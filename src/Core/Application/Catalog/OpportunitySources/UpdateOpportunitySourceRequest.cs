using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.OpportunitySources;
public class UpdateOpportunitySourceRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string SourceName { get; set; }
}

public class UpdateOpportunitySourceRequestHandler : IRequestHandler<UpdateOpportunitySourceRequest, Guid>
{
    private readonly IRepository<OpportunitySource> _repository;
    private readonly IStringLocalizer<UpdateOpportunitySourceRequestHandler> _stringLocalizer;

    public UpdateOpportunitySourceRequestHandler(IRepository<OpportunitySource> repository, IStringLocalizer<UpdateOpportunitySourceRequestHandler> stringLocalizer)
    {
        _repository = repository;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<DefaultIdType> Handle(UpdateOpportunitySourceRequest request, CancellationToken cancellationToken)
    {
        var opportunitySource = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if(opportunitySource == null)
        {
            throw new NotFoundException(string.Format(_stringLocalizer["OpportunitySource.NotFound"], request.Id));
        }

        var updatedOpportunitySource = opportunitySource.Update(request.SourceName);

        updatedOpportunitySource.DomainEvents.Add(EntityUpdatedEvent.WithEntity(updatedOpportunitySource));

        await _repository.UpdateAsync(updatedOpportunitySource, cancellationToken);

        return request.Id;
    }
}
