namespace FSH.WebApi.Application.Catalog.PackageType;
public class PackageTypeByNameSpec : Specification<FSH.WebApi.Domain.Catalog.PackageType>, ISingleResultSpecification
{
    public PackageTypeByNameSpec(string name) =>
     Query.Where(b => b.Name == name);

}
