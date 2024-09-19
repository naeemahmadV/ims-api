using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Account;
public class GetAccountRequest : IRequest<AccountDto>
{
    public Guid Id { get; set; }

    public GetAccountRequest(Guid id) => Id = id;
}

public class GetAccountRequestHandler : IRequestHandler<GetAccountRequest, AccountDto>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.Account> _repository;
    private readonly IStringLocalizer<GetAccountRequestHandler> _localizer;

    public GetAccountRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.Account> repository, IStringLocalizer<GetAccountRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<AccountDto> Handle(GetAccountRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<FSH.WebApi.Domain.Catalog.Account, AccountDto>)new AccountById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["State.notfound"], request.Id));
}
