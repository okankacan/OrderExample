using CustomerOrder.Core.Model.DbModel;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CustomerOrder.Core.Interface.Client
{
    public interface ICustomerClient
    {
        Task<List<Customer>> Customers();
        Task<bool> CustomerAdd(Customer model);

        Task<Customer> CustomerById(int customerId);
    }
}
