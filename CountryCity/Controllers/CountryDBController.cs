using CountryCity.Context;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace CountryCity.Controllers
{
    public class CountryDBController : Controller
    {
        //Burada MySql'den çekilen verilerl listelenecektir.

        readonly CountryContext _countryContext;

        public CountryDBController(CountryContext countryContext)
        {
            _countryContext = countryContext;
        }
        
        public IActionResult Index()
        {
            var deger = _countryContext.Countries.ToList();
            return View(deger);
        }
    }
}
