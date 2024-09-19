using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.ReportType;

public class DeleteReportTypeRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteReportTypeRequest(Guid id) => Id = id;
}

public class DeleteReportTypeRequestHandler : IRequestHandler<DeleteReportTypeRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.ReportTypes> _repository;
    private readonly IStringLocalizer _t;

    public DeleteReportTypeRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.ReportTypes> repository, IStringLocalizer<DeleteReportTypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeleteReportTypeRequest request, CancellationToken cancellationToken)
    {
        var reportType = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = reportType ?? throw new NotFoundException(_t["ReportType {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        reportType.DomainEvents.Add(EntityDeletedEvent.WithEntity(reportType));

        await _repository.DeleteAsync(reportType, cancellationToken);

        return request.Id;
    }
}