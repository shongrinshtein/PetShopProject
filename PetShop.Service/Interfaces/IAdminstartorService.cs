using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service.Interfaces
{
    public interface IAdminstartorService:ICatalogService
    {
        Task<bool> AddAnimal(Animal animal);
        Task<bool> EditAnimal(Animal animal);
        Task<bool> RemoveAnimal(int? id);
        Task<Animal> GetAnimalById(int? id);
    }
}
