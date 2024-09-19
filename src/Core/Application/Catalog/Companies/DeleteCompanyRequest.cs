using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Companies;

public class DeleteCompanyRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteCompanyRequest(Guid id) => Id = id;
}

public class DeleteCompanyRequestHandler : IRequestHandler<DeleteCompanyRequest, Guid>
{
    private readonly IRepository<Company> _repository;
    private readonly IStringLocalizer<DeleteCompanyRequestHandler> _localizer;

    public DeleteCompanyRequestHandler(IRepository<Company> repository, IStringLocalizer<DeleteCompanyRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = company ?? throw new NotFoundException(_localizer["company.notfound"]);

        // Add Domain Events to be raised after the commit
        company.DomainEvents.Add(EntityDeletedEvent.WithEntity(company));

        await _repository.DeleteAsync(company, cancellationToken);

        return request.Id;
    }
}