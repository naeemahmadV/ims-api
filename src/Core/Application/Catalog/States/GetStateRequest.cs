using FSH.WebApi.Application.Catalog.State;

namespace FSH.WebApi.Application;
public class GetStateRequest : IRequest<StateDto>
{
    public Guid Id { get; set; }

    public GetStateRequest(Guid id) => Id = id;
}

public class GetStateRequestHandler : IRequestHandler<GetStateRequest, StateDto>
{
    private readonly IRepository<State> _repository;
    private readonly IStringLocalizer<GetStateRequestHandler> _localizer;

    public GetStateRequestHandler(IRepository<State> repository, IStringLocalizer<GetStateRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<StateDto> Handle(GetStateRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<State, StateDto>)new StateById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["State.notfound"], request.Id));
}