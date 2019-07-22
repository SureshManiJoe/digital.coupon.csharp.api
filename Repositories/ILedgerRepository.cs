using DigitalCouponApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCouponApi.Repositories
{
    public interface ILedgerRepository 
    {
        Task<IEnumerable<Ledger>> GetAll();
        Task<Ledger> Create(Ledger ledger);
    }
}
