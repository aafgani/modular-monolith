using System;
using System.Linq.Expressions;

namespace Application.Abstractions.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "");

    Task<TEntity> GetByIdAsync(int id);

    void Insert(TEntity entity);

    void Delete(object id);

    void Delete(TEntity entityToDelete);

    void Update(TEntity entityToUpdate);
}
