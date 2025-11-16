using Athr.Application.Exceptions;
using Athr.Domain.BuildingBlocks;
using static Athr.Domain.BuildingBlocks.Constants;

namespace Athr.Application.Common
{
    public sealed class FileStorageService : IFileStorageService
    {
        public Task DeleteAsync(string storedPath, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ImageFileStorage(string uploadPath, Stream content, string extension, string mimeType, CancellationToken ct = default)
        {

            // —— 1. Size guard ——————————————————————————
            if (content.Length > MaxImageBytes)
                throw new ValidationException([new("File Size Error:", $"File exceeds {(MaxImageBytes / 1024)} KB limit.")]);

            //// —— 2. MIME sniff ——————————————————————————–
            if (!AllowedImageMimeTypes.Contains(mimeType))
                throw new ValidationException([new("File MumeType Error:", $"Unsupported MIME type: {mimeType}")]);

            return await SaveAsync(uploadPath, content, extension, mimeType, ct);
        }

        public async Task<string> MediaFileStorage(string uploadPath, Stream content, string extension, string mimeType, CancellationToken ct = default)
        {

            // —— 1. Size guard ——————————————————————————
            if (content.Length > MaxMediaBytes)
                throw new ValidationException([new("File Size Error:", $"File exceeds {(MaxMediaBytes / 1024)} KB limit.")]);

            //// —— 2. MIME sniff ——————————————————————————–
            if (!AllowedMediaTypes.Contains(mimeType))
                throw new ValidationException([new("File MumeType Error:", $"Unsupported MIME type: {mimeType}")]);

            return await SaveAsync(uploadPath, content, extension, mimeType, ct);
        }

        public string GetFinalPath(string storagePath)
        {
            var filePath = string.Join(Path.DirectorySeparatorChar, PublicPath, storagePath);
            if (File.Exists(filePath))
                return filePath.Replace('\\', '/');
            throw new ValidationException([new("File Not Exist", $"Invalid Media File Storage Credentials")]);
        }

        public Task<Stream> GetStreamAsync(string storagePath, long? from = null, long? to = null)
        {
            var fileStream = new FileStream(storagePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            return Task.FromResult<Stream>(fileStream);
        }

        private async Task<string> SaveAsync(string uploadPath, Stream content, string extension, string mimeType, CancellationToken ct = default)
        {

            //// rewind after sniffing
            //src.Position = 0;

            //// —— 3. Generate key & ensure dir ——————————
            var (key, abs) = PathStrategy(uploadPath, extension);
            Directory.CreateDirectory(Path.GetDirectoryName(abs)!);

            //// —— 4. Atomic write —————————————————————————
            var tmp = $"{abs}.tmp";
            await using (var fs = File.Create(tmp))
                await content.CopyToAsync(fs, 128 * 1024, ct);   // 128 KB buffer

            File.Move(tmp, abs, overwrite: false);


            //// —— 6. Return public URL———————————————
            return key.Replace('\\', '/');
        }

        private (string RelativeKey, string AbsolutePath) PathStrategy(string uploadPath, string ext)
        {
            var guid = Guid.NewGuid().ToString("N");          // 32 hex chars
            var hash = guid[..(HashDepth * 2)];             // e.g. "ab"

            var file = string.Concat(hash, "_",
                DateTime.Now.ToString("yyyyMMddHHmmss"),
                ext.ToLowerInvariant());

            var relativeKey = string.Join(Path.DirectorySeparatorChar, uploadPath, file);
            var absolutePath = string.Join(Path.DirectorySeparatorChar, Path.Combine(PublicPath, relativeKey));

            return (relativeKey, absolutePath);
        }
    }
}
