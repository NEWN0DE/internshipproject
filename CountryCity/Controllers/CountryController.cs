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

        
        public async Task<IActionResult> RemoveCountry(string id)
        {
            await countriesService.RemoveAsync(id);

            return RedirectToAction("Get", "Country");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCountry(string id)
        {
            var value =await countriesService.GetAsync(id);

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCountry(string id, CountryMongoDB cmd)
        {
            countriesService.UpdateAsync(id, cmd);

            return RedirectToAction("Get", "Country");

        }



    }
}
