namespace FSH.WebApi.Application.Catalog.Companies;

public class CompanyById : Specification<Company, CompanyDto>, ISingleResultSpecification
{
    public CompanyById(Guid id) =>
        Query
            .Where(p => p.Id == id);
}