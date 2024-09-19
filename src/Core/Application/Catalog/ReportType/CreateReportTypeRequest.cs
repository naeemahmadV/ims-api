namespace FSH.WebApi.Application.Catalog.ReportType;
public class CreateReportTypeRequest : IRequest<Guid>
{
    public string ReportType { get; set; }
    public string ReportName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }
}

public class CreateReportTypeRequestValidator : CustomValidator<CreateReportTypeRequest>
{
    public CreateReportTypeRequestValidator(IReadRepository<FSH.WebApi.Domain.Catalog.ReportTypes> repository, IStringLocalizer<CreateReportTypeRequestValidator> T) =>
        RuleFor(p => p.ReportName)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (steptype, ct) => await repository.FirstOrDefaultAsync(new ReportTypeByNameSpec(steptype), ct) is null)
                .WithMessage((_, name) => T["ReportType {0} already Exists.", name]);
}

public class CreateReportTypeRequestHandler : IRequestHandler<CreateReportTypeRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<FSH.WebApi.Domain.Catalog.ReportTypes> _repository;

    public CreateReportTypeRequestHandler(IRepositoryWithEvents<FSH.WebApi.Domain.Catalog.ReportTypes> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateReportTypeRequest request, CancellationToken cancellationToken)
    {
        var reportType = new FSH.WebApi.Domain.Catalog.ReportTypes(request.ReportType, request.ReportName, request.Details, request.BPCode);

        await _repository.AddAsync(reportType, cancellationToken);

        return reportType.Id;
    }
}
