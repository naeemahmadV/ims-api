
using FSH.WebApi.Application.Catalog.LeadAcitvity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountActivity;
public class GetAccountActivityRequest : IRequest<AccountActivityDto>
{

    public Guid Id { get; set; }
    public GetAccountActivityRequest(Guid id) => Id = id;
}

public class GetAccountActivityRequestHandler : IRequestHandler<GetAccountActivityRequest, AccountActivityDto>
{
    private readonly IRepository<AccountActivities> _repository;
    private readonly IStringLocalizer<UpdateAccountActivityRequestHandler> _localizer;

    public GetAccountActivityRequestHandler(IRepository<AccountActivities> repository, IStringLocalizer<UpdateAccountActivityRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<AccountActivityDto> Handle(GetAccountActivityRequest request, CancellationToken cancellationToken) =>
     await _repository.GetBySpecAsync(
            (ISpecification<AccountActivities, AccountActivityDto>)new AccountActivityById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["LeadActivity.notfound"], request.Id));
}
