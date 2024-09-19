using FSH.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Common.Interfaces;
public interface IUploadService : ITransientService
{
    string UploadAsync(UploadRequest request);
}
