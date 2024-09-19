using FSH.WebApi.Application.Catalog.PickListDetails;
using FSH.WebApi.Application.Common.Exporters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.StepType;
public class ExportStepTypeRequest : BaseFilter, IRequest<Stream>
{
}

public class ExportStepTypeRequestHandler : IRequestHandler<ExportStepTypeRequest, Stream>
{
    private readonly IReadRepository<FSH.WebApi.Domain.Catalog.StepTypes> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportStepTypeRequestHandler(IReadRepository<FSH.WebApi.Domain.Catalog.StepTypes> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportStepTypeRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportStepTypeSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportStepTypeSpecification : EntitiesByBaseFilterSpec<FSH.WebApi.Domain.Catalog.StepTypes, StepTypeDto>
{
    public ExportStepTypeSpecification(ExportStepTypeRequest request)
         : base(request)
    {

    }
}