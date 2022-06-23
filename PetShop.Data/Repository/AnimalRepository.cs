using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ContextDB _context;
        public AnimalRepository(ContextDB context) => _context = context;
        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null) return false;
            foreach (var comment in animal.Comments)
            {
                _context.Comments.Remove(comment);
            }
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Animal> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var animal = await _context.Animals
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null) throw new ArgumentNullException("Animal is null"); ;
            return animal;
        }
        public async Task<Animal> Get(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name is null"); ;
            var animal = await _context.Animals
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Name == name);
            if (animal == null) throw new ArgumentNullException("Animal is null"); ;

            return animal;
        }
        public async Task<IEnumerable<Animal>> GetAll() => await _context.Animals.ToListAsync();
        public async Task<int> Insert(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException("Animal is null");
            await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();
            return animal.AnimalId;
        }
        public async Task<bool> Update(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException("Animal is null");
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
