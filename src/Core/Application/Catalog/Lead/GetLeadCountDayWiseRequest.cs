namespace FSH.WebApi.Application.Catalog.Lead;
public class GetLeadCountDayWiseRequest : IRequest<IList<LeadDayDto>>
{
    public int Year { get; set; }
    public int Month { get; set; }
    public GetLeadCountDayWiseRequest(int year, int month) => (Year, Month) = (year, month);
}

public class GetLeadCountDayWiseRequestHandler : IRequestHandler<GetLeadCountDayWiseRequest, IList<LeadDayDto>>
{
    private readonly IRepository<Domain.Catalog.Lead> _repository;
    private readonly IDapperRepository _dapperrepository;
    public GetLeadCountDayWiseRequestHandler(IRepository<Domain.Catalog.Lead> repository, IDapperRepository dapperrepository)
    {
        _repository = repository;
        _dapperrepository = dapperrepository;
    }

    public async Task<IList<LeadDayDto>> Handle(GetLeadCountDayWiseRequest request, CancellationToken cancellationToken)
    {
        string query = @"
                    SELECT
                        DAY([CreatedOn]) AS [Day],
                        COUNT(*) AS [Count]
                    FROM Catalog.Lead
                    WHERE YEAR([CreatedOn])=" + request.Year + "AND MONTH([CreatedOn])=" + request.Month +
                  @"GROUP BY DAY([CreatedOn])
                    ORDER BY DAY([CreatedOn]) ASC;";

        var result = await _dapperrepository.QueryAsync<LeadDayDto>(query, null, null, cancellationToken);

        return result.ToList();
    }
}
