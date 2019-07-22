using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DigitalCouponApi.Repositories;
using DigitalCouponApi.Models;

namespace DigitalCouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public ICustomerRepository CustomerRepository { get; set; }

        public CustomersController(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerModel>> Get()
        {
            var customers = await CustomerRepository.GetAll();
            if (customers == null)
                return new List<CustomerModel>();
            return customers.Select(c => c.ToModel());
        }

        [HttpGet("{id}")]
        public async Task<CustomerModel> GetById(string id)
        {
            var customer = await CustomerRepository.GetById(id);
            if (customer == null)
                return null;
            return customer.ToModel();
        }
    }
}
