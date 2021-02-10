using CustomerOrder.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace CustomerOrder.Core.Interface.Client
{
   public interface ICustomerOrderDetailClient
    {
        Task<List<CustomerOrderDetail>> CustomerOrderDetails(int CustomerOrderId);
        Task<bool> CustomerOrderDetailAdd(CustomerOrderDetail model);

        Task<CustomerOrderDetail> CustomerOrderDetailById(int CustomerOrderDetailId);

        Task<bool> CustomerOrderDetailRemove(int CustomerOrderDetailId);
    }
}
