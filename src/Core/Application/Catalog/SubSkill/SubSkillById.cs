using FSH.WebApi.Application.Catalog.SubSkill;

namespace FSH.WebApi.Application;
public class SubSkillById : Specification<SubSkill, SubSkillDto>, ISingleResultSpecification
{
    public SubSkillById(Guid id) => Query.Where(p => p.Id == id);
}
