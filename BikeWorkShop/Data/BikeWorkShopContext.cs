using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BikeWorkShop.Models;

namespace BikeWorkShop.Models
{
    public class BikeWorkShopContext : DbContext
    {
        public BikeWorkShopContext (DbContextOptions<BikeWorkShopContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }

        public DbSet<Part> Part { get; set; }
    }
}
