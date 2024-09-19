using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LabelTypes.EventHandlers;

public class LabelTypesDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<FSH.WebApi.Domain.Catalog.LabelTypes>>
{
    private readonly ILogger<LabelTypesDeletedEventHandler> _logger;

    public LabelTypesDeletedEventHandler(ILogger<LabelTypesDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<FSH.WebApi.Domain.Catalog.LabelTypes> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}