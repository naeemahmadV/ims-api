using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LabelTypes.EventHandlers;

public class LabelTypesUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<FSH.WebApi.Domain.Catalog.LabelTypes>>
{
    private readonly ILogger<LabelTypesUpdatedEventHandler> _logger;

    public LabelTypesUpdatedEventHandler(ILogger<LabelTypesUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<FSH.WebApi.Domain.Catalog.LabelTypes> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}