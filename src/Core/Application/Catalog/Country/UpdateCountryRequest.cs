using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class UpdateCountryRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string Code { get; set; }
}

public class UpdateCountryRequestHandler : IRequestHandler<UpdateCountryRequest, Guid>
{
    private readonly IRepository<Country> _repository;
    private readonly IStringLocalizer<UpdateCountryRequestHandler> _localizer;
    private readonly IUploadService _file;

    public UpdateCountryRequestHandler(IRepository<Country> repository, IStringLocalizer<UpdateCountryRequestHandler> localizer, IUploadService file) =>
        (_repository, _localizer, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateCountryRequest request, CancellationToken cancellationToken)
    {
        var country = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = country ?? throw new NotFoundException(string.Format(_localizer["Country.notfound"], request.Id));

        var updatedLead = country.Update(request.Name, request.Code);

        // Add Domain Events to be raised after the commit
        country.DomainEvents.Add(EntityUpdatedEvent.WithEntity(country));

        await _repository.UpdateAsync(updatedLead, cancellationToken);

        return request.Id;
    }
}