using Blog.Application.Common.Models;
using Blog.Application.Common.Models.ServiceResult;

namespace Blog.Application.Common.Interfaces;

public interface IPaginate
{
    Task<PaginatedServiceResult<TOut>> GetPaginatedResultAsync<TIn, TOut>(IQueryable<TIn> source, PaginationFilter paginationFilter, 
        CancellationToken cancellationToken, params QueryParam[] queryParams)
        where TOut : class
        where TIn : class;
}