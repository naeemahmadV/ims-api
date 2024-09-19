namespace FSH.WebApi.Application.Catalog.Companies;

public class GetCompanyRequest : IRequest<CompanyDto>
{
    public Guid Id { get; set; }

    public GetCompanyRequest(Guid id) => Id = id;
}

public class GetCompanyRequestHandler : IRequestHandler<GetCompanyRequest, CompanyDto>
{
    private readonly IRepository<Company> _repository;
    private readonly IStringLocalizer<GetCompanyRequestHandler> _localizer;

    public GetCompanyRequestHandler(IRepository<Company> repository, IStringLocalizer<GetCompanyRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<CompanyDto> Handle(GetCompanyRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Company, CompanyDto>)new CompanyById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["product.notfound"], request.Id));
}