using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Caching.Distributed
{
    public static class DistributedCacheExtensions
    {
        public static T GetOrSet<T>(this IDistributedCache cache, string key, Func<T> func, DistributedCacheEntryOptions options=null)
        {
            var value = cache.GetString(key);
            if ("CACHE_ROLE_ALL_KEY".Equals(key))
            {
                
            }

            if (value.IsNullOrEmpty()) 
            {
                if (func == null) return default(T);
                var result = func();
                if (result == null) return default(T);
                if (options == null)
                {
                    //cache.SetString(key,System.Text.Json.JsonSerializer.Serialize(result));
                    cache.SetString(key,Newtonsoft.Json.JsonConvert.SerializeObject(result)); 
                }
                else
                {
                    cache.SetString(key,Newtonsoft.Json.JsonConvert.SerializeObject(result), options); 
                }
                
                return result;
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
            //return System.Text.Json.JsonSerializer.Deserialize<T>(value);
        }
    }
}