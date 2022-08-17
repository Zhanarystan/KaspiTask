using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaspiTask.Models;
using Microsoft.EntityFrameworkCore;

namespace KaspiTask.Data
{
    public class Seed 
    {
        public static async Task SeedData(DataContext context)
        {
            if(!await context.Product.AnyAsync())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "IPhone 12",
                        Price = 400000,
                        ImageUrl = "https://www.tradeinn.com/f/13782/137821852/apple-iphone-12-pro-max-6gb-256gb-6.7.jpg"
                    },
                    new Product
                    {
                        Name = "IPhone 13",
                        Price = 600000,
                        ImageUrl = "https://www.apple.com/newsroom/images/product/iphone/geo/Apple_iphone13_hero_geo_09142021_inline.jpg.large.jpg"
                    },
                    new Product 
                    {
                        Name = "Пылесос Dyson",
                        Price = 550000,
                        ImageUrl = "https://object.pscloud.io/cms/cms/Photo/img_0_24_698_3.jpg"
                    },
                    new Product 
                    {
                        Name = "Ноутбук Asus Zenbook 13",
                        Price = 520000,
                        ImageUrl = "https://forcecom.kz/upload/iblock/e7c/e7cb06418998a1fdb13c134a639533ea.jpg"
                    },
                    new Product 
                    {
                        Name = "Ноутбук Macbook Air 2018",
                        Price = 300000,
                        ImageUrl = "https://media.wired.com/photos/5bd883dc5b66a763e54f0b22/191:100/w_1280,c_limit/macbookair3.jpg"
                    },
                    new Product 
                    {
                        Name = "Ноутбук Macbook Air 2022",
                        Price = 600000,
                        ImageUrl = "https://images.hindustantimes.com/tech/img/2022/07/29/960x540/IMG_4284_1657976137822_1659067579143_1659067579143.jpg"
                    },
                    new Product 
                    {
                        Name = "Ноутбук Macbook Pro 2021",
                        Price = 1500000,
                        ImageUrl = "https://s12.stc.all.kpcdn.net/expert/wp-content/uploads/2022/02/apple.jpg"
                    },
                    new Product 
                    {
                        Name = "Samsung Galaxy S21",
                        Price = 350000,
                        ImageUrl = "https://object.pscloud.io/cms/cms/Photo/img_0_77_3377_12_1.jpg"
                    },
                    new Product 
                    {
                        Name = "Samsung Galaxy Note 20 Ultra",
                        Price = 450000,
                        ImageUrl = "https://www.ixbt.com/img/x780x600/r30/00/02/32/91/IMG4409.jpg"
                    },
                    new Product 
                    {
                        Name = "Apple Watch SE",
                        Price = 179000,
                        ImageUrl = "https://object.pscloud.io/cms/cms/Photo/img_0_911_587_7_1.jpg"
                    },
                    new Product 
                    {
                        Name = "LED телевизор LG 43L",
                        Price = 289000,
                        ImageUrl = "https://object.pscloud.io/cms/cms/Photo/img_0_95_1948_0_1.jpg"
                    },
                    new Product 
                    {
                        Name = "LED телевизор Samsung UE32",
                        Price = 229000,
                        ImageUrl = "https://object.pscloud.io/cms/cms/Photo/img_0_95_1716_0_1.jpg"
                    }
                };

                await context.Product.AddRangeAsync(products);
            }    
            if(!await context.OrderStatus.AnyAsync())
            {
                var statuses = new List<OrderStatus>
                {
                    new OrderStatus
                    {
                        Name = "Формируется"
                    },
                    new OrderStatus
                    {
                        Name = "Оплачен"
                    },
                    new OrderStatus
                    {
                        Name = "Выполнен"
                    }
                };

                await context.OrderStatus.AddRangeAsync(statuses);
            }
            await context.SaveChangesAsync();
        }
    }
}