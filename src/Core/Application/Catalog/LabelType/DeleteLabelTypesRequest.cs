using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class DeleteLabelTypesRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteLabelTypesRequest(Guid id) => Id = id;
}

public class DeleteLabelTypesRequestHandler : IRequestHandler<DeleteLabelTypesRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.LabelTypes> _repository;
    private readonly IStringLocalizer _t;

    public DeleteLabelTypesRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.LabelTypes> repository, IStringLocalizer<DeleteLabelTypesRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeleteLabelTypesRequest request, CancellationToken cancellationToken)
    {
        var labeltype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = labeltype ?? throw new NotFoundException(_t["Product {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        labeltype.DomainEvents.Add(EntityDeletedEvent.WithEntity(labeltype));

        await _repository.DeleteAsync(labeltype, cancellationToken);

        return request.Id;
    }
}