using CustomerOrder.Core.Contexts;
using CustomerOrder.Core.Model.DbModel;

namespace CustomerOrder.Core.Interface.Base
{
    public interface ICustomerOrdersRepository : IBaseRepository<CustomerOrders, BaseDbContext>
    {
    }
    
}
