using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LeadSources;
public class UpdateLeadSourceRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string SourceName { get; set; }
}

public class UpdateLeadSourceRequestHandler : IRequestHandler<UpdateLeadSourceRequest, Guid>
{
    private readonly IRepository<LeadSource> _repository;
    private readonly IStringLocalizer<UpdateLeadSourceRequestHandler> _localizer;
    private readonly IUploadService _file;

    public UpdateLeadSourceRequestHandler(IRepository<LeadSource> repository, IStringLocalizer<UpdateLeadSourceRequestHandler> localizer, IUploadService file) =>
        (_repository, _localizer, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateLeadSourceRequest request, CancellationToken cancellationToken)
    {
        var leadSource = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = leadSource ?? throw new NotFoundException(string.Format(_localizer["LeadSource.notfound"], request.Id));

        var updatedLead = leadSource.Update(request.SourceName);

        // Add Domain Events to be raised after the commit
        leadSource.DomainEvents.Add(EntityUpdatedEvent.WithEntity(leadSource));

        await _repository.UpdateAsync(updatedLead, cancellationToken);

        return request.Id;
    }
}