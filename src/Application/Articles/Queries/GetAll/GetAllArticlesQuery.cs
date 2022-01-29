using Domain.Entities;

namespace Application.Articles.Queries.GetAll;

public sealed record GetAllArticlesQuery(PaginationFilter PaginationFilter) : IRequestPaginatedWrapper<Article>;

public class GetAllArticlesQueryHandler : IRequestPaginatedHandlerWrapper<GetAllArticlesQuery, Article>
{
    private readonly IApplicationDbContext _context;
    private readonly IPaginate _paginate;

    public GetAllArticlesQueryHandler(IApplicationDbContext context, IPaginate paginate)
    {
        (_context, _paginate) = (context, paginate);
    }

    public async Task<PaginatedServiceResult<Article>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
    {
        var paginatedArticles = await _paginate.GetPaginatedResultAsync<Article, Article>(
            _context.Articles.AsQueryable(), request.PaginationFilter, cancellationToken);
        
        return paginatedArticles;
    }
}
