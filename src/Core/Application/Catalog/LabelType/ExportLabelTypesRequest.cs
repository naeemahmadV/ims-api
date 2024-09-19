using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class ExportLabelTypesRequest : BaseFilter, IRequest<Stream>
{
}

public class ExportLabelTypesRequestHandler : IRequestHandler<ExportLabelTypesRequest, Stream>
{
    private readonly IReadRepository<FSH.WebApi.Domain.Catalog.LabelTypes> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportLabelTypesRequestHandler(IReadRepository<FSH.WebApi.Domain.Catalog.LabelTypes> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportLabelTypesRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportLabelTypespecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportLabelTypespecification : EntitiesByBaseFilterSpec<FSH.WebApi.Domain.Catalog.LabelTypes, LabelTypesExportDto>
{
    public ExportLabelTypespecification(ExportLabelTypesRequest request)
         : base(request)
    {

    }
}