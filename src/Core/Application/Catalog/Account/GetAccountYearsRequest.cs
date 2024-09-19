using FSH.WebApi.Application.Catalog.Lead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Account;
public record GetAccountYearsRequest : IRequest<IList<AccountYearDto>>;

public class GetAccountYearsRequestHandler : IRequestHandler<GetAccountYearsRequest, IList<AccountYearDto>>
{
    private readonly IRepository<Domain.Catalog.Account> _repository;
    private readonly IDapperRepository _dapperrepository;
    public GetAccountYearsRequestHandler(IRepository<Domain.Catalog.Account> repository, IDapperRepository dapperrepository)
        => (_repository, _dapperrepository) = (repository, dapperrepository);

    public async Task<IList<AccountYearDto>> Handle(GetAccountYearsRequest request, CancellationToken cancellationToken)
    {
        string query = @"
                    SELECT
                        YEAR([CreatedOn]) AS [Year],
                        COUNT(*) AS [Count]
                    FROM Catalog.Account
                    GROUP BY YEAR([CreatedOn])
                    ORDER BY YEAR([CreatedOn]) DESC;
                    ";

        var accountlist = await _dapperrepository.QueryAsync<AccountYearDto>(query, null, null, cancellationToken);

        return accountlist.ToList();
    }
}
