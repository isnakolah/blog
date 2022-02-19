using Common.Application.Categories.Queries.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Common.Application.Categories.Queries.Get;

public sealed record GetCategoriesQuery(PaginationFilter PaginationFilter) : IRequest<List<CategoryGetDTO>>;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryGetDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IConfigurationProvider _mapperConfig;

    public GetCategoryQueryHandler(IApplicationDbContext context, IConfigurationProvider mapperConfig)
    {
        (_context, _mapperConfig) = (context, mapperConfig);
    }

    public async Task<List<CategoryGetDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _context.Categories
            .ProjectTo<CategoryGetDTO>(_mapperConfig)
            .ToListAsync(cancellationToken);

        return categories;
    }
}
