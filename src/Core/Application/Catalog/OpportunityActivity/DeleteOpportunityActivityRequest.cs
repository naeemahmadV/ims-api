using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.OpportunityActivity;
public class DeleteOpportunityActivityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteOpportunityActivityRequest(Guid id) => Id = id;
}

public class DeleteOpportunityActivityRequestHandler : IRequestHandler<DeleteOpportunityActivityRequest, Guid>
{
    private readonly IRepository<OpportunityActivities> _repository;
    private readonly IStringLocalizer<DeleteOpportunityActivityRequestHandler> _localizer;
    public DeleteOpportunityActivityRequestHandler(IRepository<OpportunityActivities> repository, IStringLocalizer<DeleteOpportunityActivityRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteOpportunityActivityRequest request, CancellationToken cancellationToken)
    {
        var opportunityActivity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = opportunityActivity ?? throw new NotFoundException(_localizer["OpportunityActivity.notfound"]);

        // Add Domain Events to be raised after the commit
        opportunityActivity.DomainEvents.Add(EntityDeletedEvent.WithEntity(opportunityActivity));

        await _repository.DeleteAsync(opportunityActivity, cancellationToken);

        return request.Id;
    }
}