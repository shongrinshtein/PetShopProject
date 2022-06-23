using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data
{
    public interface IRepository<T> where T : class
    {

        Task<int> Insert(T item);
        Task<bool> Update(T animal);
        Task<bool> Delete(int? id);
        Task<T> Get(int? id);
        Task<IEnumerable<T>> GetAll();
    }
    public interface IAnimalRepository : IRepository<Animal>
    {Task<Animal> Get(string name);}    
    public interface ICommentRepository : IRepository<Comment>{ }
    public interface ICategoryRepository : IRepository<Category>{ }


}
