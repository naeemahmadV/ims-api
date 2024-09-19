using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Domain.Catalog;
using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Lead;
public record GetLeadYearsRequest : IRequest<IList<LeadYearDto>>;

public class GetLeadYearsRequestHandler : IRequestHandler<GetLeadYearsRequest, IList<LeadYearDto>>
{
    private readonly IRepository<Domain.Catalog.Lead> _repository;
    private readonly IDapperRepository _dapperrepository;
    public GetLeadYearsRequestHandler(IRepository<Domain.Catalog.Lead> repository, IDapperRepository dapperrepository)
        => (_repository, _dapperrepository) = (repository, dapperrepository);

    public async Task<IList<LeadYearDto>> Handle(GetLeadYearsRequest request, CancellationToken cancellationToken)
    {
        string query = @"
                    SELECT
                        YEAR([CreatedOn]) AS [Year],
                        COUNT(*) AS [Count]
                    FROM Catalog.Lead
                    GROUP BY YEAR([CreatedOn])
                    ORDER BY YEAR([CreatedOn]) DESC;
                    ";
        var leadlist = await _dapperrepository.QueryAsync<LeadYearDto>(query, null, null, cancellationToken);
        return leadlist.ToList();
    }
}
