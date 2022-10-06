namespace CountryCity.Models
{
    using CountryCity.Service;
    using Microsoft.Build.Framework;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Caching.StackExchangeRedis;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using StackExchange.Redis;
    using System.Threading.Tasks;

    public class RedisService:ICacheManager
    {


        //ConnectionMultiplexer connectionMultiplexer;

        private IDatabase _database;

        private readonly IDistributedCache _redisCache;

        //private RedisCacheOptions options;

        //private string defaultConnectionString { get; set; }


        private static ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(IDistributedCache redisCache)
        {
            
            _redisCache = redisCache;

        }

        public async Task<bool> Clear()
        {

            try
            {
                var endpoints = _connectionMultiplexer.GetEndPoints(true);
                foreach (var endpoint in endpoints)
                {
                    var server = _connectionMultiplexer.GetServer(endpoint);
                    server.FlushAllDatabases();
                }
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public bool Contains(object key)
        {
            return _database.KeyExists((RedisKey)key);
        }

        public T Get<T>(string cacheKey) 
        {
           

                var valueString = _redisCache.GetString(cacheKey);
                if (!string.IsNullOrEmpty(valueString))
                {
                    var valueObject = JsonConvert.DeserializeObject<T>(valueString);
                    return (T)valueObject;
                }

                return default(T);
            
        }

        public void Remove(object key)  
        {
            _redisCache.Remove((string)key);            
        }

        public void Set<T>(string cacheKey, T model)  
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(90)
            };

            var valueString = JsonConvert.SerializeObject(model);
            _redisCache.SetString(cacheKey, valueString);
        }

        

       







        //public void Connect() => connectionMultiplexer = ConnectionMultiplexer.Connect("localhost"); //Redis sunucusuna bağlantı gerçekleştiriyoruz.
        //public IDatabase GetDb(int db)
        //{
        //    return connectionMultiplexer.GetDatabase(db);
        //}  //Redis VeriTabanları.


        //Burada Connect metodu içerisinde 'ConnectionMultiplexer' sınıfıyla Redis sunucusuna bağlantı gerçekleştirilmekte 
        //ve ardından 'GetDb' metodu ile de bağlantı gerçekleştirilmiş ilgili sınıf üzerinden Redis sunucusu üzerindeki
        //veritabanları çağırılarak elde edilmektedir.


    }


}
