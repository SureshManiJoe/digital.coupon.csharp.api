using DigitalCouponApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Entities
{
    [Table("Ledger")]
    public class Ledger
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CouponId { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountAmount { get; set; }
        public double SalesAmount { get; set; }
        public double RevenueShareAmount { get; set; }
        public double SettlementAmount { get; set; }
        public DateTime CreatedDateTime { get; set; }
        [ForeignKey("CouponId")]
        public Coupon Coupon { get; set; }
        public LedgerModel ToModel()
        {
            return new LedgerModel()
            {
                Id = Id,
                OriginalPrice = OriginalPrice,
                DiscountAmount = DiscountAmount,
                SalesAmount = SalesAmount,
                RevenueShareAmount = RevenueShareAmount,
                SettlementAmount = SettlementAmount,
                Coupon = Coupon.ToModel()
            };
        }
    }
}
