using CustomerOrder.Core.Model.DbModel;
using CustomerOrder.Core.Model.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrder.Core.Contexts
{
    public class BaseDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<CustomerOrders> CustomerOrders { get; set; }

        public DbSet<CustomerOrderDetail> CustomerOrderDetails { get; set; }

        public BaseDbContext(DbContextOptions<BaseDbContext> options)
          : base(options)
        {
        }

      



    }
}
