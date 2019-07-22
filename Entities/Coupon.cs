using DigitalCouponApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Entities
{
    [Table("Coupon")]
    public class Coupon
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public float DiscountPercent { get; set; }
        public float RevenueSharePercent { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public CouponModel ToModel()
        {
            return new CouponModel()
            {
                Id = Id,
                Name = Name,
                DiscountPercent = DiscountPercent,
                RevenueSharePercent = RevenueSharePercent,
                ExpiresOn = ExpiresOn,
                Status = Status,
                Customer = Customer.ToModel()
            };
        }
    }
}
