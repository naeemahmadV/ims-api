namespace FSH.WebApi.Application.Catalog.StepType;
public class GetStepTypeRequest : IRequest<StepTypeDto>
{
    public Guid Id { get; set; }

    public GetStepTypeRequest(Guid id) => Id = id;
}

public class SalesOderByIdSpec : Specification<FSH.WebApi.Domain.Catalog.StepTypes, StepTypeDto>, ISingleResultSpecification
{
    public SalesOderByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetStepTypeRequestHandler : IRequestHandler<GetStepTypeRequest, StepTypeDto>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.StepTypes> _repository;
    private readonly IStringLocalizer _t;

    public GetStepTypeRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.StepTypes> repository, IStringLocalizer<GetStepTypeRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<StepTypeDto> Handle(GetStepTypeRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<FSH.WebApi.Domain.Catalog.StepTypes, StepTypeDto>)new SalesOderByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["StepType {0} Not Found.", request.Id]);
}
