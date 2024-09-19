namespace FSH.WebApi.Application.Catalog.Opportunity;
public class GetOpportunityYearsRequest : IRequest<IList<OpportunityYearDto>>
{

}

public class GetOpportunityYearsRequestHandler : IRequestHandler<GetOpportunityYearsRequest, IList<OpportunityYearDto>>
{
    private readonly IRepository<Domain.Catalog.Opportunity> _repository;
    private readonly IDapperRepository _dapperrepository;
    public GetOpportunityYearsRequestHandler(IRepository<Domain.Catalog.Opportunity> repository, IDapperRepository dapperrepository)
        => (_repository, _dapperrepository) = (repository, dapperrepository);

    public async Task<IList<OpportunityYearDto>> Handle(GetOpportunityYearsRequest request, CancellationToken cancellationToken)
    {
        string query = @"
                    SELECT
                        YEAR([CreatedOn]) AS [Year],
                        COUNT(*) AS [Count]
                    FROM Catalog.Opportunity
                    GROUP BY YEAR([CreatedOn])
                    ORDER BY YEAR([CreatedOn]) DESC;
                    ";
        var opportunitylist = await _dapperrepository.QueryAsync<OpportunityYearDto>(query, null, null, cancellationToken);
        return opportunitylist.ToList();
    }
}

