using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class AppDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;");
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
