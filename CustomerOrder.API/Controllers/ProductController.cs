using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using CustomerOrder.Core.Model.DbModel;
using CustomerOrder.Core.Model.ResponseModel;
using CustomerOrder.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService  _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd([FromBody] Product model)
        {
            var result = await _productService.ProductAdd(model);

            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = result
            }); ;
        }

        [HttpGet]

        public async Task<IActionResult> Products()
        {
            var products = await _productService.Products();

            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = products
            }); ;
        }

        [HttpPost]
        public async Task<IActionResult> ProductById(int productId)
        {
            var result = await _productService.ProductById(productId);

            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = result
            }); ;
        }
    }
}