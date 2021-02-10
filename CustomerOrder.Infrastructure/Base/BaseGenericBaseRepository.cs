
using CustomerOrder.Core.Interface.Base;
using CustomerOrder.Core.Model.DbModels.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace CustomerOrder.Infrastructure.Base
{
    public class BaseGenericBaseRepository<TModel, TKey, CustomDbContext> : IBaseGenericRepository<TModel, TKey, CustomDbContext>
where TModel : class, IDbEntity<TKey>
where CustomDbContext : DbContext
    {


        public CustomDbContext Context { get; }
 
        public DbSet<TModel> DbSet { get; }

        public BaseGenericBaseRepository(CustomDbContext context,    DbSet<TModel> dbSet)
        {
            Context = context;
         
            DbSet = Context.Set<TModel>();

        }

        protected static readonly Expression<Func<TModel, TKey>> DefaultSortExpression = c => c.Id;

        public virtual async Task<TModel> FindAsync(TKey id)
        {
            return await DbSet.FindAsync(id);
        }



        public virtual async Task<(bool success, int count)> SaveOrUpdateAsync(TModel entity)
        {
            try
            {
                return await SaveOrUpdateWithoutCatchAsync(entity);
            }
            catch (DbUpdateException duEx)
            {
                return (false, 0);
            }
            catch (Exception ex)
            {
                return (false, 0);
            }
        }

        public virtual async Task<(bool success, int count)> SaveOrUpdateWithoutCatchAsync(TModel entity)
        {
            if (IsPersistent(entity))
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                entity.CreateDate = DateTime.UtcNow;
                DbSet.Add(entity);
            }
            SetUpdateDate(entity);

            var changes = await Context.SaveChangesAsync();

            return (true, changes);
        }

        public virtual async Task<(bool success, int count)> SaveWithoutCatchAsync(TModel entity)
        {
            entity.CreateDate = DateTime.UtcNow;
            DbSet.Add(entity);
            SetUpdateDate(entity);

            var changes = await Context.SaveChangesAsync();

            return (true, changes);
        }
        public virtual async Task<(bool success, int count)> SaveAsync(TModel entity)
        {
            try
            {
                return await SaveWithoutCatchAsync(entity);
            }
            catch (DbUpdateException duEx)
            {
             
                return (false, 0);
            }
            catch (Exception ex)
            {
             
                return (false, 0);
            }
        }

        public virtual async Task<(bool success, int count)> DeleteAsync(Expression<Func<TModel, bool>> predicate)
        {
            try
            {
                var objects = await QueryableToListAsync(DbSet.Where(predicate));
                if (objects != null)
                {
                    DbSet.RemoveRange(objects);
                    return (true, Context.SaveChanges());
                }
                return (true, 0);
            }
            catch (Exception exc)
            {
                return (false, 0);
            }
        }

        public virtual async Task<List<TModel>> GetListAsync()
        {
            return await QueryableToListAsync(DbSet.OrderByDescending(DefaultSortExpression).AsNoTracking());
        }

        public virtual async Task<List<TModel>> GetListAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await QueryableToListAsync(DbSet.Where(predicate).OrderByDescending(DefaultSortExpression));
        }

        #region database interactions async methods




        protected virtual bool IsPersistent(IDbEntity<TKey> entity)
        {
            return !entity.Id.Equals(default(TKey));
        }
        protected virtual PropertyInfo SetUpdateDate(TModel entity)
        {
            var properties = typeof(TModel).GetProperties();
            var updateDateProperty = properties.FirstOrDefault(c => c.Name == "UpdateDate");
            if (updateDateProperty != null)
            {
                updateDateProperty.SetValue(entity, DateTime.UtcNow);
            }
            return updateDateProperty;
        }
        private async Task<List<U>> QueryableToListAsync<U>(IQueryable<U> queryable)
        {
            try
            {
                return await queryable.ToListAsync();
            }
            catch (Exception exc)
            {

                return null;
            }
        }

        #endregion
    }

}
