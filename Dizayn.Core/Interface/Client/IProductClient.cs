using CustomerOrder.Core.Model.DbModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrder.Core.Interface.Client
{
    public interface IProductClient
    {
        Task<List<Product>> Products();
        Task<bool> ProductAdd(Product model);

        Task<Product> ProductById(int productId);
    }
}
