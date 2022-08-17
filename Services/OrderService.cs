using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Core;
using KaspiTask.DTOs;
using KaspiTask.Helpers;
using KaspiTask.Interfaces;
using KaspiTask.Models;
using Microsoft.Extensions.Logging;

namespace KaspiTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductOrderRepository _productOrderRepository;
        private readonly IOrderInfoRepository _orderInfoRepository;
        private readonly IOrderHistoryRepository _orderHistoryRepository;
        private readonly ITransactionService _transactionService;
        public OrderService
        (
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IProductOrderRepository productOrderRepository,
            ITransactionService transactionService,
            IOrderInfoRepository orderInfoRepository,
            IOrderHistoryRepository orderHistoryRepository,
            ILogger<OrderService> logger
        )
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _productOrderRepository = productOrderRepository;
            _transactionService = transactionService;
            _orderInfoRepository = orderInfoRepository;
            _orderHistoryRepository = orderHistoryRepository;
            _logger = logger;
        }

        public Task<Result<Order>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<OrderDto>> Get(Guid id)
        {
            var order = await _orderRepository.Get(id);
            if(order == null) return null;
            return Result<OrderDto>.Success(DTOMapper.MapOrder(order));
        }

        public async Task<Result<IEnumerable<OrderDto>>> Get()
        {
            return Result<IEnumerable<OrderDto>>.Success(DTOMapper.MapOrderList(await _orderRepository.Get()));
        }

        public async Task<Result<OrderDto>> Create()
        {
            var order = await _orderRepository.GetCurrent();

            if(order != null)
                return Result<OrderDto>.Failure(new List<string>{"Вы не можете перейти на завершив текущий заказ!"});

            order = new Order();
            order.GenerateName();
            order.StatusId = (int)OrderStatusEnum.Forming;
            
            var isSuccess = await _orderRepository.Create(order);
            
            if(!isSuccess)
                return Result<OrderDto>.Failure(new List<string>{"Заказ не создан!"});

            var history = CreateOrderHistory(order.Id, (int)OrderStatusEnum.Forming);

            await _orderHistoryRepository.Create(history);

            _logger.LogWarning("Новый заказ успешно создан!");

            Order.OrderNumber++;
            
            return Result<OrderDto>.Success(DTOMapper.MapOrder(order));
        }

        public async Task<Result<OrderDto>> GetCurrent()
        {
            var order = await _orderRepository.GetCurrent();
            if(order == null)
                return null;
            return Result<OrderDto>.Success(DTOMapper.MapOrder(order));
        }
        
        private async Task<Result<ProductOrderDto>> CreateProductOrder(Order order, Product product)
        {
            var productOrder = new ProductOrder
            {
                OrderId = order.Id,
                ProductId = product.Id,
                Price = product.Price,
                Amount = 1
            };
            
            if(!await _productOrderRepository.Create(productOrder))
                return Result<ProductOrderDto>.Failure(new List<string>{"Не удалось добавить продукт к заказу!"});
            
            return Result<ProductOrderDto>.Success(DTOMapper.MapProductOrder(productOrder));
        }

        public async Task<Result<OrderDto>> Pay(CreateOrderInfoDto dto)
        {
            var order = await _orderRepository.GetCurrent();
            
            if(order == null)
                return Result<OrderDto>.Failure(new List<string>{"Не удалось найти заказ!"});

            var orderInfo = DTOMapper.MapOrderInfoFromDto(dto);
    
            if(!await _orderInfoRepository.Create(orderInfo))
                return Result<OrderDto>.Failure(new List<string>{"Не удалось создать информацию о заказе!"});

            if(!await AddProducts(dto.Products))
                return Result<OrderDto>.Failure(new List<string>{"Не удалось добавить товары в заказ!"});

            var history = CreateOrderHistory(order.Id, (int)OrderStatusEnum.Paid);

            if(!await _orderHistoryRepository.Create(history))
            {
                await _orderInfoRepository.Delete(orderInfo);
                return Result<OrderDto>.Failure(new List<string>{"Не удалось создать историю о заказе!"});
            }
                
            order.StatusId = (int)OrderStatusEnum.Paid;
            order.InfoId = orderInfo.Id;  

            if(!await _orderRepository.Update(order))
            {
                await _orderInfoRepository.Delete(orderInfo);
                await _orderHistoryRepository.Delete(history);
                return Result<OrderDto>.Failure(new List<string>{"Не удалось обновить заказ!"});
            }
            
            return Result<OrderDto>.Success(DTOMapper.MapOrder(order));
        }

        public async Task<Result<OrderDto>> Complete(Guid id)
        {
            var order = await _orderRepository.Get(id);
            
            if(order == null)
                return Result<OrderDto>.Failure(new List<string>{"Не удалось найти заказ!"});

            var history = CreateOrderHistory(order.Id, (int)OrderStatusEnum.Completed);

            if(!await _orderHistoryRepository.Create(history))
                return Result<OrderDto>.Failure(new List<string>{"Не удалось создать историю о заказе!"});
    
            order.StatusId = (int)OrderStatusEnum.Completed;

            if(!await _orderRepository.Update(order))
            {
                await _orderHistoryRepository.Delete(history);
                return Result<OrderDto>.Failure(new List<string>{"Не удалось обновить заказ!"});
            }

            return Result<OrderDto>.Success(DTOMapper.MapOrder(order));
        }

        public async Task<Result<IEnumerable<ProductOrderDto>>> GetProducts(Guid orderId)
        {
            return Result<IEnumerable<ProductOrderDto>>
                .Success(DTOMapper.MapProductOrderList(await _productOrderRepository.Get(orderId)));
        }
        public async Task<Result<IEnumerable<OrderHistoryDto>>> GetHistory(Guid orderId)
        {
            return Result<IEnumerable<OrderHistoryDto>>
                .Success(DTOMapper.MapOrderHistoryList(await _orderHistoryRepository.Get(orderId)));
        }
        private OrderHistory CreateOrderHistory(Guid orderId, int statusId)
        {
            return new OrderHistory
            {
                CreatedAt = DateTime.Now,
                OrderId = orderId,
                StatusId = statusId
            };
        }

        private async Task<bool> AddProducts(List<CreateProductOrderDto> productsInOrder)
        {
            var order = await _orderRepository.GetCurrent();
            if(order == null) return false;
            
            var productOrderList = new List<ProductOrder>();
            foreach(var item in productsInOrder)
            {
                _logger.LogWarning(item.ProductId.ToString());
                var productOrder = new ProductOrder
                {
                    Amount = item.Amount,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    OrderId = order.Id
                };
                productOrderList.Add(productOrder);
            }

            return await _productOrderRepository.CreateRange(productOrderList) > 0;
        }
    }
}