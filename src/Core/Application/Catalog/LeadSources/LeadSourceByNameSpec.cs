
namespace FSH.WebApi.Application.Catalog.LeadSources;
public class LeadSourceByNameSpec : Specification<LeadSource>, ISingleResultSpecification
{
    public LeadSourceByNameSpec(string sourceName) => Query.Where(p => p.SourceName == sourceName);

}
