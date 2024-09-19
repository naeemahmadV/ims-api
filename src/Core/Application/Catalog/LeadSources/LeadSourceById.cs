
namespace FSH.WebApi.Application.Catalog.LeadSources;
public class LeadSourceById : Specification<LeadSource, LeadSourceDto>, ISingleResultSpecification
{
    public LeadSourceById(Guid id) =>
    Query.Where(p => p.Id == id);
}
