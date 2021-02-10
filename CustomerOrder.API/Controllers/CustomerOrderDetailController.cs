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
    public class CustomerOrderDetailController : ControllerBase
    {
        private readonly CustomerOrderDetailService  _customerOrderDetailService;

        public CustomerOrderDetailController(CustomerOrderDetailService customerOrderDetailService)
        {
            _customerOrderDetailService = customerOrderDetailService;
        }
        [HttpPost]
        public async Task<IActionResult> CustumerOrderDetailAdd([FromBody] CustomerOrderDetail model)
        {
            var result = await _customerOrderDetailService.CustumerOrderDetailAdd(model);

            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = result
            });  
        }
        [HttpPost]
        public async Task<IActionResult> CustomerOrderDetails(int CustomerOrderId)
        {

            var custumerOrderDetails = await _customerOrderDetailService.CustumerOrderDetails(CustomerOrderId);

          
            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = custumerOrderDetails
            });

           
        }
        [HttpPost]
        public async Task<IActionResult> CustomerOrderDetailById(int CustomerOrderDetailId)
        {

            var custumerOrderDetail = await _customerOrderDetailService.CustomerOrderDetailById(CustomerOrderDetailId);
            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = custumerOrderDetail
            });
           
        }
        [HttpPost]
        public async Task<IActionResult> CustomerOrderDetailRemove(CustomerOrderDetail model)
        {

            var custumerOrderDetail = await _customerOrderDetailService.CustomerOrderDetailRemove(model);
            return Ok(new BaseResponseModel
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = custumerOrderDetail
            });
          
        }
    }
}