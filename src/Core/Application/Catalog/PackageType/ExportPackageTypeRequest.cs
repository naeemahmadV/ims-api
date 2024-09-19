using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.Catalog.PackageType;
public class ExportPackageTypeRequest : BaseFilter, IRequest<Stream>
{
}

public class ExportPackageTypeRequestHandler : IRequestHandler<ExportPackageTypeRequest, Stream>
{
    private readonly IReadRepository<FSH.WebApi.Domain.Catalog.PackageType> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportPackageTypeRequestHandler(IReadRepository<FSH.WebApi.Domain.Catalog.PackageType> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportPackageTypeRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportPackageTypepecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportPackageTypepecification : EntitiesByBaseFilterSpec<FSH.WebApi.Domain.Catalog.PackageType, PackageTypeExportDto>
{
    public ExportPackageTypepecification(ExportPackageTypeRequest request)
         : base(request)
    {

    }
}