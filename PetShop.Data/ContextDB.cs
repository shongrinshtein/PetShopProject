using Microsoft.EntityFrameworkCore;

namespace PetShop.Data.Models
{
    public partial class ContextDB : DbContext
    {
        public ContextDB()
        {
        }

        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        {

        }

        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SHONGRIN\\SHONSQLSERVER;Initial Catalog=PetShopDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
