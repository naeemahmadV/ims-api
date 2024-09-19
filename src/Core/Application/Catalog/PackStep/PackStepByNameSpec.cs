namespace FSH.WebApi.Application.Catalog.PackStep;
public class PackStepByNameSpec : Specification<FSH.WebApi.Domain.Catalog.PackStep>, ISingleResultSpecification
{
    public PackStepByNameSpec(string steptype) =>
     Query.Where(b => b.StepType == steptype);

}
