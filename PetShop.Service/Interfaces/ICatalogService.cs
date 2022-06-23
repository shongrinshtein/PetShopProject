using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service.Interfaces
{
    public interface ICatalogService
    {
        IEnumerable<Category?> GetAllCategorys();
        Task<IEnumerable<Animal>> GetAnimalsByCategory(int? category);
        Task<Animal> GetAnimalById(int? id);
        Task<bool> AddComment(Comment comment);
    }
}
