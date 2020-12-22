using EcomerceProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Seeders
{
    public class UserSeeders
    {
        public UserSeeders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { id = 1, name = "huy", email = "toilahuy098@gmail.com", phone = "0933691822", address = "binh thanh", password = "123456", avatar = "image/p1.png", level = true, status = true, create_at = DateTime.Now, update_at = DateTime.Now, },
                new User { id = 2, name = "hoai", email = "hoaixp@gmail.com", phone = "0933691822", address = "quan 3", password = "123456", avatar = "image/p2.png", level = false, status = true, create_at = DateTime.Now, update_at = DateTime.Now, },
                new User { id = 3, name = "lan", email = "lanttm@gmail.com", phone = "0933691822", address = "quan 3", password = "123456", avatar = "image/p2.png", level = false, status = true, create_at = DateTime.Now, update_at = DateTime.Now, }
            );
        }
    }
}
