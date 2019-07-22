using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Models
{
    public class ValidateModel
    {
        public Guid CouponId { get; set; }
        public Guid CustomerId { get; set; }

    }
}
