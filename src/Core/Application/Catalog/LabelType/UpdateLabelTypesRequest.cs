using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class UpdateLabelTypesRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string LabelType { get; set; }
    public string LabelName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }
}

public class UpdateLabelTypesRequestHandler : IRequestHandler<UpdateLabelTypesRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.LabelTypes> _repository;
    private readonly IStringLocalizer _t;
    private readonly IFileStorageService _file;

    public UpdateLabelTypesRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.LabelTypes> repository, IStringLocalizer<UpdateLabelTypesRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateLabelTypesRequest request, CancellationToken cancellationToken)
    {
        var labeltype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = labeltype ?? throw new NotFoundException(_t["LabelTypes {0} Not Found.", request.Id]);

        var updatedlabeltype = labeltype.Update(request.LabelName, request.LabelType, request.Details, request.BPCode);

        // Add Domain Events to be raised after the commit
        labeltype.DomainEvents.Add(EntityUpdatedEvent.WithEntity(labeltype));

        await _repository.UpdateAsync(updatedlabeltype, cancellationToken);

        return request.Id;
    }
}