using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Interfaces;
using KaspiTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaspiTask.Controllers
{
    [AllowAnonymous]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return HandleResult(await _productService.Get());
        }
    }
}