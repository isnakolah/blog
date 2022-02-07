using Blog.Application.Common.Models;
using Blog.Application.Common.Models.ServiceResult;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PaginateService : IPaginate
{
    public async Task<PaginatedServiceResult<TOut>> GetPaginatedResultAsync<TIn, TOut>(IQueryable<TIn> source, PaginationFilter paginationFilter, 
        CancellationToken cancellationToken, params QueryParam[] queryParams)
        where TOut : class
        where TIn : class
    {
        var data = source.Select(x => x as TOut).AsEnumerable();
        var totalRecords = await source.CountAsync(cancellationToken);

        var paginatedResult = new PaginatedServiceResult<TOut>(data!, paginationFilter, 1, 1,
            paginationFilter.From ?? DateOnly.MinValue, paginationFilter.To ?? DateOnly.MaxValue);

        return paginatedResult;
    }
}