namespace FSH.WebApi.Application.Catalog.OpportunitySources;
public class OpportunitySourceById : Specification<OpportunitySource, OpportunitySourceDto>, ISingleResultSpecification
{
    public OpportunitySourceById(Guid id)
    {
        Query.Where(x => x.Id == id);
    }
}
