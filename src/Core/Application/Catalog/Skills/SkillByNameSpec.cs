
namespace FSH.WebApi.Application.Catalog.Skills;
public class SkillByNameSpec : Specification<Domain.Catalog.Skill>, ISingleResultSpecification
{
    public SkillByNameSpec(string name) => Query.Where(p => p.Name == name);
}
