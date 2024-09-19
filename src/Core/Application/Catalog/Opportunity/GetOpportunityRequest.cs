namespace FSH.WebApi.Application.Catalog.Opportunity;
public class GetOpportunityRequest : IRequest<OpportunityDto>
{
    public Guid Id { get; set; }

    public GetOpportunityRequest(Guid id)
    {
        Id = id;
    }
}

public class GetOpportunityRequestHandler : IRequestHandler<GetOpportunityRequest, OpportunityDto>
{
    private readonly IRepository<Domain.Catalog.Opportunity> _repository;
    private readonly IStringLocalizer<GetOpportunityRequestHandler> _stringLocalizer;

    public GetOpportunityRequestHandler(IRepository<Domain.Catalog.Opportunity> repository, IStringLocalizer<GetOpportunityRequestHandler> stringLocalizer)
    {
        _repository = repository;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<OpportunityDto> Handle(GetOpportunityRequest request, CancellationToken cancellationToken)
    {
        return await _repository.GetBySpecAsync((ISpecification<Domain.Catalog.Opportunity, OpportunityDto>)new OpportunityById(request.Id), cancellationToken)
            ?? throw new NotFoundException(string.Format(_stringLocalizer["Opportunity.NotFound"], request.Id));
    }
}