using FSH.WebApi.Application.Catalog.LeadSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountSource;
public class GetAccountSourceRequest : IRequest<AccountSourceDto>
{
    public Guid Id { get; set; }

    public GetAccountSourceRequest(Guid id) => Id = id;
}

public class GetAccountSourceRequestHandler : IRequestHandler<GetAccountSourceRequest, AccountSourceDto>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.AccountSource> _repository;
    private readonly IStringLocalizer<GetAccountSourceRequestHandler> _localizer;

    public GetAccountSourceRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.AccountSource> repository, IStringLocalizer<GetAccountSourceRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<AccountSourceDto> Handle(GetAccountSourceRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<FSH.WebApi.Domain.Catalog.AccountSource, AccountSourceDto>)new LeadSourceById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["AccountSource.notfound"], request.Id));
}
