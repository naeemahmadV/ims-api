namespace FSH.WebApi.Application.Catalog.OpportunityActivity;
public class SearchOpportunityAcitivityRequest : PaginationFilter, IRequest<PaginationResponse<OpportunityActivityDto>>
{
    public Guid OpportunityId { get; set; }
}

public class SearchOpportunityAcitivityRequestHandler : IRequestHandler<SearchOpportunityAcitivityRequest, PaginationResponse<OpportunityActivityDto>>
{
    private readonly IRepository<OpportunityActivities> _repository;
    public SearchOpportunityAcitivityRequestHandler(IRepository<OpportunityActivities> repository) =>
        _repository = repository;

    public async Task<PaginationResponse<OpportunityActivityDto>> Handle(SearchOpportunityAcitivityRequest request, CancellationToken cancellationToken)
    {
        var spec = new OpportunityActivityBySearchRequestSpec(request);

        var result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);

        return result;
    }
}

public class SearchOpportunityAcitivityTaskRequest : PaginationFilter, IRequest<PaginationResponse<OpportunityActivityTaskDto>>
{
    public Guid assignTo { get; set; }

}

public class SearchOpportunityAcitivityTaskRequestHandler : IRequestHandler<SearchOpportunityAcitivityTaskRequest, PaginationResponse<OpportunityActivityTaskDto>>
{
    private readonly IRepository<OpportunityActivities> _repository;
    public SearchOpportunityAcitivityTaskRequestHandler(IRepository<OpportunityActivities> repository) =>
        _repository = repository;

    public async Task<PaginationResponse<OpportunityActivityTaskDto>> Handle(SearchOpportunityAcitivityTaskRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var spec = new OpportunityActivityByTaskAssignUserRequestSpec(request);

            var result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
}