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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CustomerAdd([FromBody] Customer model)
        {
           var result = await _customerService.CustomerAdd(model);

            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = result
            }); ;
        }
        [HttpGet]
        public async Task<IActionResult> Customers()
        {
            var customers = await _customerService.Customers();

            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = customers
            });
        }
        [HttpPost]
        public async Task<IActionResult> CustomerById(int customerId)
        {
           
            var customer = await _customerService.CustomerById(customerId);

            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = customer
            });
        }

    }
}