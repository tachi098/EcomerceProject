using EcomerceProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Seeders
{
    public class ProductSeeders
    {
        public ProductSeeders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { id = 1, name = "Nokia", image = "image/p1.jpg", price = 5000, saleprice = 400, finalprice = 4600, status = 1, create_at = DateTime.Now, update_at = DateTime.Now },
                new Product { id = 2, name = "Samsung Galaxy", image = "image/p2.jpg", price = 5000, saleprice = 400, finalprice = 4600, status = 1, create_at = DateTime.Now, update_at = DateTime.Now },
                new Product { id = 3, name = "Samsung Note", image = "image/p3.jpg", price = 5000, saleprice = 400, finalprice = 4600, status = 1, create_at = DateTime.Now, update_at = DateTime.Now },
                new Product { id = 4, name = "Iphone", image = "image/p4.jpg", price = 5000, saleprice = 400, finalprice = 4600, status = 1, create_at = DateTime.Now, update_at = DateTime.Now }
            );
        }
    }
}
