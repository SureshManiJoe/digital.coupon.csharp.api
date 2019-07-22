using DigitalCouponApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CouponDbContext couponDbContext;

        public CustomerRepository(CouponDbContext couponDbContext)
        {
            this.couponDbContext = couponDbContext;
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            var customer = couponDbContext.Customers.AsEnumerable();
            return Task.FromResult(customer);
        }

        public Task<Customer> GetById(string id)
        {
            var customer = couponDbContext.Customers.FirstOrDefault(c => c.Id.ToString().ToLower() == id.ToLower());
            return Task.FromResult(customer);
        }

    }
}
