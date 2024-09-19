using FSH.WebApi.Application.Catalog.Lead;
using FSH.WebApi.Application.Catalog.LeadStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Account;
public class GetAccountTypeRequest : IRequest<List<AccountTypeDto>>
{
}

public class GetAccountTypeRequestHandler : IRequestHandler<GetAccountTypeRequest, List<AccountTypeDto>>
{
    public Task<List<AccountTypeDto>> Handle(GetAccountTypeRequest request, CancellationToken cancellationToken)
    {
        var accountType = Enum.GetValues(typeof(Domain.Common.AccountType))
                .Cast<Domain.Common.AccountType>()
                .Select(status => new AccountTypeDto
                {
                    Id = (int)status,
                    Name = status.GetDescription()
                })
                .ToList();

        return Task.FromResult(accountType);

    }
}
