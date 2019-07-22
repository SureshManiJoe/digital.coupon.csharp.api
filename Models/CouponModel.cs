using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Models
{
    public class CouponModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float DiscountPercent { get; set; }
        public float RevenueSharePercent { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Status { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
