using CustomerOrder.Core.Interface.Base;
using CustomerOrder.Core.Model.DbModels.Interface;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrder.Infrastructure.Base
{
    public class BaseRepository<TModel, CustomDbContext> : BaseGenericRepository<TModel, int, CustomDbContext>, IBaseRepository<TModel, CustomDbContext>
     where TModel : class, IPersistentEntity
     where CustomDbContext : DbContext
    {
    }
}
