using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Models
{
    public class CustomerCouponModel
    {
        public CustomerModel Customer { get; set; }
        public CouponModel[] Coupons { get; set; }
    }
}
