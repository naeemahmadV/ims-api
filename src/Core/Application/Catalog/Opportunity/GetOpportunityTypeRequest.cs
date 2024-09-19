using System.ComponentModel;

namespace FSH.WebApi.Application.Catalog.Opportunity;
public class GetOpportunityTypeRequest : IRequest<List<OpportunityTypeDto>>
{

}

public class GetOpportunityTypeRequestHandler : IRequestHandler<GetOpportunityTypeRequest, List<OpportunityTypeDto>>
{
    public Task<List<OpportunityTypeDto>> Handle(GetOpportunityTypeRequest request, CancellationToken cancellationToken)
    {
        var opportunityType = Enum.GetValues(typeof(Domain.Common.OpportunityType))
                                  .Cast<Domain.Common.OpportunityType>()
                                  .Select(type => new OpportunityTypeDto
                                  {
                                      Id = (int)type,
                                      Name = type.GetDescription()
                                  })
                                  .ToList();

        return Task.FromResult(opportunityType);
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