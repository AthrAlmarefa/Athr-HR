using Athr.Domain.BuildingBlocks;
using System.ComponentModel.DataAnnotations;

namespace Athr.Domain.Common;

public sealed record ImagePath : ValueObject
{
    public string Value { get; }
    private ImagePath(string value) => Value = value;

    public static ImagePath Create(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            throw new ArgumentException("Image path cannot be empty", nameof(raw));

        // add whatever validation rules you need (allowed extensions, protocol, …)
        return new ImagePath(raw.Trim());
    }
    public static string GetImagePath(string storagePath)
    {
        var filePath = string.Join(Path.DirectorySeparatorChar, Constants.PublicPath, storagePath);
        if (File.Exists(filePath))
            return filePath.Replace('\\', '/');
        return storagePath;
    }
}

