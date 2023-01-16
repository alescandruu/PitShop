using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PitShop.Models;

namespace PitShop.Data
{
    public class PitShopContext : DbContext
    {
        public PitShopContext (DbContextOptions<PitShopContext> options)
            : base(options)
        {
        }

        public DbSet<PitShop.Models.Car> Car { get; set; } = default!;

        public DbSet<PitShop.Models.Mechanic> Mechanic { get; set; }

        public DbSet<PitShop.Models.Booking> Booking { get; set; }

        public DbSet<PitShop.Models.Review> Review { get; set; }
    }
}
