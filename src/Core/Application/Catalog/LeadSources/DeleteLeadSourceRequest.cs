using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LeadSources;
public class DeleteLeadSourceRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteLeadSourceRequest(Guid id) => Id = id;
}

public class DeleteLeadSourceRequestHandler : IRequestHandler<DeleteLeadSourceRequest, Guid>
{
    private readonly IRepository<LeadSource> _repository;
    private readonly IStringLocalizer<DeleteLeadSourceRequestHandler> _localizer;

    public DeleteLeadSourceRequestHandler(IRepository<LeadSource> repository, IStringLocalizer<DeleteLeadSourceRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteLeadSourceRequest request, CancellationToken cancellationToken)
    {
        var leadSource = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = leadSource ?? throw new NotFoundException(_localizer["LeadSource.notfound"]);

        // Add Domain Events to be raised after the commit
        leadSource.DomainEvents.Add(EntityDeletedEvent.WithEntity(leadSource));

        await _repository.DeleteAsync(leadSource, cancellationToken);

        return request.Id;
    }
}