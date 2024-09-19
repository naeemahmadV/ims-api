using FSH.WebApi.Application.Catalog.LeadStatus;

namespace FSH.WebApi.Application.Catalog.Lead;
public class GetLeadTypeRequest : IRequest<List<LeadTypeDto>>
{

}

public class GetLeadTypeRequestHandler : IRequestHandler<GetLeadTypeRequest, List<LeadTypeDto>>
{
    public Task<List<LeadTypeDto>> Handle(GetLeadTypeRequest request, CancellationToken cancellationToken)
    {
        var leadType = Enum.GetValues(typeof(Domain.Common.LeadType))
                .Cast<Domain.Common.LeadType>()
                .Select(status => new LeadTypeDto
                {
                    Id = (int)status,
                    Name = status.GetDescription()
                })
                .ToList();

        return Task.FromResult(leadType);

    }
}
