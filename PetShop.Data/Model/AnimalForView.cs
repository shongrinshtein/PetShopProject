using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Model
{
    public class AnimalForView
    {
        public Animal? Animal { get; set; }
        public int CountComments { get; set; }
    }
}
