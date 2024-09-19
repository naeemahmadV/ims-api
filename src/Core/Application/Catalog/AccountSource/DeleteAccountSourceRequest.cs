using FSH.WebApi.Application.Catalog.AccountSource;
using FSH.WebApi.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountSource;
public class DeleteAccountSourceRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteAccountSourceRequest(Guid id) => Id = id;

}

public class DeleteAccountSourceRequestHandler : IRequestHandler<DeleteAccountSourceRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.AccountSource> _repository;
    private readonly IStringLocalizer<DeleteAccountSourceRequestHandler> _localizer;

    public DeleteAccountSourceRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.AccountSource> repository, IStringLocalizer<DeleteAccountSourceRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteAccountSourceRequest request, CancellationToken cancellationToken)
    {
        var accountSource = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = accountSource ?? throw new NotFoundException(_localizer["AccountSource.notfound"]);

        // Add Domain Events to be raised after the commit
        accountSource.DomainEvents.Add(EntityDeletedEvent.WithEntity(accountSource));

        await _repository.DeleteAsync(accountSource, cancellationToken);

        return request.Id;
    }
}
