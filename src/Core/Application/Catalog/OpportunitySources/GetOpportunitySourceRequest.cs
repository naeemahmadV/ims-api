namespace FSH.WebApi.Application.Catalog.OpportunitySources;
public class GetOpportunitySourceRequest : IRequest<OpportunitySourceDto>
{
    public Guid Id { get; set; }

    public GetOpportunitySourceRequest(Guid id)
    {
        Id = id;
    }
}

public class GetOpportunitySourceRequestHandler : IRequestHandler<GetOpportunitySourceRequest, OpportunitySourceDto>
{
    private readonly IRepository<OpportunitySource> _repository;
    private readonly IStringLocalizer<GetOpportunitySourceRequestHandler> _stringLocalizer;

    public GetOpportunitySourceRequestHandler(IRepository<OpportunitySource> repository, IStringLocalizer<GetOpportunitySourceRequestHandler> stringLocalizer)
    {
        _repository = repository;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<OpportunitySourceDto> Handle(GetOpportunitySourceRequest request, CancellationToken cancellationToken)
    {
        return await _repository.GetBySpecAsync((ISpecification<OpportunitySource, OpportunitySourceDto>) new OpportunitySourceById(request.Id), cancellationToken)
            ?? throw new NotFoundException(string.Format(_stringLocalizer["OpportunitySource.NotFound"], request.Id));
    }
}
