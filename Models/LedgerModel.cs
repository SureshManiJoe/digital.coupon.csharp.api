using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Models
{
    public class LedgerModel
    {
        public Guid Id { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountAmount { get; set; }
        public double SalesAmount { get; set; }
        public double RevenueShareAmount { get; set; }
        public double SettlementAmount { get; set; }
        public CouponModel Coupon { get; set; }
    }
}
