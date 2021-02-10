using CustomerOrder.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Core.Interface.Client
{
    public interface ICustomerOrderClient
    {
        Task<List<CustomerOrders>> CustomerOrders(int CustomerId);
        Task<bool> CustomerOrderAdd(CustomerOrders model);

        Task<CustomerOrders> CustomerOrderById(int CustomerOrderId);
    }
}
