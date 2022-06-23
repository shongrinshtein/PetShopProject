using PetShop.Data;
using PetShop.Data.Model;
using PetShop.Data.Models;
using PetShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service
{
    public class HomeService : IHomeService
    {
        private readonly IAnimalRepository animalRepos;
        private readonly ICommentRepository commentRepository;

        public HomeService(IAnimalRepository animalRepository, ICommentRepository commentRepository)
        {
            this.animalRepos = animalRepository;
            this.commentRepository = commentRepository;
        }
        public async Task<IEnumerable<AnimalForView>> GetTopTwoComments()
        {
            var tempComments = await this.commentRepository.GetAll();
            var topCommentsAnimals = tempComments.ToList().GroupBy(c => c.AnimalId)
                .Select(a => new { animalId = a.Key, CountComments = a.Count() })
                .OrderByDescending(a => a.CountComments).Take(2);
            if (topCommentsAnimals == default) throw new ArgumentNullException("no animal found");
            List<AnimalForView> animals = new List<AnimalForView>();
            List<Animal> regularAnimals = new List<Animal>();
            foreach (var tempAnimal in topCommentsAnimals)
            {
                animals.Add(new AnimalForView { Animal = animalRepos.Get(tempAnimal.animalId).Result, CountComments = tempAnimal.CountComments });
                regularAnimals.Add(animalRepos.Get(tempAnimal.animalId).Result);
            }
            foreach (var tempAnimal in animalRepos.GetAll().Result)
            {
                if (animals.Count == 2) break;
                if (!regularAnimals.Contains(tempAnimal)) animals.Add(new AnimalForView { Animal = tempAnimal, CountComments = 0 });
            }
            return animals;
        }
    }
}
