using PetShop.Data.Models;
using PetShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service
{
    public class UserService
    {
        protected AnimalRepository animalRepos;
        protected CommentRepository? commentRepository;
        public UserService(AnimalRepository animalRepository) => this.animalRepos = animalRepository;

        public IEnumerable<Animal> SortByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category)) return Enumerable.Empty<Animal>();
            return animalRepos.GetAll().Result.ToList().Where(c => c.Category.Name == category);
        }

    }
}
