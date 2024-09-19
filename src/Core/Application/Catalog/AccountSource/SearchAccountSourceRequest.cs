using FSH.WebApi.Application.Catalog.LeadSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountSource;
public class SearchAccountSourceRequest : PaginationFilter, IRequest<PaginationResponse<AccountSourceDto>>
{
}

public class AccountSourceBySearchRequestSpec : EntitiesByPaginationFilterSpec<Domain.Catalog.AccountSource, AccountSourceDto>
{
    public AccountSourceBySearchRequestSpec(SearchAccountSourceRequest request)
        : base(request) =>
        Query.OrderBy(c => c.SourceName, !request.HasOrderBy());
}

public class SearchAccountSourceRequestHandler : IRequestHandler<SearchAccountSourceRequest, PaginationResponse<AccountSourceDto>>
{
    private readonly IReadRepository<FSH.WebApi.Domain.Catalog.AccountSource> _repository;

    public SearchAccountSourceRequestHandler(IReadRepository<FSH.WebApi.Domain.Catalog.AccountSource> repository) => _repository = repository;

    public async Task<PaginationResponse<AccountSourceDto>> Handle(SearchAccountSourceRequest request, CancellationToken cancellationToken)
    {
        var spec = new AccountSourceBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
