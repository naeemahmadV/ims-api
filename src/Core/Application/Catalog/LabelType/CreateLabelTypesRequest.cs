using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class CreateLabelTypesRequest : IRequest<Guid>
{
    public string LabelType { get; set; }
    public string LabelName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }
}

public class CreateLabelTypesRequestHandler : IRequestHandler<CreateLabelTypesRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.LabelTypes> _repository;
    private readonly IFileStorageService _file;

    public CreateLabelTypesRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.LabelTypes> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<Guid> Handle(CreateLabelTypesRequest request, CancellationToken cancellationToken)
    {

        var labeltype = new FSH.WebApi.Domain.Catalog.LabelTypes(request.LabelType, request.LabelName, request.Details, request.BPCode);

        // Add Domain Events to be raised after the commit
        labeltype.DomainEvents.Add(EntityCreatedEvent.WithEntity(labeltype));

        await _repository.AddAsync(labeltype, cancellationToken);

        return labeltype.Id;
    }
}