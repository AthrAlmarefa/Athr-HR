namespace Athr.Application.Common;

public class PaginatedList<T>
{
    public IReadOnlyList<T> Data { get; init; }
    public int Total { get; init; }
    public int CurrentPage { get; init; }
    public int PerPage { get; init; }
}
