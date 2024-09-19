namespace FSH.WebApi.Application.Catalog.ReportType;
public class ReportTypeByNameSpec : Specification<FSH.WebApi.Domain.Catalog.ReportTypes>, ISingleResultSpecification
{
    public ReportTypeByNameSpec(string reportname) =>
     Query.Where(b => b.ReportName == reportname);

}
