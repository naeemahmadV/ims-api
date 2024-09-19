namespace FSH.WebApi.Application.Catalog.Opportunity;
public class GetOpportunityCountMonthWiseRequest : IRequest<IList<OpportunityMonthDto>>
{
    public int Year { get; set; }

    public GetOpportunityCountMonthWiseRequest(int year)
    {
        Year = year;
    }
}

public class GetOpportunityCountMonthWiseRequestHandler : IRequestHandler<GetOpportunityCountMonthWiseRequest, IList<OpportunityMonthDto>>
{
    private readonly IRepository<Domain.Catalog.Opportunity> _repository;
    private readonly IDapperRepository _dapperrepository;

    public GetOpportunityCountMonthWiseRequestHandler(IRepository<Domain.Catalog.Opportunity> repository, IDapperRepository dapperrepository)
    {
        _repository = repository;
        _dapperrepository = dapperrepository;
    }

    public async Task<IList<OpportunityMonthDto>> Handle(GetOpportunityCountMonthWiseRequest request, CancellationToken cancellationToken)
    {
        string query = @"
                    SELECT
                        MONTH([CreatedOn]) AS [Month],
                        COUNT(*) AS [Count]
                    FROM Catalog.Opportunity
                    WHERE YEAR([CreatedOn])=" + request.Year +
                    @"GROUP BY MONTH([CreatedOn])
                    ORDER BY MONTH([CreatedOn]) ASC;
                    ";

        var result = await _dapperrepository.QueryAsync<OpportunityMonthDto>(query, null, null, cancellationToken);

        return result.ToList();
    }
}
