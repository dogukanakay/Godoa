using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class GodoaContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<VirtualCurrencyType> VirtualCurrencyTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameKey> GameKeys { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<VirtualCurrency> VirtualCurrencies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ABRA; Database= Godofa; Trusted_Connection=true; Encrypt=True;TrustServerCertificate=True");
        }
    }
}
