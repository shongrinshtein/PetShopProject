using System;
using System.Collections.Generic;

namespace PetShop.Data.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Comments = new HashSet<Comment>();
        }

        public int AnimalId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhotoUrl { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
