namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class LabelTypesExportDto : IDto
{
    public Guid Id { get; set; }
    public string LabelType { get; set; }
    public string LabelName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }
}