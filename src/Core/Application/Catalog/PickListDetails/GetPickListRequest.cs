using FSH.WebApi.Application.Catalog.SalesOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.PickListDetails;
public class GetPickListRequest : IRequest<PickListDto>
{
    public Guid Id { get; set; }

    public GetPickListRequest(Guid id) => Id = id;
}

public class PickListByIdSpec : Specification<PickList, PickListDto>, ISingleResultSpecification
{
    public PickListByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetPickListRequestHandler : IRequestHandler<GetPickListRequest, PickListDto>
{
    private readonly IRepository<PickList> _repository;
    private readonly IStringLocalizer _t;

    public GetPickListRequestHandler(IRepository<PickList> repository, IStringLocalizer<GetPickListRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<PickListDto> Handle(GetPickListRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<PickList, PickListDto>)new PickListByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["SalesOrder {0} Not Found.", request.Id]);
}
