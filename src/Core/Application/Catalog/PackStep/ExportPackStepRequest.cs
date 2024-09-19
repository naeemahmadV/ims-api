using FSH.WebApi.Application.Catalog.StepType;
using FSH.WebApi.Application.Common.Exporters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.PackStep;
public class ExportPackStepRequest : BaseFilter, IRequest<Stream>
{
}

public class ExportPackStepRequestHandler : IRequestHandler<ExportPackStepRequest, Stream>
{
    private readonly IReadRepository<FSH.WebApi.Domain.Catalog.PackStep> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportPackStepRequestHandler(IReadRepository<FSH.WebApi.Domain.Catalog.PackStep> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportPackStepRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportPackStepSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportPackStepSpecification : EntitiesByBaseFilterSpec<FSH.WebApi.Domain.Catalog.PackStep, PackStepDto>
{
    public ExportPackStepSpecification(ExportPackStepRequest request)
         : base(request)
    {

    }
}