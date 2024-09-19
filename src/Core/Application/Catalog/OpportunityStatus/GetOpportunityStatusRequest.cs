using System.ComponentModel;

namespace FSH.WebApi.Application.Catalog.OpportunityStatus;
public class GetOpportunityStatusRequest : IRequest<List<OpportunityStatusDto>>
{

}

public class GetOpportunityStatusRequestHandler : IRequestHandler<GetOpportunityStatusRequest, List<OpportunityStatusDto>>
{
    public Task<List<OpportunityStatusDto>> Handle(GetOpportunityStatusRequest request, CancellationToken cancellationToken)
    {
        var opportunitystatusDtos = Enum.GetValues(typeof(Domain.Common.OpportunityStatus))
                .Cast<Domain.Common.OpportunityStatus>()
                .Select(status => new OpportunityStatusDto
                {
                    Id = (int)status,
                    Name = status.GetDescription()
                })
                .ToList();

        return Task.FromResult(opportunitystatusDtos);
    }
}

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
        return descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
    }
}
