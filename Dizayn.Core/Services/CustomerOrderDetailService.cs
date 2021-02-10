using CustomerOrder.Core.Interface.Base;
using CustomerOrder.Core.Model.DbModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrder.Core.Services
{
    public class CustomerOrderDetailService
    {
        private readonly ICustomerOrderDetailRepository  _customerOrderDetailRepository;
        private readonly ICustomerOrdersRepository _customerOrdersRepository;
        private readonly ICustomerRepository _customerRepository;

        public CustomerOrderDetailService(ICustomerOrderDetailRepository customerOrderDetailRepository, ICustomerOrdersRepository customerOrdersRepository, ICustomerRepository customerRepository)
        {
            _customerOrderDetailRepository = customerOrderDetailRepository;
            _customerOrdersRepository = customerOrdersRepository;
            _customerRepository = customerRepository;
        }

        public async Task<bool> CustumerOrderDetailAdd(CustomerOrderDetail model)
        {
            var customerControl = await _customerRepository.GetListAsync(c => c.Id == model.UserId);
            if (customerControl != null)
                return false;

            var customerOrderControl = _customerOrdersRepository.FindAsync(model.CustomerOrderId);
            if (customerOrderControl != null)
                return false;

            var customerOrderDetail = await _customerOrderDetailRepository.SaveOrUpdateAsync(model);

            return customerOrderDetail.success;


        }
        public async Task<List<CustomerOrderDetail>> CustumerOrderDetails(int CustomerOrderId)
        {

            var CustumerOrderDetails = await _customerOrderDetailRepository.GetListAsync(c=>c.CustomerOrderId== CustomerOrderId);

            return CustumerOrderDetails;


        }

        public async Task<CustomerOrderDetail> CustomerOrderDetailById(int customerOrderDetailId)
        {

            var customerOrderDetail = await _customerOrderDetailRepository.FindAsync(customerOrderDetailId);

            return customerOrderDetail;

        }

        public async Task<bool> CustomerOrderDetailRemove(CustomerOrderDetail model)
        {
            var customerControl = await _customerRepository.GetListAsync(c => c.Id == model.UserId);
            if (customerControl != null)
                return false;

            var customerOrderControl = _customerOrdersRepository.FindAsync(model.CustomerOrderId);
            if (customerOrderControl != null)
                return false;

            var customerOrderDetail = await _customerOrderDetailRepository.DeleteAsync(c=>c.Id==model.Id);

            return customerOrderDetail.success;

        }
    }
}
