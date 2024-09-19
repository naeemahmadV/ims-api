namespace FSH.WebApi.Application.Catalog.ReportType;
public class ReportTypeDto : IDto
{
    public Guid Id { get; set; }
    public string ReportType { get; set; }
    public string ReportName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }
}
