namespace FSH.WebApi.Application.Catalog.Opportunity;
public class GetOpportunityCountDayWiseRequest : IRequest<IList<OpportunityDayDto>>
{
    public int Year { get; set; }
    public int Month { get; set; }

    public GetOpportunityCountDayWiseRequest(int year, int month)
    {
        Year = year;
        Month = month;
    }
}

public class GetOpportunityCountDayWiseRequestHandler : IRequestHandler<GetOpportunityCountDayWiseRequest, IList<OpportunityDayDto>>
{
    private readonly IRepository<Domain.Catalog.Opportunity> _repository;
    private readonly IDapperRepository _dapperRepository;

    public GetOpportunityCountDayWiseRequestHandler(IRepository<Domain.Catalog.Opportunity> repository, IDapperRepository dapperRepository)
    {
        _repository = repository;
        _dapperRepository = dapperRepository;
    }

    public async Task<IList<OpportunityDayDto>> Handle(GetOpportunityCountDayWiseRequest request, CancellationToken cancellationToken)
    {
        string query = @"
                    SELECT
                        DAY([CreatedOn]) AS [Day],
                        COUNT(*) AS [Count]
                    FROM Catalog.Opportunity
                    WHERE YEAR([CreatedOn])=" + request.Year + "AND MONTH([CreatedOn])=" + request.Month +
        @"GROUP BY DAY([CreatedOn])
                    ORDER BY DAY([CreatedOn]) ASC;"
        ;

        var result = await _dapperRepository.QueryAsync<OpportunityDayDto>(query, null, null, cancellationToken);
        return result.ToList();
    }
}