using System.Linq.Expressions;
using OnlinePharmacy.Application.Common.DTOs;
using OnlinePharmacy.Domain.Interfaces;
using OnlinePharmacy.Domain.Models;

namespace OnlinePharmacy.Application.Common.Interfaces
{
    public interface ILookupService<TEntity> where TEntity : class, IEntity<Guid>
    {
        Task<PaginatedResponse<LookupDTO<Guid>>> GetLookupAsync(
            string? search = null,
            int pageIndex = 1,
            int pageSize = 10,
            string orderBy = "Order",
            string orderDirection = "asc",
            Expression<Func<TEntity, bool>>? filters = null,
            CancellationToken cancellationToken = default);
    }
}
