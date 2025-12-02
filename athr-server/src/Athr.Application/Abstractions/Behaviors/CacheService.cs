using Athr.Application.Abstractions.Caching;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using System.Text.Json;

namespace Athr.Infrastructure.Caching;

public sealed class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _redis;
    private readonly StackExchange.Redis.IDatabase _database;

    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _database = redis.GetDatabase();
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var value = await _database.StringGetAsync(key);

        if (value.IsNullOrEmpty)
            return default;

        return JsonSerializer.Deserialize<T>(value!);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
    {
        var serializedValue = JsonSerializer.Serialize(value);

        if (expiration.HasValue)
        {
            await _database.StringSetAsync(key, serializedValue, expiration.Value);
        }
        else
        {
            await _database.StringSetAsync(key, serializedValue);
        }
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        return _database.KeyDeleteAsync(key);
    }

    public Task<bool> ContainsAsync(string key, CancellationToken cancellationToken = default)
    {
        return _database.KeyExistsAsync(key);
    }
}