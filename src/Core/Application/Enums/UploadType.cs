using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Enums;
public enum UploadType : byte
{
    [Description(@"Images\Products")]
    Product,

    [Description(@"Images\ProfilePictures")]
    ProfilePicture,

    [Description(@"Document")]
    Document,

    [Description(@"Image")]
    Image,

    [Description(@"Video")]
    Video,

    [Description(@"Unknown")]
    Unknown,
}
