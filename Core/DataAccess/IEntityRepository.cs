using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess;

public interface IEntityRepository<T> where T : class, IEntity, new()
{
    T Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

    List<T> GetList(Expression<Func<T, bool>> predicate = null,
                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

    List<T> GetListByDynamic(Dynamic.Dynamic dynamic,
                             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

    T Add(T entity);

    T Update(T entity);

    T Delete(T entity);
}