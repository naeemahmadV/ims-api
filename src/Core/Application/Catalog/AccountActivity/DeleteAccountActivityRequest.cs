
using FSH.WebApi.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountActivity;
public class DeleteAccountActivityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteAccountActivityRequest(Guid id) => Id = id;
}

public class DeleteAccountActivityRequestHandler : IRequestHandler<DeleteAccountActivityRequest, Guid>
{
    private readonly IRepository<AccountActivities> _repository;
    private readonly IStringLocalizer<UpdateAccountActivityRequestHandler> _localizer;
    public DeleteAccountActivityRequestHandler(IRepository<AccountActivities> repository, IStringLocalizer<UpdateAccountActivityRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteAccountActivityRequest request, CancellationToken cancellationToken)
    {
        var accountActivity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = accountActivity ?? throw new NotFoundException(_localizer["AccountActivity.notfound"]);

        // Add Domain Events to be raised after the commit
        accountActivity.DomainEvents.Add(EntityDeletedEvent.WithEntity(accountActivity));

        await _repository.DeleteAsync(accountActivity, cancellationToken);

        return request.Id;
    }
}
