namespace FSH.WebApi.Application.Catalog.Opportunity;
public class OpportunityById : Specification<Domain.Catalog.Opportunity, OpportunityDto>, ISingleResultSpecification
{
    public OpportunityById(Guid Id) => Query.Where(o => o.Id == Id);
}
