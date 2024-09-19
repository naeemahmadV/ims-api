namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class GetLabelTypesRequest : IRequest<LabelTypesDetailsDto>
{
    public Guid Id { get; set; }

    public GetLabelTypesRequest(Guid id) => Id = id;
}
public class LabelTypesByIdSpec : Specification<FSH.WebApi.Domain.Catalog.LabelTypes, LabelTypesDetailsDto>, ISingleResultSpecification
{
    public LabelTypesByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetLabelTypesRequestHandler : IRequestHandler<GetLabelTypesRequest, LabelTypesDetailsDto>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.LabelTypes> _repository;
    private readonly IStringLocalizer _t;

    public GetLabelTypesRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.LabelTypes> repository, IStringLocalizer<GetLabelTypesRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<LabelTypesDetailsDto> Handle(GetLabelTypesRequest request, CancellationToken cancellationToken) =>
    await _repository.FirstOrDefaultAsync(
        (ISpecification<FSH.WebApi.Domain.Catalog.LabelTypes, LabelTypesDetailsDto>)new LabelTypesByIdSpec(request.Id), cancellationToken)
    ?? throw new NotFoundException(_t["LabelType {0} Not Found.", request.Id]);
}