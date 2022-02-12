using Common.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Common.Application.Articles.EventHandlers.ArticleAddedToCategoryEventHandlers;

public class SendMessageHandler : INotificationHandler<DomainEventNotification<ArticleAddedToCategoryEvent>>
{
    private readonly  ILogger<SendMessageHandler> _logger;

    public SendMessageHandler(ILogger<SendMessageHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DomainEventNotification<ArticleAddedToCategoryEvent> notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}