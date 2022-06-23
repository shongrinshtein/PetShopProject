
using PetShop.Data;
using PetShop.Data.Models;
using PetShop.Data.Repository;
using PetShop.Service.Interfaces;

namespace PetShop.Service
{
    public class AdminService : IAdminstartorService
    {
        private readonly IAnimalRepository animalRepos;
        private readonly ICategoryRepository categoryRepository;

        public AdminService(IAnimalRepository animalRepository, ICategoryRepository categoryRepository)
        {
            this.animalRepos = animalRepository;
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Category?> GetAllCategorys()
        {

            return categoryRepository.GetAll().Result;
        }
        public async Task<IEnumerable<Animal>> GetAnimalsByCategory(int? category)
        {
            var tempRepos = await animalRepos.GetAll();
            if (category == null)
                return tempRepos;
            return tempRepos.Where(animal => animal.CategoryId == category);
        }

        public async Task<bool> AddAnimal(Animal animal)
        {
            try
            {
                var temp = await animalRepos.Insert(animal);
            }
            catch (Exception)
            { return false; }
            return true;
        }
        public async Task<bool> EditAnimal(Animal animal)
        {
            try
            { await animalRepos.Update(animal); }
            catch (Exception)
            { return false; }
            return true;
        }
        public async Task<bool> RemoveAnimal(int? id)
        {
            var tempAnimal = await animalRepos.Get(id);
            try
            {await animalRepos.Delete(id);}
            catch (Exception)
            {return false;}
            return true;
        }

        public async Task<Animal> GetAnimalById(int? id)
        {
            if (id == null) throw new ArgumentNullException("no id found");
            return await animalRepos.Get(id);
        }

        public Task<bool> AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}