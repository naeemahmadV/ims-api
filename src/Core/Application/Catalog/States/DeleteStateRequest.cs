using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class DeleteStateRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteStateRequest(Guid id) => Id = id;
}

public class DeleteStateRequestHandler : IRequestHandler<DeleteStateRequest, Guid>
{
    private readonly IRepository<Domain.Catalog.State> _repository;
    private readonly IStringLocalizer<DeleteStateRequestHandler> _localizer;

    public DeleteStateRequestHandler(IRepository<State> repository, IStringLocalizer<DeleteStateRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteStateRequest request, CancellationToken cancellationToken)
    {
        var state = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = state ?? throw new NotFoundException(_localizer["State.notfound"]);

        // Add Domain Events to be raised after the commit
        state.DomainEvents.Add(EntityDeletedEvent.WithEntity(state));

        await _repository.DeleteAsync(state, cancellationToken);

        return request.Id;
    }
}