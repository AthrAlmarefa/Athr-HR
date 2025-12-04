namespace Athr.Domain.BuildingBlocks
{
    public interface IFileStorageService
    {
        Task DeleteAsync(string storedPath, CancellationToken ct = default);

        Task<string> ImageFileStorage(string uploadPath, Stream content, string extension, string mimeType, CancellationToken ct = default);

        Task<string> MediaFileStorage(string uploadPath, Stream content, string extension, string mimeType, CancellationToken ct = default);
        string GetFinalPath(string storagePath);
        Task<Stream> GetStreamAsync(string storagePath, long? from = null, long? to = null);

    }
}
