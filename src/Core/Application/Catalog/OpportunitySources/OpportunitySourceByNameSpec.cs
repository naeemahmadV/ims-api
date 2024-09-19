namespace FSH.WebApi.Application.Catalog.OpportunitySources;
public class OpportunitySourceByNameSpec : Specification<OpportunitySource>, ISingleResultSpecification
{
    public OpportunitySourceByNameSpec(string name)
    {
        Query.Where(x => x.SourceName == name);
    }
}
