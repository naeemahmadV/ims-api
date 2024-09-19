using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LeadSources;
public class CreateLeadSourceRequest : IRequest<Guid>
{
    public string SourceName { get; set; }
}

public class CreateLeadSourceRequestHandler : IRequestHandler<CreateLeadSourceRequest, Guid>
{
    private readonly IRepository<Domain.Catalog.LeadSource> _repository;
    private readonly IUploadService _file;

    public CreateLeadSourceRequestHandler(IRepository<Domain.Catalog.LeadSource> repository, IUploadService file) =>
        (_repository, _file) = (repository, file);

    public async Task<Guid> Handle(CreateLeadSourceRequest request, CancellationToken cancellationToken)
    {
        var leadSource = new LeadSource(request.SourceName);
        //Add Domain Events to be raised after the commit
        leadSource.DomainEvents.Add(EntityCreatedEvent.WithEntity(leadSource));
        await _repository.AddAsync(leadSource, cancellationToken);
        return leadSource.Id;
    }
}