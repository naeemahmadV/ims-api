using FSH.WebApi.Application.Catalog.LeadSources;
using FSH.WebApi.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountSource;
public class CreateAccountSourceRequest : IRequest<Guid>
{
    public string SourceName { get; set; }
}
public class CreateAccountSourceRequestHandler : IRequestHandler<CreateAccountSourceRequest, Guid>
{
    private readonly IRepository<Domain.Catalog.AccountSource> _repository;
    private readonly IUploadService _file;

    public CreateAccountSourceRequestHandler(IRepository<Domain.Catalog.AccountSource> repository, IUploadService file) =>
        (_repository, _file) = (repository, file);

    public async Task<Guid> Handle(CreateAccountSourceRequest request, CancellationToken cancellationToken)
    {
        var accountSource = new Domain.Catalog.AccountSource(request.SourceName);
        //Add Domain Events to be raised after the commit
        accountSource.DomainEvents.Add(EntityCreatedEvent.WithEntity(accountSource));
        await _repository.AddAsync(accountSource, cancellationToken);
        return accountSource.Id;
    }
}