namespace FSH.WebApi.Application;
public class SubSkillByNameSpec : Specification<SubSkill>, ISingleResultSpecification
{
    public SubSkillByNameSpec(string name) => Query.Where(p => p.SubSkillName == name);
}
