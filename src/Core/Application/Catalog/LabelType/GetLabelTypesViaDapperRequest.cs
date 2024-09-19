namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class GetLabelTypesViaDapperRequest : IRequest<LabelTypesDto>
{
    public Guid Id { get; set; }

    public GetLabelTypesViaDapperRequest(Guid id) => Id = id;
}

public class GetLabelTypesViaDapperRequestHandler : IRequestHandler<GetLabelTypesViaDapperRequest, LabelTypesDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetLabelTypesViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetLabelTypesViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<LabelTypesDto> Handle(GetLabelTypesViaDapperRequest request, CancellationToken cancellationToken)
    {
        var labeltype = await _repository.QueryFirstOrDefaultAsync<FSH.WebApi.Domain.Catalog.LabelTypes>(
            $"SELECT * FROM Catalog.\"LabelTypes\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = labeltype ?? throw new NotFoundException(_t["LabelTypes {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in ProductDto and the product not having a Brand assigned.
        return new LabelTypesDto
        {
            Id = labeltype.Id,
            LabelType = labeltype.LabelType,
            LabelName = labeltype.LabelName,
            BPCode = labeltype.BPCode,
            Details = labeltype.Details,
        };
    }
}