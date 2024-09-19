
using FSH.WebApi.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountSource;
public class UpdateAccountSourceRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string SourceName { get; set; }
}
public class UpdateAccountSourceRequestHandler : IRequestHandler<UpdateAccountSourceRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.AccountSource> _repository;
    private readonly IStringLocalizer<UpdateAccountSourceRequestHandler> _localizer;
    private readonly IUploadService _file;

    public UpdateAccountSourceRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.AccountSource> repository, IStringLocalizer<UpdateAccountSourceRequestHandler> localizer, IUploadService file) =>
        (_repository, _localizer, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateAccountSourceRequest request, CancellationToken cancellationToken)
    {
        var accountSource = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = accountSource ?? throw new NotFoundException(string.Format(_localizer["AccountSource.notfound"], request.Id));

        var updatedAccount = accountSource.Update(request.SourceName);

        // Add Domain Events to be raised after the commit
        accountSource.DomainEvents.Add(EntityUpdatedEvent.WithEntity(accountSource));

        await _repository.UpdateAsync(updatedAccount, cancellationToken);

        return request.Id;
    }
}