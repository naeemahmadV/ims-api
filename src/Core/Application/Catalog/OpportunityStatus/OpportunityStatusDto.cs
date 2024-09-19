namespace FSH.WebApi.Application.Catalog.OpportunityStatus;

public class OpportunityStatusDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
