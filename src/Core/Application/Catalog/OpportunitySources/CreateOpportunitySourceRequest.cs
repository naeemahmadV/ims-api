using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.OpportunitySources;
public class CreateOpportunitySourceRequest : IRequest<Guid>
{
    public string SourceName { get; set; }
}

public class CreateOpportunitySourceRequestHandler : IRequestHandler<CreateOpportunitySourceRequest, Guid>
{
    private readonly IRepository<OpportunitySource> _repository;
    private readonly IUploadService _uploadService;

    public CreateOpportunitySourceRequestHandler(IRepository<OpportunitySource> repository, IUploadService uploadService)
    {
        _repository = repository;
        _uploadService = uploadService;
    }

    public async Task<DefaultIdType> Handle(CreateOpportunitySourceRequest request, CancellationToken cancellationToken)
    {
        var opportunitySource = new OpportunitySource(request.SourceName);

        opportunitySource.DomainEvents.Add(EntityCreatedEvent.WithEntity(opportunitySource));

        await _repository.AddAsync(opportunitySource, cancellationToken);

        return opportunitySource.Id;
    }
}
