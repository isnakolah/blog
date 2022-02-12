namespace Common.Application.Common.Models.ServiceResult;

public record PaginatedServiceResult<T> : ServiceResult<IEnumerable<T>>
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalPages { get; init; }
    public int TotalRecords { get; init; }
    public DateOnly From { get; init; }  
    public DateOnly To { get; init; }

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