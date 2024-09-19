using FSH.WebApi.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application;
public class DeleteAccountRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteAccountRequest(Guid id) => Id = id;
}

public class DeleteAccountRequestHandler : IRequestHandler<DeleteAccountRequest, Guid>
{
    private readonly IRepository<Account> _repository;
    private readonly IStringLocalizer<DeleteAccountRequestHandler> _localizer;

    public DeleteAccountRequestHandler(IRepository<Account> repository, IStringLocalizer<DeleteAccountRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = account ?? throw new NotFoundException(_localizer["Account.notfound"]);

        // Add Domain Events to be raised after the commit
        account.DomainEvents.Add(EntityDeletedEvent.WithEntity(account));

        await _repository.DeleteAsync(account, cancellationToken);

        return request.Id;
    }
}

