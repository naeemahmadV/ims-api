using FSH.WebApi.Application.Catalog.Country;

namespace FSH.WebApi.Application;
public class SearchCountryRequest : PaginationFilter, IRequest<PaginationResponse<CountryDto>>
{

}

public class CountryBySearchRequestSpec : EntitiesByPaginationFilterSpec<Country, CountryDto>
{
    public CountryBySearchRequestSpec(SearchCountryRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchCountryRequestHandler : IRequestHandler<SearchCountryRequest, PaginationResponse<CountryDto>>
{
    private readonly IReadRepository<Country> _repository;

    public SearchCountryRequestHandler(IReadRepository<Country> repository) => _repository = repository;

    public async Task<PaginationResponse<CountryDto>> Handle(SearchCountryRequest request, CancellationToken cancellationToken)
    {
        var spec = new CountryBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}