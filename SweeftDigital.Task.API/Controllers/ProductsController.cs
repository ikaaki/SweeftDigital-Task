using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweeftDigital.Task.API.Models.Products;
using SweeftDigital.Task.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest request)
        {
            var id = await _productService.AddProductAsync(request.Product);

            return Ok(new
            {
                Data = id
            });
        }
    }
}
