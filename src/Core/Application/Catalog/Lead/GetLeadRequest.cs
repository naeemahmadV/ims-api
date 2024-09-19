namespace FSH.WebApi.Application;
public class GetLeadRequest : IRequest<LeadDto>
{
    public Guid Id { get; set; }

    public GetLeadRequest(Guid id) => Id = id;
}

public class GetLeadRequestHandler : IRequestHandler<GetLeadRequest, LeadDto>
{
    private readonly IRepository<Lead> _repository;
    private readonly IStringLocalizer<GetLeadRequestHandler> _localizer;

    public GetLeadRequestHandler(IRepository<Lead> repository, IStringLocalizer<GetLeadRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<LeadDto> Handle(GetLeadRequest request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetBySpecAsync(
             (ISpecification<Lead, LeadDto>)new LeadById(request.Id), cancellationToken)
         ?? throw new NotFoundException(string.Format(_localizer["State.notfound"], request.Id));

        return result;
    }
}