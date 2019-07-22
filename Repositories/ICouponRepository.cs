using DigitalCouponApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Repositories
{
    public interface ICouponRepository  
    {
        Task<IEnumerable<Coupon>> GetAll();
        Task<Coupon> GetById(string id);
        Task<IEnumerable<Coupon>> GetByCustomerId(string id);
        Task<Coupon> Create(Coupon coupon);
        Task<bool> IsValid(string couponId, string customerId);
        Task<Coupon> Redeem(string id);
    }
}
