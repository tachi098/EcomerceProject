using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Seeders
{
    public class ApplicationSeeders
    {
        public void OnModelSeeders(ModelBuilder modelBuilder)
        {
            //User
            new UserSeeders(modelBuilder);

            //Order
            new OrderSeeders(modelBuilder);

            //Product
            new ProductSeeders(modelBuilder);

            //OrderDetail
            new OrderDetailSeeders(modelBuilder);
        }
    }
}
