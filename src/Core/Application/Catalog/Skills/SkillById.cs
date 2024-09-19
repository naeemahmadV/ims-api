namespace FSH.WebApi.Application.Catalog.Skills;
public class SkillById : Specification<Domain.Catalog.Skill, SkillDto>, ISingleResultSpecification
{
    public SkillById(Guid id) => Query.Where(p => p.Id == id);
}
