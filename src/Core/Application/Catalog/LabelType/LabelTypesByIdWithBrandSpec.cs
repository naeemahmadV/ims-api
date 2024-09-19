namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class LabelTypesByIdWithBrandSpec : Specification<FSH.WebApi.Domain.Catalog.LabelTypes, LabelTypesDetailsDto>, ISingleResultSpecification
{
    public LabelTypesByIdWithBrandSpec(Guid id) =>
        Query
            .Where(p => p.Id == id);

}