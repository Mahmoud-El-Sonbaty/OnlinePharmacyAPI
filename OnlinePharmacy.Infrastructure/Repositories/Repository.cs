using System.Linq.Expressions;
using OnlinePharmacy.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using OnlinePharmacy.Infrastructure.Data;

namespace OnlinePharmacy.Infrastructure.Repositories
{
    public class Repository<TEntity, TPrimaryKey>(AppDbContext context) : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : struct
    {
        internal readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
        internal readonly AppDbContext _context = context;

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync([id], cancellationToken: cancellationToken);
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            return (await _dbSet.AddAsync(entity, cancellationToken)).Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Update(entity).Entity;
            }, cancellationToken);
        }

        public async Task<TEntity> RemoveAsync(TPrimaryKey id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            return _dbSet.Remove(entity).Entity;
        }

        public IQueryable<TEntity> GetByIdQueryable(TPrimaryKey id)
        {
            var keyName = _context.Model.FindEntityType(typeof(TEntity))
                .FindPrimaryKey().Properties
                .Single().Name;

            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, keyName);
            var value = Expression.Constant(id);
            var equals = Expression.Equal(property, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equals, parameter);

            return _dbSet.Where(lambda);
        }

        public IQueryable<TEntity> GetByIdQueryable(TEntity entity)
        {
            var keyName = _context.Model.FindEntityType(typeof(TEntity))
                .FindPrimaryKey().Properties
                .Single().Name;

            var id = (TPrimaryKey)typeof(TEntity).GetProperty(keyName).GetValue(entity);
            return GetByIdQueryable(id);
        }

    }
}
