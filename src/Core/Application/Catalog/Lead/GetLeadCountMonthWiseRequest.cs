namespace FSH.WebApi.Application.Catalog.Lead;
public class GetLeadCountMonthWiseRequest : IRequest<IList<LeadMonthDto>>
{
    public int Year { get; set; }
    public GetLeadCountMonthWiseRequest(int year) => Year = year;
}

public class GetLeadCountMonthWiseRequestHandler : IRequestHandler<GetLeadCountMonthWiseRequest, IList<LeadMonthDto>>
{
    private readonly IRepository<Domain.Catalog.Lead> _repository;
    private readonly IDapperRepository _dapperrepository;
    public GetLeadCountMonthWiseRequestHandler(IRepository<Domain.Catalog.Lead> repository, IDapperRepository dapperrepository)
    {
        _repository = repository;
        _dapperrepository = dapperrepository;
    }

    public async Task<IList<LeadMonthDto>> Handle(GetLeadCountMonthWiseRequest request, CancellationToken cancellationToken)
    {

        string query = @"
                    SELECT
                        MONTH([CreatedOn]) AS [Month],
                        COUNT(*) AS [Count]
                    FROM Catalog.Lead
                    WHERE YEAR([CreatedOn])=" + request.Year +
                    @"GROUP BY MONTH([CreatedOn])
                    ORDER BY MONTH([CreatedOn]) ASC;
                    ";

        var result = await _dapperrepository.QueryAsync<LeadMonthDto>(query, null, null, cancellationToken);

        return result.ToList();
    }
}