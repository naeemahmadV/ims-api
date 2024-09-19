using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Companies;

public class UpdateCompanyRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public Guid Id { get; set; }
}

public class UpdateCompanyRequestHandler : IRequestHandler<UpdateCompanyRequest, Guid>
{
    private readonly IRepository<Company> _repository;
    private readonly IStringLocalizer<UpdateCompanyRequestHandler> _localizer;
    private readonly IFileStorageService _file;

    public UpdateCompanyRequestHandler(IRepository<Company> repository, IStringLocalizer<UpdateCompanyRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _localizer, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = company ?? throw new NotFoundException(string.Format(_localizer["company.notfound"], request.Id));

        // Remove old image if flag is set
        var updatedCompany = company.Update(request.Name);

        // Add Domain Events to be raised after the commit
        company.DomainEvents.Add(EntityUpdatedEvent.WithEntity(company));

        await _repository.UpdateAsync(updatedCompany, cancellationToken);

        return request.Id;
    }
}