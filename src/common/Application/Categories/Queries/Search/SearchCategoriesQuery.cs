using Common.Application.Categories.Queries.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Common.Application.Categories.Queries.Search;

public sealed record SearchCategoriesQuery(string categoryName) : IRequest<ICollection<CategoryGetDTO>>;

public class SearchCategoriesQueryHandler : IRequestHandler<SearchCategoriesQuery, ICollection<CategoryGetDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IConfigurationProvider _mapperConfig;

    public SearchCategoriesQueryHandler(IApplicationDbContext context, IConfigurationProvider mapperConfig)
    {
        (_context, _mapperConfig) = (context, mapperConfig);
    }

    
    public async Task<ICollection<CategoryGetDTO>> Handle(SearchCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _context.Categories
            .Where(c => c.Name.Contains(request.categoryName))
            .ProjectTo<CategoryGetDTO>(_mapperConfig)
            .ToListAsync(cancellationToken);

        return categories;
    }
}
