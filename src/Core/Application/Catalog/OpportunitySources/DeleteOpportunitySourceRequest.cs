using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.OpportunitySources;
public class DeleteOpportunitySourceRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteOpportunitySourceRequest(Guid id)
    {
        Id = id;
    }
}

public class DeleteOpportunitySourceRequestHandler : IRequestHandler<DeleteOpportunitySourceRequest, Guid>
{
    private readonly IRepository<OpportunitySource> _repository;
    private readonly IStringLocalizer<GetOpportunitySourceRequestHandler> _stringLocalizer;

    public DeleteOpportunitySourceRequestHandler(IRepository<OpportunitySource> repository, IStringLocalizer<GetOpportunitySourceRequestHandler> stringLocalizer)
    {
        _repository = repository;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<DefaultIdType> Handle(DeleteOpportunitySourceRequest request, CancellationToken cancellationToken)
    {
        var opportunitySource = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (opportunitySource == null)
        {
            throw new NotFoundException(string.Format(_stringLocalizer["OpportunitySource.NotFound"], request.Id));
        }

        opportunitySource.DomainEvents.Add(EntityDeletedEvent.WithEntity(opportunitySource));

        await _repository.DeleteAsync(opportunitySource, cancellationToken);

        return request.Id;
    }
}

