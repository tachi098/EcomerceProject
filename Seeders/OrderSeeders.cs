using EcomerceProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Seeders
{
    public class OrderSeeders
    {
        public OrderSeeders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order { id = 1, userid = 1, name = "huy", email = "toilahuy098@gmail.com", phone = "0933691822", address = "binh thanh", status = true },
                new Order { id = 2, userid = 1, name = "huy", email = "toilahuy098@gmail.com", phone = "0933691822", address = "binh thanh", status = true },
                new Order { id = 3, userid = 2, name = "hoai", email = "toilahuy098@gmail.com", phone = "0933691822", address = "binh thanh", status = true },
                new Order { id = 4, userid = 2, name = "hoai", email = "toilahuy098@gmail.com", phone = "0933691822", address = "binh thanh", status = true }
            );
        }
    }
}
