using Athr.Application.Abstractions.Messaging;

namespace Athr.Application.Abstractions.Caching;

public interface ICachedQuery<out TResponse> : IQuery<TResponse>, ICachedQuery;

public interface ICachedQuery
{
    string CacheKey { get; }

    TimeSpan? Expiration { get; }
}
