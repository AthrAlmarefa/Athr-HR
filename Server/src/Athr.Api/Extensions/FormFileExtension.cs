using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Application.Exceptions;

namespace Athr.Api.Extensions;

public static class FormFileExtension
{
    /// <summary>
    /// Returns a tuple containing the opened read-stream and the file’s extension
    /// (including the leading dot, e.g. “.jpg”).
    /// </summary>
    public static (Stream Stream, string Extension) OpenReadWithExtension(this IFormFile file)
    {
        if (file is null || file.Length == 0)
            throw new ValidationException([new("File Error:", $"File Can't Be Empty.")]);
        // Important: DO NOT dispose here – the caller must dispose the stream.
        return (file.OpenReadStream(), Path.GetExtension(file.FileName));
    }
}
