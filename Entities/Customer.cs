using DigitalCouponApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public CustomerModel ToModel()
        {
            return new CustomerModel()
            {
                Id = Id,
                Name = Name,
                Email = Email
            };
        }
    }
}
