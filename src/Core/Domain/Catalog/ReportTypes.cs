namespace FSH.WebApi.Domain.Catalog;
public class ReportTypes : AuditableEntity, IAggregateRoot
{
    public string ReportType { get; set; }
    public string ReportName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }

    public ReportTypes() { }

    public ReportTypes(string reportType, string reportName, string details, string bPCode)
    {
        ReportType = reportType;
        ReportName = reportName;
        Details = details;
        BPCode = bPCode;
    }

    public ReportTypes Update(string reportType, string reportName, string details, string bPCode)
    {
        if (reportType is not null && ReportType?.Equals(reportType) is not true) ReportType = reportType;
        if (reportName is not null && ReportName?.Equals(reportName) is not true) ReportName = reportName;
        if (details is not null && Details?.Equals(details) is not true) Details = details;
        if (bPCode is not null && BPCode?.Equals(bPCode) is not true) BPCode = bPCode;
        return this;
    }
}
