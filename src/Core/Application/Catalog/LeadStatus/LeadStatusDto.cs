namespace FSH.WebApi.Application.Catalog.LeadStatus;
public class LeadStatusDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
