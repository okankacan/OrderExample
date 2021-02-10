using CustomerOrder.Core.Model.DbModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerOrder.Core.Interface.Base;

namespace CustomerOrder.Core.Services
{
    public class ProductService
    {
        private readonly IProductRepository  _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> ProductAdd(Product model)
        {

            var product = await _productRepository.SaveOrUpdateAsync(model);

            return product.success;
        }

        public async Task<List<Product>> Products()
        {

            var products = await _productRepository.GetListAsync();

            return products;
        }

        public async Task<Product> ProductById(int productId)
        {

            var product = await _productRepository.FindAsync(productId);

            return product;

        }
    }
}
