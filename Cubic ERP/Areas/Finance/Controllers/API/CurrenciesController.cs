using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cubic_ERP.Models;

namespace Cubic_ERP.Areas.Finance.Controllers.API
{
    public class CurrenciesController : ApiController
    {
        private ApplicationDbContext _context;

        public CurrenciesController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get list of currencies
        [Route("finance/api/currencies")]
        public IHttpActionResult GetCurrencies()
        {
            return Ok(_context.DbCurrencies.ToList());
        }

        //Delete Currency
        [Route("finance/api/currencies/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteCurrency(int id)
        {
            var currency = _context.DbCurrencies.Find(id);
            if (currency==null)
            {
                return NotFound();
            }

            _context.DbCurrencies.Remove(currency);
            _context.SaveChanges();
            return Ok();
        }

    }
}
