using AutoMapper;
using PetShop.Client.Models;
using PetShop.Data.Models;

namespace PetShop.Client.Profiles
{
    public class ProfileAnimal:Profile
    {
        public ProfileAnimal()
        {
            CreateMap<Animal,AnimalViewModel>().ReverseMap();
        }
    }
}
