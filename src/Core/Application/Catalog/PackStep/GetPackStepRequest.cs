namespace FSH.WebApi.Application.Catalog.PackStep;
public class GetPackStepRequest : IRequest<PackStepDto>
{
    public Guid Id { get; set; }

    public GetPackStepRequest(Guid id) => Id = id;
}

public class SalesOderByIdSpec : Specification<FSH.WebApi.Domain.Catalog.PackStep, PackStepDto>, ISingleResultSpecification
{
    public SalesOderByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetPackStepRequestHandler : IRequestHandler<GetPackStepRequest, PackStepDto>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.PackStep> _repository;
    private readonly IStringLocalizer _t;

    public GetPackStepRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.PackStep> repository, IStringLocalizer<GetPackStepRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<PackStepDto> Handle(GetPackStepRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<FSH.WebApi.Domain.Catalog.PackStep, PackStepDto>)new SalesOderByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["PackStep {0} Not Found.", request.Id]);
}
