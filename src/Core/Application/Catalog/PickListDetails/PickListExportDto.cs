namespace FSH.WebApi.Application.Catalog.PickListDetails;
public class PickListExportDto : IDto
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
