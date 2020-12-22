using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomerceProject.Entities;

namespace EcomerceProject.Seeders
{
    public class OrderDetailSeeders
    {
        public OrderDetailSeeders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { id = 1, price = 5000, quantity = 2, productid = 1, orderid = 1}
            );
        }
    }
}
