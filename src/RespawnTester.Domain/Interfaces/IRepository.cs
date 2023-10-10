using System.Linq.Expressions;

namespace RespawnTester.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);

    Task<TEntity> GetByID(object id);

    Task Insert(TEntity entity);

    Task Delete(object id);

    Task Delete(TEntity entityToDelete);

    Task Update(TEntity entityToUpdate);
}
