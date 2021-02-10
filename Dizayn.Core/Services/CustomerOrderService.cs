using CustomerOrder.Core.Model.DbModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerOrder.Core.Interface.Base;
namespace CustomerOrder.Core.Services
{
   public class CustomerOrderService
    {
        private readonly ICustomerOrdersRepository  _customerOrdersRepository;
        private readonly ICustomerRepository _customerRepository;

        public CustomerOrderService(ICustomerOrdersRepository customerOrdersRepository, ICustomerRepository customerRepository)
        {
            _customerOrdersRepository = customerOrdersRepository;
            _customerRepository = customerRepository;
        }

        public async Task<bool> CustumerOrderAdd(CustomerOrders model)
        {
            var customerControl = await _customerRepository.GetListAsync(c => c.Email == model.Email);
            if (customerControl != null)
                return false;

            var customerOrder = await _customerOrdersRepository.SaveOrUpdateAsync(model);

            return customerOrder.success;


        }

        public async Task<List<CustomerOrders>> CustumerOrderDetails(int customerId)
        {

            var custumerOrders = await _customerOrdersRepository.GetListAsync(c=>c.UserId== customerId);

            return custumerOrders;
        }
        public async Task<CustomerOrders> CustomerOrderById(int customerOrderId)
        {

            var customerOrder = await _customerOrdersRepository.FindAsync(customerOrderId);

            return customerOrder;

        }
    }
}
