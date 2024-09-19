using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Companies;

public class CreateCompanyRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;

}

public class CreateCompanyRequestHandler : IRequestHandler<CreateCompanyRequest, Guid>
{
    private readonly IRepository<Company> _repository;
    private readonly IFileStorageService _file;

    public CreateCompanyRequestHandler(IRepository<Company> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<Guid> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = new FSH.WebApi.Domain.Catalog.Company(request.Name);

        // Add Domain Events to be raised after the commit
        company.DomainEvents.Add(EntityCreatedEvent.WithEntity(company));

        await _repository.AddAsync(company, cancellationToken);

        return company.Id;
    }
}