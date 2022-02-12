using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Application.Common.Models;
using Common.Application.Common.Models.ServiceResult;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PaginateService : IPaginate
{
    private readonly IConfigurationProvider _mapperConfig;

    public PaginateService(IConfigurationProvider mapperConfig)
    {
        _mapperConfig = mapperConfig;
    }

    public async Task<PaginatedServiceResult<TOut>> GetPaginatedResultAsync<TIn, TOut>(
        IQueryable<TIn> source, PaginationFilter paginationFilter, CancellationToken cancellationToken, params QueryParam[] queryParams)
        where TOut : class
        where TIn : class
    {
        var data = source.ProjectTo<TOut>(_mapperConfig).AsEnumerable();
        var totalRecords = await source.CountAsync(cancellationToken);

        var paginatedResult = new PaginatedServiceResult<TOut>(
            data!, paginationFilter, 1, totalRecords, paginationFilter.From ?? DateOnly.MinValue, paginationFilter.To ?? DateOnly.MaxValue);

        return paginatedResult;
    }
}