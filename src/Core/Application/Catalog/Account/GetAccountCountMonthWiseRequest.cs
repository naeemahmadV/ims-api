using FSH.WebApi.Application.Catalog.Lead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Account;
public class GetAccountCountMonthWiseRequest : IRequest<IList<AccountMonthDto>>
{
    public int Year { get; set; }
    public GetAccountCountMonthWiseRequest(int year) => Year = year;
}

public class GetAccountCountMonthWiseRequestHandler : IRequestHandler<GetAccountCountMonthWiseRequest, IList<AccountMonthDto>>
{
    private readonly IRepository<Domain.Catalog.Account> _repository;
    private readonly IDapperRepository _dapperrepository;
    public GetAccountCountMonthWiseRequestHandler(IRepository<Domain.Catalog.Account> repository, IDapperRepository dapperrepository)
    {
        _repository = repository;
        _dapperrepository = dapperrepository;
    }

    public async Task<IList<AccountMonthDto>> Handle(GetAccountCountMonthWiseRequest request, CancellationToken cancellationToken)
    {

        string query = @"
                    SELECT
                        MONTH([CreatedOn]) AS [Month],
                        COUNT(*) AS [Count]
                    FROM Catalog.Account
                    WHERE YEAR([CreatedOn])=" + request.Year +
                    @"GROUP BY MONTH([CreatedOn])
                    ORDER BY MONTH([CreatedOn]) ASC;
                    ";

        var result = await _dapperrepository.QueryAsync<AccountMonthDto>(query, null, null, cancellationToken);

        return result.ToList();
    }
}
