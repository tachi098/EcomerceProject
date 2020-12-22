using EcomerceProject.Entities;
using EcomerceProject.Seeders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Repositories
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> orderDetail { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var mainSeeder = new ApplicationSeeders();
            new ApplicationSeeders().OnModelSeeders(modelBuilder);
        }
    }
}
