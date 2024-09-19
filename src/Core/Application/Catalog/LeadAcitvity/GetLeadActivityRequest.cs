namespace FSH.WebApi.Application.Catalog.LeadAcitvity;
public class GetLeadActivityRequest : IRequest<LeadActivityDto>
{
    public Guid Id { get; set; }
    public GetLeadActivityRequest(Guid id) => Id = id;
}

public class GetLeadActivityRequestHandler : IRequestHandler<GetLeadActivityRequest, LeadActivityDto>
{
    private readonly IRepository<LeadActivities> _repository;
    private readonly IStringLocalizer<UpdateLeadActivityRequestHandler> _localizer;

    public GetLeadActivityRequestHandler(IRepository<LeadActivities> repository, IStringLocalizer<UpdateLeadActivityRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<LeadActivityDto> Handle(GetLeadActivityRequest request, CancellationToken cancellationToken) =>
     await _repository.GetBySpecAsync(
            (ISpecification<LeadActivities, LeadActivityDto>)new LeadActivityById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["LeadActivity.notfound"], request.Id));
}
