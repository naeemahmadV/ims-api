using FSH.WebApi.Application.Identity.Users;

namespace FSH.WebApi.Application;
public class SearchLeadRequest : PaginationFilter, IRequest<PaginationResponse<LeadDto>>
{
    public int? Year { get; set; }
    public int? Month { get; set; }
    public int? Day { get; set; }
    public bool CreatedOnOrder { get; set; }
    public bool? MarkAsQualified { get; set; }
    public Guid? UserId { get; set; }
    public string? UserRole { get; set; }
    //public Guid? CountryId { get; set; }

    //public Guid? StateId { get; set; }

    //public Guid? CityId { get; set; }

    //public Guid? LeadSourceId { get; set; }
}

public class SearchLeadRequestHandler : IRequestHandler<SearchLeadRequest, PaginationResponse<LeadDto>>
{
    private readonly IReadRepository<Lead> _repository;
    private readonly IUserService _userService;

    public SearchLeadRequestHandler(IReadRepository<Lead> repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }
    public async Task<PaginationResponse<LeadDto>> Handle(SearchLeadRequest request, CancellationToken cancellationToken)
    {
        string user = request.UserId.ToString();
        var UserRole =await _userService.GetUserRole(user, cancellationToken);
        PaginationResponse<LeadDto> result;
        if (UserRole.ToString() == "Admin")
        {
           var spec = new LeadsBySearchRequestSpec(request);
            result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);

        }
        else if(UserRole.ToString() == "Technical coordinator")
        {
            var spec = new LeadsBySearchTechnialCoordinatorRequestSpec(request);
            result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
        }

        else 
        {
            var spec = new LeadsBySearchSalesCoordinatorRequestSpec(request);
            result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
        }

        return result;
    }
}