namespace FSH.WebApi.Application.Catalog.SalesOrders;
public class SalesOrderByNameSpec : Specification<SalesOrder>, ISingleResultSpecification
{
    public SalesOrderByNameSpec(string customername) =>
     Query.Where(b => b.CustomerName == customername);

}
