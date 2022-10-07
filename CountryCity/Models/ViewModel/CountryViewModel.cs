using System.ComponentModel.DataAnnotations;

namespace CountryCity.Models.ViewModel
{
    public class CountryViewModel
    {
        
        public string Name { get; set; }
       
        public string Capital { get; set; }

        public int? Population { get; set; }

    }
}
