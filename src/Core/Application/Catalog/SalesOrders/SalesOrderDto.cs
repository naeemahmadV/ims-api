namespace FSH.WebApi.Application.Catalog.SalesOrders;
public class SalesOrderDto : IDto
{
    public Guid Id { get; set; }
    public int? Sales_Order { get; set; }

    public DateTime? DueDate { get; set; }


    public string? CustomerName { get; set; }

    public string? Item { get; set; }
    public int? Quantity { get; set; }
    public int? SPQ { get; set; }
    public string? PackageType { get; set; }
    public bool IsConsolidate { get; set; }
}
