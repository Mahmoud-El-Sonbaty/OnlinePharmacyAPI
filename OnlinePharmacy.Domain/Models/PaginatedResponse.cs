
namespace OnlinePharmacy.Domain.Models
{
    public class PaginatedResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCOunt { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public PaginatedResponse(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCOunt = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
}
