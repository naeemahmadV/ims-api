
namespace FSH.WebApi.Application;
public class LeadById : Specification<Lead, LeadDto>, ISingleResultSpecification
{
    public LeadById(Guid id) => Query.Where(p => p.Id == id);
}
