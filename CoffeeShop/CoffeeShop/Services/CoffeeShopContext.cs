using CoffeeShop.DALModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Services
{
        public class CoffeeShopContext : IdentityDbContext
        {
            public CoffeeShopContext(DbContextOptions options) : base(options)
            {

            }

            //public DbSet<CoffeeDAL> Users { get; set; }
            public DbSet<ItemsDAL> Items { get; set; }
    }
}
