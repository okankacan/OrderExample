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
    public class CustomerOrderController : ControllerBase
    {
        private readonly CustomerOrderService  _customerOrderService;

        public CustomerOrderController(CustomerOrderService customerOrderService)
        {
            _customerOrderService = customerOrderService;
        }

        [HttpPost]
        public async Task<IActionResult> CustomerOrderAdd([FromBody] CustomerOrders model)
        {
            var result = await _customerOrderService.CustumerOrderAdd(model);

            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = result
            }); ;
        }
        [HttpPost]
        public async Task<IActionResult> CustomerOrders(int CustomerId)
        {

            var custumerOrders = await _customerOrderService.CustumerOrderDetails(CustomerId);

            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = custumerOrders
            });

        }
        [HttpPost]
        public async Task<IActionResult> CustomerOrderById(int CustomerOrderId)
        {

            var custumerOrder = await _customerOrderService.CustomerOrderById(CustomerOrderId);

            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = custumerOrder
            });

        }
    }
}