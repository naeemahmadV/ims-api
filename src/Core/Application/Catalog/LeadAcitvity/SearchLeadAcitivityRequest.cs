using FSH.WebApi.Application.Common.Models;

namespace FSH.WebApi.Application.Catalog.LeadAcitvity;
public class SearchLeadAcitivityRequest : PaginationFilter, IRequest<PaginationResponse<LeadActivityDto>>
{
    public Guid LeadId { get; set; }
}

public class SearchLeadAcitivityRequestHandler : IRequestHandler<SearchLeadAcitivityRequest, PaginationResponse<LeadActivityDto>>
{
    private readonly IRepository<LeadActivities> _repository;
    public SearchLeadAcitivityRequestHandler(IRepository<LeadActivities> repository) =>
        _repository = repository;

    public async Task<PaginationResponse<LeadActivityDto>> Handle(SearchLeadAcitivityRequest request, CancellationToken cancellationToken)
    {
        var spec = new LeadActivityBySearchRequestSpec(request);

        var result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);

        return result;
    }
}


public class SearchLeadAcitivityTaskRequest : PaginationFilter, IRequest<PaginationResponse<LeadActivityTaskDto>>
{
    public Guid assignTo { get; set; }
    
}

public class SearchLeadAcitivityTaskRequestHandler : IRequestHandler<SearchLeadAcitivityTaskRequest, PaginationResponse<LeadActivityTaskDto>>
{
    private readonly IRepository<LeadActivities> _repository;
    public SearchLeadAcitivityTaskRequestHandler(IRepository<LeadActivities> repository) =>
        _repository = repository;

    public async Task<PaginationResponse<LeadActivityTaskDto>> Handle(SearchLeadAcitivityTaskRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var spec = new LeadActivityByTaskAssignUserRequestSpec(request);

            var result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {

            throw ex; 
        }
        
    }
}