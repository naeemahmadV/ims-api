using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.ReportType;

public class UpdateReportTypeRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string ReportType { get; set; }
    public string ReportName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }
}

public class UpdateReportTypeRequestHandler : IRequestHandler<UpdateReportTypeRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.ReportTypes> _repository;
    private readonly IStringLocalizer _t;
    private readonly IFileStorageService _file;

    public UpdateReportTypeRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.ReportTypes> repository, IStringLocalizer<UpdateReportTypeRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateReportTypeRequest request, CancellationToken cancellationToken)
    {
        var reportType = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = reportType ?? throw new NotFoundException(_t["ReportType {0} Not Found.", request.Id]);

        var updatedreportType = reportType.Update(request.ReportType, request.ReportName, request.Details, request.BPCode);

        // Add Domain Events to be raised after the commit
        reportType.DomainEvents.Add(EntityUpdatedEvent.WithEntity(reportType));

        await _repository.UpdateAsync(updatedreportType, cancellationToken);

        return request.Id;
    }
}