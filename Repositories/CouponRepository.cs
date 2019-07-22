using DigitalCouponApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CouponDbContext couponDbContext;

        public CouponRepository(CouponDbContext couponDbContext)
        {
            this.couponDbContext = couponDbContext;
        }

        public Task<IEnumerable<Coupon>> GetAll()
        {
            var coupons = couponDbContext.Coupons
                .Include(c => c.Customer).OrderByDescending(k => k.CreatedDateTime).AsEnumerable();
            return Task.FromResult(coupons);
        }

        public Task<IEnumerable<Coupon>> GetByCustomerId(string id)
        {
            var coupons = couponDbContext.Coupons.Where(c => c.CustomerId.ToString().ToLower() == id.ToLower()).AsEnumerable();
            return Task.FromResult(coupons);
        }

        public Task<Coupon> GetById(string id)
        {
            var coupon = GetCoupon(id);
            return Task.FromResult(coupon);
        }

        public async Task<Coupon> Create(Coupon coupon)
        {
            couponDbContext.Coupons.Add(coupon);
            await couponDbContext.SaveChangesAsync();
            return coupon;
        }

        public Task<bool> IsValid(string couponId, string customerId)
        {
            var result = couponDbContext.Coupons.FirstOrDefault(c => c.Id.ToString().ToLower() == couponId.ToLower() &&
            c.CustomerId.ToString().ToLower() == customerId.ToLower());
            if (result == null)
                return Task.FromResult(false);
            if (DateTime.Compare(result.ExpiresOn, DateTime.Now) == -1)
                return Task.FromResult(true);
            return Task.FromResult(false);
        }

        public Task<Coupon> Redeem(string couponId)
        {
            var coupon = GetCoupon(couponId);
            coupon.Status = "REDEEMED";
            couponDbContext.SaveChanges();
            return Task.FromResult(coupon);
        }

        private Coupon GetCoupon(string id)
        {
            return couponDbContext.Coupons.Include(c => c.Customer).FirstOrDefault(c => c.Id.ToString().ToLower() == id.ToLower());
        }

    }
}
