using PetShop.Data;
using PetShop.Data.Models;
using PetShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IAnimalRepository animalRepos;
        private readonly ICategoryRepository categoryRepository;

        public CatalogService(IAnimalRepository animalRepository, ICommentRepository commentRepository,ICategoryRepository categoryRepository)
        {
            this.commentRepository = commentRepository;
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


        public async Task< bool> AddComment(Comment comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Content) || comment == null)
                return false;
            try
            { await commentRepository.Insert(comment); }
            catch (Exception)
            { return false; }
            return true;
        }
        public async Task<Animal> GetAnimalById(int? id)
        {
            if (id == null) throw new ArgumentNullException("no id found");
            return await animalRepos.Get(id);
        }


    }
}
