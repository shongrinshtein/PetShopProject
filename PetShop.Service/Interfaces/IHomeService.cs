using PetShop.Data.Model;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service
{
    public interface IHomeService
    {
        Task<IEnumerable<AnimalForView>> GetTopTwoComments(); 
    }
}
