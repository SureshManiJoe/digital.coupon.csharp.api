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
    public class LedgerController : ControllerBase
    {
        public ILedgerRepository LedgerRepository { get; set; }
        public LedgerController(ILedgerRepository ledgerRepository)
        {
            LedgerRepository = ledgerRepository;
        }

        [HttpGet(Name = "Get")]
        public async Task<IEnumerable<LedgerModel>> Get()
        {
            var ledger = await LedgerRepository.GetAll();
            if (ledger == null)
                return new List<LedgerModel>();
            return ledger.Select(l => l.ToModel());
        }
    }
}
