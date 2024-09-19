
namespace FSH.WebApi.Application.Catalog.LeadSources;
public class GetLeadSourceRequest : IRequest<LeadSourceDto>
{
    public Guid Id { get; set; }

    public GetLeadSourceRequest(Guid id) => Id = id;
}

public class GetLeadSourceRequestHandler : IRequestHandler<GetLeadSourceRequest, LeadSourceDto>
{
    private readonly IRepository<LeadSource> _repository;
    private readonly IStringLocalizer<GetLeadSourceRequestHandler> _localizer;

    public GetLeadSourceRequestHandler(IRepository<LeadSource> repository, IStringLocalizer<GetLeadSourceRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<LeadSourceDto> Handle(GetLeadSourceRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<LeadSource, LeadSourceDto>)new LeadSourceById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["LeadSource.notfound"], request.Id));
}
