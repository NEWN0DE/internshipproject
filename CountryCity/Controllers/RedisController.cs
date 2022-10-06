using CountryCity.Context;
using CountryCity.Models;
using CountryCity.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace CountryCity.Controllers
{

    public class RedisController : Controller
    {

        //Bu class'ta Redis ile alakalı işlemler gerçekleştirilecektir.

        IDistributedCache _distributedCache; //Dependency Injection'dan Servisimizi Talep Ediyoruz.


        RedisService _redisService;

        ICacheManager _cacheManager;

        CountryContext _countryContext;

        public void SettCache<T>(string key,T model)
        {
            //string key = "Country";

            //var values = _countryContext.Countries.ToList();

            //_cacheManager.Set<List<Country>>(key, values);

            //return View();

        }

        public RedisController(IDistributedCache distributedCache, ICacheManager cacheManager,CountryContext countryContext)
        {
            _distributedCache = distributedCache;
            _cacheManager = cacheManager;
            _countryContext = countryContext;
        }           

       

        public IActionResult Page4()
        {
            var values = _cacheManager.Get<List<Country>>("Country");  //Get Cache

            return View(values);
        }        
                          

        public IActionResult SetCache()
        {
            string key = "Country";            

            var values = _countryContext.Countries.ToList();         

            _cacheManager.Set<List<Country>>(key,values);

            return View();
        }
       

        public IActionResult Remove()  //Key Değeri verilen datayı siler.
        {
            _cacheManager.Remove("Country");

            return View();
           
        }

        //public IActionResult ClearDataBase()
        //{
        //    _cacheManager.Clear();

        //    return View();

        //}

        //public IActionResult Contain()
        //{
        //    _cacheManager.Contains("Country");

        //    return View();
        //}





    }
}
