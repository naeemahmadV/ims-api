using FSH.WebApi.Application.Catalog.Products;
using FSH.WebApi.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.PickListDetails;
public class DeletePickListRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeletePickListRequest(Guid id) => Id = id;
}

public class DeletePickListRequestHandler : IRequestHandler<DeletePickListRequest, Guid>
{
    private readonly IRepository<PickList> _repository;
    private readonly IStringLocalizer _t;

    public DeletePickListRequestHandler(IRepository<PickList> repository, IStringLocalizer<DeletePickListRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeletePickListRequest request, CancellationToken cancellationToken)
    {
        var pickList = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = pickList ?? throw new NotFoundException(_t["Pick List {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        pickList.DomainEvents.Add(EntityDeletedEvent.WithEntity(pickList));

        await _repository.DeleteAsync(pickList, cancellationToken);

        return request.Id;
    }
}