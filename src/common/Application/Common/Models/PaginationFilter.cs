namespace Blog.Application.Common.Models;

public record PaginationFilter
{
    public PaginationFilter()
    {
    }

    public PaginationFilter(int pageNumber, int pageSize, DateOnly from, DateOnly to, bool useDateRangeOnly)
    {
        (PageNumber, PageSize, From, To, UseDateRangeOnly) = (pageNumber, pageSize, from, to, useDateRangeOnly);
    }

    public PaginationFilter(int pageSize, DateOnly from, DateOnly to, bool useDateRangeOnly)
    {
        (PageSize, From, To, UseDateRangeOnly) = (pageSize, from, to, useDateRangeOnly);
    }
    
    public int PageNumber { get; private set; } = 1;
    public int PageSize { get; } = 10;
    public DateOnly? From { get; }
    public DateOnly? To { get; }
    public bool UseDateRangeOnly { get; }
    
    public PaginationFilter ChangePageNumber(int pageNumber)
    {
        PageNumber = pageNumber;
        return this;
    }
}