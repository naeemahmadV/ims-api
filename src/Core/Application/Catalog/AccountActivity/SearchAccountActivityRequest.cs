namespace FSH.WebApi.Application.Catalog.AccountActivity;
public class SearchAccountActivityRequest : PaginationFilter, IRequest<PaginationResponse<AccountActivityDto>>
{
    public Guid AccountId { get; set; }
}

public class SearchAccountAcitivityRequestHandler : IRequestHandler<SearchAccountActivityRequest, PaginationResponse<AccountActivityDto>>
{
    private readonly IRepository<AccountActivities> _repository;
    public SearchAccountAcitivityRequestHandler(IRepository<AccountActivities> repository) =>
        _repository = repository;

    public async Task<PaginationResponse<AccountActivityDto>> Handle(SearchAccountActivityRequest request, CancellationToken cancellationToken)
    {
        var spec = new AccountActivityBySearchRequestSpec(request);

        var result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);

        return result;
    }
}

public class SearchAccountAcitivityTaskRequest : PaginationFilter, IRequest<PaginationResponse<AccountActivityTaskDto>>
{
    public Guid assignTo { get; set; }

}

public class SearchAccountAcitivityTaskRequestHandler : IRequestHandler<SearchAccountAcitivityTaskRequest, PaginationResponse<AccountActivityTaskDto>>
{
    private readonly IRepository<AccountActivities> _repository;
    public SearchAccountAcitivityTaskRequestHandler(IRepository<AccountActivities> repository) =>
        _repository = repository;

    public async Task<PaginationResponse<AccountActivityTaskDto>> Handle(SearchAccountAcitivityTaskRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var spec = new AccountActivityByTaskAssignUserRequestSpec(request);

            var result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
}
