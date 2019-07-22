using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Models
{
    public class RedeemModel
    {
        public double OriginalPrice { get; set; }
        public Guid CouponId { get; set; }

    }
}
