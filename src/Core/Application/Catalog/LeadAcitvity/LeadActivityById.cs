namespace FSH.WebApi.Application.Catalog.LeadAcitvity;
public class LeadActivityById : Specification<LeadActivities, LeadActivityDto>, ISingleResultSpecification
{
    public LeadActivityById(Guid id) => Query.Where(p => p.Id == id);
}
