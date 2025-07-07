using System.Linq.Expressions;

namespace OnlinePharmacy.Domain.Interfaces
{
    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : struct
    {
        IQueryable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> RemoveAsync(TPrimaryKey id, CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetByIdQueryable(TPrimaryKey id);
        IQueryable<TEntity> GetByIdQueryable(TEntity entity);
    }
}
