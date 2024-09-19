namespace FSH.WebApi.Application.Catalog.PickListDetails;
public class GetPickListViaDapperRequest : IRequest<PickListDto>
{
    public Guid Id { get; set; }

    public GetPickListViaDapperRequest(Guid id) => Id = id;
}

public class GetPickListViaDapperRequestHandler : IRequestHandler<GetPickListViaDapperRequest, PickListDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetPickListViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetPickListViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<PickListDto> Handle(GetPickListViaDapperRequest request, CancellationToken cancellationToken)
    {
        var pickList = await _repository.QueryFirstOrDefaultAsync<PickList>(
            $"SELECT * FROM Catalog.\"PickList\" WHERE \"Id\"  = '{request.Id}'", cancellationToken: cancellationToken);

        _ = pickList ?? throw new NotFoundException(_t["PickList {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in ProductDto and the product not having a Brand assigned.
        return new PickListDto
        {
            Id = pickList.Id,
            SalesOrder = pickList.SalesOrder,
            ActualETD = pickList.ActualETD,
            BatchNo = pickList.BatchNo,
            BPCode = pickList.BPCode,
            CartonUOM = pickList.CartonUOM,
            CRD = pickList.CRD,
            CtnQty = pickList.CtnQty,
            CustPartNum = pickList.CustPartNum,
            CustRefNo = pickList.CustRefNo,
            DateCode = pickList.DateCode,
            DocEntry = pickList.DocEntry,
            IECustRef = pickList.IECustRef,
            IESONum = pickList.IESONum,
            ItemCode = pickList.ItemCode,
            ItemDesc = pickList.ItemDesc,
            Packed = pickList.Packed,
            PackUOM = pickList.PackUOM,
            PickQty = pickList.PickQty,
            Processed = pickList.Processed,
            SOLineNo = pickList.SOLineNo,
            SPQ = pickList.SPQ,
            SPQUnit = pickList.SPQUnit,
            PackageTypeId = pickList.PackageTypeId,
            LabelTypeId = pickList.LabelTypeId,
            StepTypeId = pickList.StepTypeId,
        };
    }
}