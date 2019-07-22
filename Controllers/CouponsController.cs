using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalCouponApi.Entities;
using DigitalCouponApi.Models;
using DigitalCouponApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCouponApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        public ICouponRepository CouponRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public ILedgerRepository LedgerRepository { get; set; }
        public CouponsController(ICouponRepository couponRepository, ICustomerRepository customerRepository, ILedgerRepository ledgerRepository)
        {
            CouponRepository = couponRepository;
            CustomerRepository = customerRepository;
            LedgerRepository = ledgerRepository;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<CouponModel>> GetAll()
        {
            var coupons = await CouponRepository.GetAll();
            if (coupons == null)
                return new List<CouponModel>();
            return coupons.Select(c => c.ToModel());
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<CouponModel> GetById(string id)
        {
            var coupon = await CouponRepository.GetById(id);
            if (coupon == null)
                return null;
            return coupon.ToModel();
        }

        [HttpGet("{id}", Name = "GetByCustomer")]
        public async Task<CustomerCouponModel> GetByCustomer(string id)
        {
            var customerCouponModel = new CustomerCouponModel();
            var customer = await CustomerRepository.GetById(id);
            var coupons = await CouponRepository.GetByCustomerId(id);
            if (customer != null)
            {
                customerCouponModel.Customer = customer.ToModel();
            }
            customerCouponModel.Coupons = coupons?.Select(c => c.ToModel()).ToArray();
            return customerCouponModel;
        }

        [HttpPost(Name = "Create")]
        public async Task<CouponModel> Create([FromBody] CouponModel couponModel)
        {
            var coupon = new Coupon()
            {
                Name = couponModel.Name,
                DiscountPercent = couponModel.DiscountPercent,
                RevenueSharePercent = couponModel.RevenueSharePercent,
                ExpiresOn = couponModel.ExpiresOn,
                Status = couponModel.Status,
                CreatedDateTime = DateTime.Now,
                CustomerId = couponModel.Customer.Id

            };
            var createdCoupon = await CouponRepository.Create(coupon);
            var result = await CouponRepository.GetById(createdCoupon.Id.ToString());
            return result.ToModel();
        }

        // PUT: api/Coupons

        [HttpPost(Name = "Validate")]
        public async Task<bool> Validate([FromBody] ValidateModel validateModel)
        {
            var result = await CouponRepository.IsValid(validateModel.CouponId.ToString(), validateModel.CustomerId.ToString());
            return result;
        }

        // PUT: api/Coupons
        [HttpPost(Name = "Redeem")]
        public async Task<LedgerModel> Redeem([FromBody] RedeemModel redeemModel)
        {
            var coupon = await CouponRepository.Redeem(redeemModel.CouponId.ToString());
            var ledger = new Ledger();
            ledger.Coupon = coupon;
            ledger.OriginalPrice = Math.Round(redeemModel.OriginalPrice, 2);
            ledger.DiscountAmount = Math.Round(redeemModel.OriginalPrice * (coupon.DiscountPercent / 100), 2);
            ledger.SalesAmount = Math.Round(ledger.OriginalPrice - ledger.DiscountAmount, 2);
            ledger.RevenueShareAmount = Math.Round(ledger.SalesAmount * (coupon.RevenueSharePercent / 100), 2);
            ledger.SettlementAmount = Math.Round(ledger.SalesAmount - ledger.RevenueShareAmount, 2);
            ledger.CreatedDateTime = DateTime.Now;
            var result = await LedgerRepository.Create(ledger);
            return result.ToModel();
        }
    }
}
