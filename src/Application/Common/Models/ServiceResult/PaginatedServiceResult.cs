namespace Application.Common.Models.ServiceResult;

public record PaginatedServiceResult<T> : ServiceResult<IEnumerable<T>>
{
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int TotalRecords { get; }
    public DateOnly From { get; }
    public DateOnly To { get; }

    public PaginatedServiceResult()
    {
    }

    public PaginatedServiceResult(ServiceError error) : base(error)
    {
    }

    public PaginatedServiceResult(IEnumerable<T> data, PaginationFilter paginationFilter, int totalPages, int totalRecords, DateOnly from, DateOnly to) : base(data)
    {
        PageNumber = paginationFilter.PageNumber.Equals(0) ? 0 : paginationFilter.PageNumber;
        TotalPages = totalPages;
        PageSize = paginationFilter.PageSize;
        TotalRecords = totalRecords;
        From = from;
        To = to;
    }
}