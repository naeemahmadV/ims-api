using FSH.WebApi.Application.Catalog.SalesOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.PickListDetails;
public class SearchPickListRequest : PaginationFilter, IRequest<PaginationResponse<PickListDto>>
{

}

public class PickListBySearchRequestSpec : EntitiesByPaginationFilterSpec<PickList, PickListDto>
{
    public PickListBySearchRequestSpec(SearchPickListRequest request)
        : base(request) =>
        Query.OrderBy(c => c.SalesOrder, !request.HasOrderBy());
}

public class SearchPickListRequestHandler : IRequestHandler<SearchPickListRequest, PaginationResponse<PickListDto>>
{
    private readonly IReadRepository<PickList> _repository;

    public SearchPickListRequestHandler(IReadRepository<PickList> repository) => _repository = repository;

    public async Task<PaginationResponse<PickListDto>> Handle(SearchPickListRequest request, CancellationToken cancellationToken)
    {
        var spec = new PickListBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
