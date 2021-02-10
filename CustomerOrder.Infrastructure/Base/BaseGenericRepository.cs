using CustomerOrder.Core.Helpers;
using CustomerOrder.Core.Model.DbModels.Interface;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrder.Infrastructure.Base
{

    public class BaseGenericRepository<TModel, TKey, CustomDbContext> : BaseGenericBaseRepository<TModel, TKey, CustomDbContext>
   where TModel : class, IDbEntity<TKey>
   where CustomDbContext : DbContext
    {
        public BaseGenericRepository() : base(
                 ServiceGetter.GetService<CustomDbContext>(), null)
        { }
    }
}
