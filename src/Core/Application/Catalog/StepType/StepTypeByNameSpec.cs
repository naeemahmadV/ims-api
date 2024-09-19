namespace FSH.WebApi.Application.Catalog.StepType;
public class StepTypeByNameSpec : Specification<FSH.WebApi.Domain.Catalog.StepTypes>, ISingleResultSpecification
{
    public StepTypeByNameSpec(string stepname) =>
     Query.Where(b => b.StepName == stepname);

}
