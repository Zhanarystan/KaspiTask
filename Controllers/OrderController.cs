using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.DTOs;
using KaspiTask.Interfaces;
using KaspiTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaspiTask.Controllers
{
    [AllowAnonymous]
    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return HandleResult(await _orderService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> Get(Guid id)
        {
            return HandleResult(await _orderService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create()
        {
            return HandleResult(await _orderService.Create());
        }

        [HttpGet("current")]
        public async Task<ActionResult<Order>> GetCurrent()
        {
            return HandleResult(await _orderService.GetCurrent());
        }

        [HttpPost("pay")]
        public async Task<IActionResult> Pay(CreateOrderInfoDto dto)
        {
            return HandleResult(await _orderService.Pay(dto));
        }

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id)
        {
            return HandleResult(await _orderService.Complete(id));
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProducts(Guid id)
        {
            return HandleResult(await _orderService.GetProducts(id));
        }

        [HttpGet("{id}/history")]
        public async Task<IActionResult> GetHistory(Guid id)
        {
            return HandleResult(await _orderService.GetHistory(id));
        }

    }
}