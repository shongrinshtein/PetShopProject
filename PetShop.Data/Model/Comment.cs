using System;
using System.Collections.Generic;

namespace PetShop.Data.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        
        public string Content { get; set; } = null!;
        public int? AnimalId { get; set; }

        public virtual Animal? Animal { get; set; }
    }
}
