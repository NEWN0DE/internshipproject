using CountryCity.Context;
using CountryCity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryCity.Controllers
{
    public class CountryAjax : Controller
    {

        //Burada JQuery ile veri post edilmiştir.
        readonly CountryContext _context;
        public CountryAjax(CountryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {          
                                  

            return View();
        }

        [HttpPost]
        public IActionResult GetDataCountry(Country C1)
        {
            _context.AddAsync(C1);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
