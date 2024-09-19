namespace FSH.WebApi.Application.Catalog.StepType;
public class StepTypeDto : IDto
{
    public Guid Id { get; set; }
    public string StepType { get; set; }
    public string StepName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }
}
