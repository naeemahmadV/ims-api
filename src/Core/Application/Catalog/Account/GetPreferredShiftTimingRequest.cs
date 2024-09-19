using FSH.WebApi.Application.Catalog.LeadStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Account;
public class GetPreferredShiftTimingRequest : IRequest<List<PreferredShiftTimingRequestDto>>
{

}
public class GetPreferredShiftTimingRequestHandler : IRequestHandler<GetPreferredShiftTimingRequest, List<PreferredShiftTimingRequestDto>>
{
    public Task<List<PreferredShiftTimingRequestDto>> Handle(GetPreferredShiftTimingRequest request, CancellationToken cancellationToken)
    {
        var preferredShiftTimingRequestDto = Enum.GetValues(typeof(Domain.Common.PreferredShiftTiming))
                .Cast<Domain.Common.PreferredShiftTiming>()
                .Select(status => new PreferredShiftTimingRequestDto
                {
                    Id = (int)status,
                    Name = status.GetDescription()
                })
                .ToList();

        return Task.FromResult(preferredShiftTimingRequestDto);
    }
}