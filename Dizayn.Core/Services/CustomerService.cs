using CustomerOrder.Core.Interface.Base;
using CustomerOrder.Core.Model.DbModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrder.Core.Services
{
    public  class CustomerService
    {

        private readonly ICustomerRepository  _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> CustomerAdd(Customer model)
        {
            var customerControl =await  _customerRepository.GetListAsync(c => c.Email == model.Email);
            if (customerControl != null)
                return false;

            var customer = await _customerRepository.SaveOrUpdateAsync(model);

            return customer.success;


        }
        public async Task<List<Customer>> Customers()
        {

            var customers = await _customerRepository.GetListAsync();

            return customers;


        }

        public async Task<Customer> CustomerById(int customerId)
        {

            var customers = await _customerRepository.FindAsync(customerId);

            return customers;


        }

    }
}
