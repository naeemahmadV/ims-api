namespace FSH.WebApi.Application.Catalog.SalesOrders;
public class CreateSalesOrderRequest : IRequest<Guid>
{
    public int? Sales_Order { get; set; }

    public DateTime? DueDate { get; set; }


    public string? CustomerName { get; set; }

    public string? Item { get; set; }
    public int? Quantity { get; set; }
    public int? SPQ { get; set; }
    public string? PackageType { get; set; }
    public bool IsConsolidate { get; set; }
}

public class CreateSalesOrderRequestValidator : CustomValidator<CreateSalesOrderRequest>
{
    public CreateSalesOrderRequestValidator(IReadRepository<SalesOrder> repository, IStringLocalizer<CreateSalesOrderRequestValidator> T) =>
        RuleFor(p => p.CustomerName)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (customername, ct) => await repository.FirstOrDefaultAsync(new SalesOrderByNameSpec(customername), ct) is null)
                .WithMessage((_, customername) => T["Customer {0} already Exists.", customername]);
}

public class CreateSalesOrderRequestHandler : IRequestHandler<CreateSalesOrderRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<SalesOrder> _repository;

    public CreateSalesOrderRequestHandler(IRepositoryWithEvents<SalesOrder> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateSalesOrderRequest request, CancellationToken cancellationToken)
    {
        var salesorder = new SalesOrder(request.Sales_Order, request.DueDate , request.CustomerName, request.Item, request.Quantity, request.SPQ, request.PackageType, request.IsConsolidate);

        await _repository.AddAsync(salesorder, cancellationToken);

        return salesorder.Id;
    }
}
