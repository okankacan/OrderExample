using CustomerOrder.Core.Model.DbModels.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomerOrder.Core.Interface.Base
{
    public interface IBaseGenericRepository<TModel, TKey, CustomDbContext>
      where TModel : class, IDbEntity<TKey>
      where CustomDbContext : DbContext
    {
        CustomDbContext Context { get; }

        DbSet<TModel> DbSet { get; }

        #region async methods

        Task<TModel> FindAsync(TKey id);


        Task<(bool success, int count)> SaveOrUpdateAsync(TModel entity);


        Task<(bool success, int count)> SaveAsync(TModel entity);

        Task<(bool success, int count)> DeleteAsync(Expression<Func<TModel, bool>> predicate);

        Task<List<TModel>> GetListAsync();

        Task<List<TModel>> GetListAsync(Expression<Func<TModel, bool>> predicate);


        #endregion


    }
}
