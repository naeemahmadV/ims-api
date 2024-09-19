namespace FSH.WebApi.Application.Catalog.OpportunitySources;
public class OpportunitySourceDto : IDto
{
    public Guid Id { get; set; }
    public string SourceName { get; set; }
}
