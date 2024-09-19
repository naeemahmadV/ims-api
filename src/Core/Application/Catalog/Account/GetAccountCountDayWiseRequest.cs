using FSH.WebApi.Application.Catalog.Lead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Account;
public class GetAccountCountDayWiseRequest : IRequest<IList<AccountDayDto>>
{
    public int Year { get; set; }
    public int Month { get; set; }
    public GetAccountCountDayWiseRequest(int year, int month) => (Year, Month) = (year, month);
}


public class GetAccountCountDayWiseRequestHandler : IRequestHandler<GetAccountCountDayWiseRequest, IList<AccountDayDto>>
{
    private readonly IRepository<Domain.Catalog.Account> _repository;
    private readonly IDapperRepository _dapperrepository;
    public GetAccountCountDayWiseRequestHandler(IRepository<Domain.Catalog.Account> repository, IDapperRepository dapperrepository)
    {
        _repository = repository;
        _dapperrepository = dapperrepository;
    }

    public async Task<IList<AccountDayDto>> Handle(GetAccountCountDayWiseRequest request, CancellationToken cancellationToken)
    {
        string query = @"
                    SELECT
                        DAY([CreatedOn]) AS [Day],
                        COUNT(*) AS [Count]
                    FROM [Account]
                    WHERE YEAR([CreatedOn])=" + request.Year + "AND MONTH([CreatedOn])=" + request.Month +
                  @"GROUP BY DAY([CreatedOn])
                    ORDER BY DAY([CreatedOn]) ASC;";

        var result = await _dapperrepository.QueryAsync<AccountDayDto>(query, null, null, cancellationToken);

        return result.ToList();
    }
}
