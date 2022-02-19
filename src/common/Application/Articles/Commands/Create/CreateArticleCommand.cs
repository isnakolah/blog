using Common.Application.Articles.Commands.DTOs;

namespace Common.Application.Articles.Commands.Create;

public sealed record CreateArticleCommand(ArticleCreateDTO Article) : IRequestWrapper;

public class CreateArticleCommandHandler : IRequestHandlerWrapper<CreateArticleCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateArticleCommandHandler(IMapper mapper, IApplicationDbContext context)
    {
        (_mapper, _context) = (mapper, context);
    }

    public async Task<ServiceResult> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = request.Article.MapToEntity(_mapper);

        article.Created();

        _context.Articles.Add(article);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success();
    }
}
