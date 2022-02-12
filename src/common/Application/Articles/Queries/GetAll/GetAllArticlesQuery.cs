using Common.Application.Articles.Queries.DTOs;
using Common.Domain.Entities;

namespace Common.Application.Articles.Queries.GetAll;

public sealed record GetAllArticlesQuery(PaginationFilter PaginationFilter) : IRequestPaginatedWrapper<ArticleGetDTO>;

public class GetAllArticlesQueryHandler : IRequestHandlerPaginatedWrapper<GetAllArticlesQuery, ArticleGetDTO>
{
    private readonly IApplicationDbContext _context;
    private readonly IPaginate _paginate;

    public GetAllArticlesQueryHandler(IApplicationDbContext context, IPaginate paginate)
    {
        (_context, _paginate) = (context, paginate);
    }

    public async Task<PaginatedServiceResult<ArticleGetDTO>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
    {
        var paginatedArticles = await _paginate.GetPaginatedResultAsync<Article, ArticleGetDTO>(
            _context.Articles.AsQueryable(), request.PaginationFilter, cancellationToken);
        
        return paginatedArticles;
    }
}
