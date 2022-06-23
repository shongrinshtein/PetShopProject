using System;
using System.Collections.Generic;

namespace PetShop.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            Animals = new HashSet<Animal>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
