﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Uploads
{
    public enum UploadType
    {
        BookImage
    }
    public interface IBase64FileUploader
    {
        bool IsExtensionsValid(string base64File);
        string GetExtension(string base64File);
        string Upload(string base64File, UploadType type);
        IEnumerable<string> Upload(IEnumerable<string> base64Files, UploadType type);
    }
}
