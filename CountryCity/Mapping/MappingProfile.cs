using AutoMapper;
using CountryCity.Models;
using CountryCity.Models.ViewModel;
using CountryCity.ViewModel;

namespace CountryCity.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUserViewModel, AppUser>();

            CreateMap<AppUser,AppUserViewModel>();

            CreateMap<RoleViewModel,AppRole>();

            CreateMap<AppRole,RoleViewModel>();

            CreateMap<CountryViewModel,Country>();

            CreateMap<Country,CountryViewModel>();     
            
            
                        

            
        }

    }
}
