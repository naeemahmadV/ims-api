namespace FSH.WebApi.Application.Catalog.Opportunity;
public class PreferredShiftTimingRequestDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
