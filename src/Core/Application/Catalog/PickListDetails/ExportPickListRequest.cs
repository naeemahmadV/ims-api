using FSH.WebApi.Application.Catalog.Products;
using FSH.WebApi.Application.Common.Exporters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.PickListDetails;
public class ExportPickListRequest : BaseFilter, IRequest<Stream>
{
}

public class ExportPickListRequestHandler : IRequestHandler<ExportPickListRequest, Stream>
{
    private readonly IReadRepository<PickList> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportPickListRequestHandler(IReadRepository<PickList> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportPickListRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportPickListpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportPickListpecification : EntitiesByBaseFilterSpec<PickList, PickListExportDto>
{
    public ExportPickListpecification(ExportPickListRequest request)
         : base(request)
    {

    }
}