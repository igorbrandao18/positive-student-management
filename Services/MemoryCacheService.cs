using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace PositiveStudentManagement.Services
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _defaultExpiration = TimeSpan.FromMinutes(15);

        public MemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            await Task.CompletedTask;
            
            if (_cache.TryGetValue(key, out var value))
            {
                if (value is string jsonString)
                {
                    return JsonSerializer.Deserialize<T>(jsonString);
                }
                return (T?)value;
            }
            
            return default(T);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            await Task.CompletedTask;
            
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration ?? _defaultExpiration,
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };

            if (value != null && !IsSimpleType(typeof(T)))
            {
                var jsonString = JsonSerializer.Serialize(value);
                _cache.Set(key, jsonString, options);
            }
            else
            {
                _cache.Set(key, value, options);
            }
        }

        public async Task RemoveAsync(string key)
        {
            await Task.CompletedTask;
            _cache.Remove(key);
        }

        public async Task RemoveByPatternAsync(string pattern)
        {
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(string key)
        {
            await Task.CompletedTask;
            return _cache.TryGetValue(key, out _);
        }

        private static bool IsSimpleType(Type type)
        {
            return type.IsPrimitive ||
                   type.IsEnum ||
                   type == typeof(string) ||
                   type == typeof(DateTime) ||
                   type == typeof(DateTimeOffset) ||
                   type == typeof(TimeSpan) ||
                   type == typeof(Guid) ||
                   (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}
