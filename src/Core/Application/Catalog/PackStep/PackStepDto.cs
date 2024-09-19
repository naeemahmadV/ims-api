namespace FSH.WebApi.Application.Catalog.PackStep;
public class PackStepDto : IDto
{
    public Guid Id { get; set; }
    public int StepNo { get; set; }
    public string StepType { get; set; }
    public string LabelType { get; set; }
    public string ReportType { get; set; }
    public string PackageType { get; set; }
    public string BPCode { get; set; }
    public string Pallet { get; set; }
    public string Detail { get; set; }
}
