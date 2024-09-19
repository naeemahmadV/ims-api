namespace FSH.WebApi.Application.Catalog.ReportType;
public class GetReportTypeRequest : IRequest<ReportTypeDto>
{
    public Guid Id { get; set; }

    public GetReportTypeRequest(Guid id) => Id = id;
}

public class SalesOderByIdSpec : Specification<FSH.WebApi.Domain.Catalog.ReportTypes, ReportTypeDto>, ISingleResultSpecification
{
    public SalesOderByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetReportTypeRequestHandler : IRequestHandler<GetReportTypeRequest, ReportTypeDto>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.ReportTypes> _repository;
    private readonly IStringLocalizer _t;

    public GetReportTypeRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.ReportTypes> repository, IStringLocalizer<GetReportTypeRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<ReportTypeDto> Handle(GetReportTypeRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<FSH.WebApi.Domain.Catalog.ReportTypes, ReportTypeDto>)new SalesOderByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["ReportType {0} Not Found.", request.Id]);
}
