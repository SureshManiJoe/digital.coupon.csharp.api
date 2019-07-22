using DigitalCouponApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Repositories
{
    public class LedgerRepository : ILedgerRepository
    {
        private readonly CouponDbContext couponDbContext;

        public LedgerRepository(CouponDbContext couponDbContext)
        {
            this.couponDbContext = couponDbContext;
        }

        public Task<IEnumerable<Ledger>> GetAll()
        {
            var ledger = couponDbContext.Ledger
                .Include(l => l.Coupon.Customer).OrderByDescending(l  => l.CreatedDateTime).AsEnumerable();
            return Task.FromResult(ledger);
        }
        public Task<Ledger> Create(Ledger ledger)
        {
            couponDbContext.Ledger.Add(ledger);
            couponDbContext.SaveChanges();
            return Task.FromResult(ledger);
        }
    }
}
