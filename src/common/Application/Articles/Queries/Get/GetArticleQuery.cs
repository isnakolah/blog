using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Application.Articles.Queries.DTOs;
using Common.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Common.Application.Articles.Queries.Get;

public record GetArticleQuery(string Slug) : IRequestWrapper<ArticleGetDTO?>;

public class GetArticleQueryHandler : IRequestHandlerWrapper<GetArticleQuery, ArticleGetDTO?>
{
    private readonly IConfigurationProvider _mapperConfig;
    private readonly IApplicationDbContext _context;

    public GetArticleQueryHandler(IConfigurationProvider mapperConfig, IApplicationDbContext context)
    {
        (_mapperConfig, _context) = (mapperConfig, context);
    }

    public async Task<ServiceResult<ArticleGetDTO?>> Handle(GetArticleQuery request, CancellationToken cancellationToken)
    {
        var title = request.Slug.RemakeStringFromSlug();
        
        var article = await _context.Articles
            .Where(a => a.Title.Contains(title, StringComparison.InvariantCultureIgnoreCase))
            .ProjectTo<ArticleGetDTO>(_mapperConfig)
            .FirstOrDefaultAsync();

        return ServiceResult.Success(article);
    }
}