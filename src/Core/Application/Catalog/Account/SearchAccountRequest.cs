using FSH.WebApi.Application.Catalog.Account;
using FSH.WebApi.Application.Identity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application;
public class SearchAccountRequest : PaginationFilter, IRequest<PaginationResponse<AccountDto>>
{
    public int? Year { get; set; }
    public int? Month { get; set; }
    public int? Day { get; set; }
    public bool CreatedOnOrder { get; set; }
    public Guid? UserId { get; set; }
    public string? UserRole { get; set; }
}

public class SearchAccountRequestHandler : IRequestHandler<SearchAccountRequest, PaginationResponse<AccountDto>>
{
    private readonly IReadRepository<Account> _repository;
    private readonly IUserService _userService;
    //private readonly UserManager<ApplicationUser> _userManager;

    public SearchAccountRequestHandler(IReadRepository<Account> repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }

    public async Task<PaginationResponse<AccountDto>> Handle(SearchAccountRequest request, CancellationToken cancellationToken)
    {
        string user = request.UserId.ToString();
        var UserRole = await _userService.GetUserRole(user, cancellationToken);
        PaginationResponse<AccountDto> result;
        if (UserRole.ToString() == "Admin")
        {
            var spec = new AccountBySearchRequestSpec(request);
            result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);

        }
        else if (UserRole.ToString() == "Technical coordinator")
        {
            var spec = new AccountBySearchTechnialCoordinatorRequestSpec(request);
            result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
        }

        else
        {
            var spec = new AccountBySearchSalesCoordinatorRequestSpec(request);
            result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
        }

        return result;
    }
}
