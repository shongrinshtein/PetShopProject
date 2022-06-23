using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ContextDB _context;
        public CategoryRepository(ContextDB context) => _context = context;

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll() => await _context.Categories.ToListAsync();

        public Task<int> Insert(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Category animal)
        {
            throw new NotImplementedException();
        }
    }
}
