using System.ComponentModel;

namespace FSH.WebApi.Application.Catalog.LeadStatus;
public class GetLeadStatusRequest : IRequest<List<LeadStatusDto>>
{

}

public class GetLeadStatusRequestHandler : IRequestHandler<GetLeadStatusRequest, List<LeadStatusDto>>
{
    public Task<List<LeadStatusDto>> Handle(GetLeadStatusRequest request, CancellationToken cancellationToken)
    {
        var leadStatusDtos = Enum.GetValues(typeof(Domain.Common.LeadStatus))
                .Cast<Domain.Common.LeadStatus>()
                .Select(status => new LeadStatusDto
                {
                    Id = (int)status,
                    Name = status.GetDescription()
                })
                .ToList();

        return Task.FromResult(leadStatusDtos);

    }
}

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
        return descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
    }
}