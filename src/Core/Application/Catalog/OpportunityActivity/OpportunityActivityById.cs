namespace FSH.WebApi.Application.Catalog.OpportunityActivity;
public class OpportunityActivityById : Specification<OpportunityActivities, OpportunityActivityDto>, ISingleResultSpecification
{
    public OpportunityActivityById(Guid id) => Query.Where(p => p.Id == id);
}
