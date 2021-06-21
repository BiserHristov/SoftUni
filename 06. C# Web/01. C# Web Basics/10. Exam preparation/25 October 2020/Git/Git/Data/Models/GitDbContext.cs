using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Data.Models
{
    public class GitDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }
        public DbSet<Repository> Repositories { get; init; }
        public DbSet<Commit> Commits { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Git;Integrated Security=true;");
            }
        }

    }
}
