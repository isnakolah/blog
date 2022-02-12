using Common.Application.Articles.Queries.DTOs;
using Common.Domain.Entities;

namespace Common.Application.Articles.Queries.GetTrending;

public sealed record GetTrendingArticlesQuery : IRequestPaginatedWrapper<ArticleGetDTO>;

public class GetTrendingArticleQueryHandler : IRequestHandlerPaginatedWrapper<GetTrendingArticlesQuery, ArticleGetDTO>
{
    private readonly IApplicationDbContext _context;
    private readonly IPaginate _paginate;

    public GetTrendingArticleQueryHandler(IApplicationDbContext context, IPaginate paginate)
    {
        (_context, _paginate) = (context, paginate);
    }

    public async Task<PaginatedServiceResult<ArticleGetDTO>> Handle(GetTrendingArticlesQuery request, CancellationToken cancellationToken)
    {
        var paginatedArticles = await _paginate.GetPaginatedResultAsync<Article, ArticleGetDTO>(
            _context.Articles.AsQueryable(), new PaginationFilter(), cancellationToken);
        
        return paginatedArticles;
    }
}