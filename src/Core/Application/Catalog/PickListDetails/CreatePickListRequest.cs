namespace FSH.WebApi.Application.Catalog.PickListDetails;
public class CreatePickListRequest : IRequest<Guid>
{
    public string? SalesOrder { get; set; }
    public string? DocEntry { get; set; }
    public int SOLineNo { get; set; }
    public string? BatchNo { get; set; }
    public int PickQty { get; set; }
    public int SPQ { get; set; }
    public int CtnQty { get; set; }
    public string? DateCode { get; set; }
    public string? ActualETD { get; set; }
    public string? CustRefNo { get; set; }
    public string? CustPartNum { get; set; }
    public string? ItemCode { get; set; }
    public string? ItemDesc { get; set; }
    public string? IESONum { get; set; }
    public string? IECustRef { get; set; }
    public string? Processed { get; set; }
    public string? CRD { get; set; }
    public string? Packed { get; set; }
    public string? BPCode { get; set; }
    public string? SPQUnit { get; set; }
    public string? PackUOM { get; set; }
    public string? CartonUOM { get; set; }
    public Guid PackageTypeId { get; set; }
    public Guid LabelTypeId { get; set; }
    public Guid StepTypeId { get; set; }
}

public class CreatePickListRequestValidator : CustomValidator<CreatePickListRequest>
{
    public CreatePickListRequestValidator(IReadRepository<PickList> repository, IStringLocalizer<CreatePickListRequestValidator> T) =>
        RuleFor(p => p.CustPartNum)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (custpartnum, ct) => await repository.FirstOrDefaultAsync(new PickListByNameSpec(custpartnum), ct) is null)
                .WithMessage((_, custpartnum) => T["Customer {0} already Exists.", custpartnum]);
}

public class CreatePickListRequestHandler : IRequestHandler<CreatePickListRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<PickList> _repository;

    public CreatePickListRequestHandler(IRepositoryWithEvents<PickList> repository) => _repository = repository;

    public async Task<Guid> Handle(CreatePickListRequest request, CancellationToken cancellationToken)
    {
        var pickList = new PickList(request.SalesOrder, request.DocEntry, request.SOLineNo, request.BatchNo, request.PickQty, request.SPQ, request.CtnQty,
            request.DateCode, request.ActualETD, request.CustRefNo, request.CustPartNum, request.ItemCode, request.ItemDesc, request.IESONum, request.IECustRef, request.Processed, request.CRD, request.Packed, request.BPCode,
            request.SPQUnit, request.PackUOM, request.CartonUOM, request.PackageTypeId, request.LabelTypeId, request.StepTypeId);

        await _repository.AddAsync(pickList, cancellationToken);

        return pickList.Id;
    }
}