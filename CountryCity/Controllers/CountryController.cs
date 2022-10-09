using CountryCity.Models.MongoDB;
using CountryCity.Models.MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CountryCity.Controllers
{
    public class CountryController : Controller
    {
        //Buradaki Crud işlemleri MongoDb ile yapılacaktır.
       
        private readonly CountriesService countriesService;

        public CountryController(CountriesService countriesService)
        {
            this.countriesService = countriesService;
        }

        public async Task<IActionResult> Get()
        {
            var country = await countriesService.GetAsync();


            return View(country);

        }

        public async Task<IActionResult> AddCountry()
        {
            return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(CountryMongoDB C)
        {
            await countriesService.CreateAsync(C);

            return RedirectToAction("Get", "Country");

        }

    }
}
