namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class LabelTypesByNameSpec : Specification<FSH.WebApi.Domain.Catalog.LabelTypes>, ISingleResultSpecification
{
    public LabelTypesByNameSpec(string name) =>
        Query.Where(p => p.LabelName == name);
}