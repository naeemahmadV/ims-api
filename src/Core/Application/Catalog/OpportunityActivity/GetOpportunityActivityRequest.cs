namespace FSH.WebApi.Application.Catalog.OpportunityActivity;
public class GetOpportunityActivityRequest : IRequest<OpportunityActivityDto>
{
    public Guid Id { get; set; }
    public GetOpportunityActivityRequest(Guid id) => Id = id;
}

public class GetOpportunityActivityRequestHandler : IRequestHandler<GetOpportunityActivityRequest, OpportunityActivityDto>
{
    private readonly IRepository<OpportunityActivities> _repository;
    private readonly IStringLocalizer<GetOpportunityActivityRequestHandler> _localizer;

    public GetOpportunityActivityRequestHandler(IRepository<OpportunityActivities> repository, IStringLocalizer<GetOpportunityActivityRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<OpportunityActivityDto> Handle(GetOpportunityActivityRequest request, CancellationToken cancellationToken) =>
     await _repository.GetBySpecAsync(
            (ISpecification<OpportunityActivities, OpportunityActivityDto>)new OpportunityActivityById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["OpportunityActivity.notfound"], request.Id));
}