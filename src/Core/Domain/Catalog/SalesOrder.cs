using System.Xml.Linq;

namespace FSH.WebApi.Domain.Catalog;
public class SalesOrder : AuditableEntity, IAggregateRoot
{
    public int? Sales_Order { get; set; }

    public DateTime? DueDate { get; set; }

   
    public string? CustomerName { get; set; }

    public string? Item { get; set; }
    public int? Quantity { get; set;}
    public int? SPQ { get; set; }
    public string? PackageType { get; set; }
    public bool IsConsolidate { get; set; }

    public SalesOrder(int? sales_Order, DateTime? dueDate, string? customerName, string? item, int? quantity, int? sPQ, string? packageType, bool isConsolidate)
    {
        Sales_Order = sales_Order;
        DueDate = dueDate;
        CustomerName = customerName;
        Item = item;
        Quantity = quantity;
        SPQ = sPQ;
        PackageType = packageType;
        IsConsolidate = isConsolidate;
    }

    public SalesOrder Update(int? sales_order, DateTime? duedate, string? customername, string? item, int? quantity, int? spq, string? packagetype, bool isconsolidate)
    {
        if (sales_order is not null && Sales_Order?.Equals(sales_order) is not true) Sales_Order = sales_order;
        if (duedate is not null && DueDate?.Equals(duedate) is not true) DueDate = duedate;
        if (customername is not null && CustomerName?.Equals(customername) is not true) CustomerName = customername;
        if (item is not null && Item?.Equals(item) is not true) Item = item;
        if (quantity is not null && Quantity?.Equals(quantity) is not true) Quantity = quantity;
        if (spq is not null && SPQ?.Equals(spq) is not true) SPQ = spq;
        if (packagetype is not null && PackageType?.Equals(packagetype) is not true) PackageType = packagetype;
        if ( IsConsolidate.Equals(isconsolidate) is not true) IsConsolidate = isconsolidate;
        return this;
    }

}
