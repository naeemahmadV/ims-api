namespace FSH.WebApi.Application.Catalog.Companies;

public class SearchCompanyRequest : PaginationFilter, IRequest<PaginationResponse<CompanyDto>>
{
}

public class CompanyBySearchRequestSpec : EntitiesByPaginationFilterSpec<Company, CompanyDto>
{
    public CompanyBySearchRequestSpec(SearchCompanyRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchCompanyRequestHandler : IRequestHandler<SearchCompanyRequest, PaginationResponse<CompanyDto>>
{
    private readonly IReadRepository<Company> _repository;

    public SearchCompanyRequestHandler(IReadRepository<Company> repository) => _repository = repository;

    public async Task<PaginationResponse<CompanyDto>> Handle(SearchCompanyRequest request, CancellationToken cancellationToken)
    {
        var spec = new CompanyBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}