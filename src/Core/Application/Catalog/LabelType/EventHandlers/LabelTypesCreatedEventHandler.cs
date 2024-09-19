using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LabelTypes.EventHandlers;

public class LabelTypesCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<FSH.WebApi.Domain.Catalog.LabelTypes>>
{
    private readonly ILogger<LabelTypesCreatedEventHandler> _logger;

    public LabelTypesCreatedEventHandler(ILogger<LabelTypesCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<FSH.WebApi.Domain.Catalog.LabelTypes> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}
