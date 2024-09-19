using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LeadAcitvity;
public class DeleteLeadActivityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteLeadActivityRequest(Guid id) => Id = id;
}

public class DeleteLeadActivityRequestHandler : IRequestHandler<DeleteLeadActivityRequest, Guid>
{
    private readonly IRepository<LeadActivities> _repository;
    private readonly IStringLocalizer<UpdateLeadActivityRequestHandler> _localizer;
    public DeleteLeadActivityRequestHandler(IRepository<LeadActivities> repository, IStringLocalizer<UpdateLeadActivityRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteLeadActivityRequest request, CancellationToken cancellationToken)
    {
        var leadActivity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = leadActivity ?? throw new NotFoundException(_localizer["LeadActivity.notfound"]);

        // Add Domain Events to be raised after the commit
        leadActivity.DomainEvents.Add(EntityDeletedEvent.WithEntity(leadActivity));

        await _repository.DeleteAsync(leadActivity, cancellationToken);

        return request.Id;
    }
}
