using FSH.WebApi.Application.Identity.Users;

namespace FSH.WebApi.Application.Catalog.Opportunity;
public class SearchOpportunityRequest : PaginationFilter, IRequest<PaginationResponse<OpportunityDto>>
{
    public int? Year { get; set; }
    public int? Month { get; set; }
    public int? Day { get; set; }
    public bool CreatedOnOrder { get; set; }
    public bool? OpportunityWon { get; set; }
    public Guid? UserId { get; set; }
    public string? UserRole { get; set; }
}

public class SearchOpportunityRequestHandler : IRequestHandler<SearchOpportunityRequest, PaginationResponse<OpportunityDto>>
{
    private readonly IReadRepository<Domain.Catalog.Opportunity> _repository;
    private readonly IUserService _userService;

    public SearchOpportunityRequestHandler(IReadRepository<Domain.Catalog.Opportunity> repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }

    public async Task<PaginationResponse<OpportunityDto>> Handle(SearchOpportunityRequest request, CancellationToken cancellationToken)
    {
        string user = request.UserId.ToString();
        var UserRole = await _userService.GetUserRole(user, cancellationToken);

        PaginationResponse<OpportunityDto> result;

        if (UserRole.ToString() == "Admin")
        {
            var spec = new OpportunitiesBySearchRequestSpec(request);
            result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);

        }
        else if (UserRole.ToString() == "Technical coordinator")
        {
            var spec = new OpportunitiesBySearchTechnialCoordinatorRequestSpec(request);
            result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
        }

        else
        {
            var spec = new OpportunitiesBySearchSalesCoordinatorRequestSpec(request);
            result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
        }

        return result;

        throw new NotImplementedException();
    }
}
