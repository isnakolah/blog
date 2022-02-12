using Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Common.Application.Articles.Queries.GetTrending;

public sealed record GetTrendingArticlesQuery : IRequestPaginatedWrapper<Article>;

public class GetTrendingArticleQueryHandler : IRequestHandlerPaginatedWrapper<GetTrendingArticlesQuery, Article>
{
    private readonly IApplicationDbContext _context;

    public GetTrendingArticleQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedServiceResult<Article>> Handle(GetTrendingArticlesQuery request, CancellationToken cancellationToken)
    {
        var article = await _context.Articles.ToArrayAsync();

        var paginatedResponse = new PaginatedServiceResult<Article>
        {
            Data = article
        };

        return paginatedResponse;
    }
}