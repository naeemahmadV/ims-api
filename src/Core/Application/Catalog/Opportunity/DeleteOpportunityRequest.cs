using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Opportunity;
public class DeleteOpportunityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteOpportunityRequest(Guid id)
    {
        Id = id;
    }
}

public class DeleteOpportunityRequestHandler : IRequestHandler<DeleteOpportunityRequest, Guid>
{
    private readonly IRepository<Domain.Catalog.Opportunity> _repository;
    private readonly IStringLocalizer<DeleteOpportunityRequestHandler> _stringLocalizer;

    public DeleteOpportunityRequestHandler(IRepository<Domain.Catalog.Opportunity> repository, IStringLocalizer<DeleteOpportunityRequestHandler> stringLocalizer)
    {
        _repository = repository;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<DefaultIdType> Handle(DeleteOpportunityRequest request, CancellationToken cancellationToken)
    {
        var opportunity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (opportunity == null)
        {
            throw new NotFoundException(string.Format(_stringLocalizer["Opportunity.NotFound"], request.Id));
        }

        opportunity.DomainEvents.Add(EntityDeletedEvent.WithEntity(opportunity));

        await _repository.DeleteAsync(opportunity, cancellationToken);

        return request.Id;
    }
}
