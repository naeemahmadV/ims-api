namespace FSH.WebApi.Domain.Catalog;
public class PackStep : AuditableEntity, IAggregateRoot
{
    public int StepNo { get; set; }
    public string StepType { get; set; }
    public string LabelType { get; set; }
    public string ReportType { get; set; }
    public string PackageType { get; set; }
    public string BPCode { get; set; }
    public string Pallet { get; set; }
    public string Detail { get; set; }

    public PackStep() { }

    public PackStep(int stepno, string steptype, string labeltype, string reporttype, string packagetype, string bpcode, string pallet, string detail)
    {
        StepNo = stepno;
        StepType = steptype;
        LabelType = labeltype;
        ReportType = reporttype;
        PackageType = packagetype;
        BPCode = bpcode;
        Pallet = pallet;
        Detail = detail;
    }
    public PackStep Update(int stepno, string steptype, string labeltype, string reporttype, string packagetype, string bpcode, string pallet, string detail)
    {
        if (stepno > 0 && StepNo.Equals(stepno) is not true) StepNo = stepno;
        if (steptype is not null && StepType?.Equals(steptype) is not true) StepType = steptype;
        if (labeltype is not null && LabelType?.Equals(labeltype) is not true) LabelType = labeltype;
        if (reporttype is not null && ReportType?.Equals(reporttype) is not true) ReportType = reporttype;
        if (packagetype is not null && PackageType?.Equals(packagetype) is not true) PackageType = packagetype;
        if (bpcode is not null && BPCode?.Equals(bpcode) is not true) BPCode = bpcode;
        if (pallet is not null && Pallet?.Equals(pallet) is not true) Pallet = pallet;
        if (detail is not null && Detail?.Equals(detail) is not true) Detail = detail;
        return this;
    }
}
