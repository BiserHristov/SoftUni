namespace ChangeMe.Data
{
    using ChangeMe.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ChangeMeDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ChangeMe;Integrated Security=True;");
            }
        }

    }
}
