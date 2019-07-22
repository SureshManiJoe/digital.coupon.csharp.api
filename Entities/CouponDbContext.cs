using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Entities
{
    public class CouponDbContext : DbContext
    {
        public CouponDbContext(DbContextOptions<CouponDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Ledger> Ledger { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer()
            {
                Id = Guid.NewGuid(),
                Name = "Jeffrey Ritcher",
                Email = "jeffrey.ritcher@nowhere.com",
                CreatedDateTime = DateTime.Now
            }, new Customer()
            {
                Id = Guid.NewGuid(),
                Name = "Sheldon Couper",
                Email = "sheldon.couper@nowhere.com",
                CreatedDateTime = DateTime.Now
            }, new Customer()
            {
                Id = Guid.NewGuid(),
                Name = "Mike Hill",
                Email = "mike.hill@nowhere.com",
                CreatedDateTime = DateTime.Now
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
