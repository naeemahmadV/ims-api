
namespace FSH.WebApi.Application.Catalog.LeadSources;
public class LeadSourceDto : IDto
{
    public Guid Id { get; set; }
    public string SourceName { get; set; }
}
