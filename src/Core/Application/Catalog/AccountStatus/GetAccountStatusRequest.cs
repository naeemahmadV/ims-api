using FSH.WebApi.Application.Catalog.LeadStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountStatus;
public class GetAccountStatusRequest : IRequest<List<AccountStatusDto>>
{
}

public class GetAccountStatusRequestHandler : IRequestHandler<GetAccountStatusRequest, List<AccountStatusDto>>
{
    public Task<List<AccountStatusDto>> Handle(GetAccountStatusRequest request, CancellationToken cancellationToken)
    {
        var accountStatusDtos = Enum.GetValues(typeof(Domain.Common.AccountStatus))
                .Cast<Domain.Common.AccountStatus>()
                .Select(status => new AccountStatusDto
                {
                    Id = (int)status,
                    Name = status.GetDescription()
                })
                .ToList();

        return Task.FromResult(accountStatusDtos);

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
