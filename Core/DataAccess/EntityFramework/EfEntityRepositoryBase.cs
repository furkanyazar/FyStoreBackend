using Core.DataAccess.Dynamic;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    public TEntity Get(Expression<Func<TEntity, bool>> predicate,
                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        using var context = new TContext();
        IQueryable<TEntity> queryable = context.Set<TEntity>();
        if (include != null) queryable = include(queryable);
        return queryable.FirstOrDefault(predicate);
    }

    public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null,
                                 Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        using var context = new TContext();
        IQueryable<TEntity> queryable = context.Set<TEntity>();
        if (include != null) queryable = include(queryable);
        return predicate == null ? queryable.ToList() : queryable.Where(predicate).ToList();
    }

    public List<TEntity> GetListByDynamic(Dynamic.Dynamic dynamic,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        using var context = new TContext();
        IQueryable<TEntity> queryable = context.Set<TEntity>().ToDynamic(dynamic);
        if (include != null) queryable = include(queryable);
        return queryable.ToList();
    }

    public TEntity Add(TEntity entity)
    {
        using var context = new TContext();
        context.Entry(entity).State = EntityState.Added;
        context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        using var context = new TContext();
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        using var context = new TContext();
        context.Entry(entity).State = EntityState.Deleted;
        context.SaveChanges();
        return entity;
    }
}