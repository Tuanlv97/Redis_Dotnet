using System;
using System.Threading.Tasks;

namespace DemoRedis.Services
{
    public interface IResponseCacheService
    {
        Task SetCacheReponseAsync(string cacheKey, object response, TimeSpan timeOut);
        Task<string> GetCacheResponseAsync(string cacheKey);
    }
}
