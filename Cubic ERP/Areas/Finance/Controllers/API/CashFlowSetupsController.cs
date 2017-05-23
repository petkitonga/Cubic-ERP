using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cubic_ERP.Models;

namespace Cubic_ERP.Areas.Finance.Controllers.API
{
    public class CashFlowSetupsController : ApiController
    {
        private ApplicationDbContext _context;

        public CashFlowSetupsController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //get list of cashflow setups
        [HttpGet]
        [Route("finance/api/cashflowsetups")]
        public IHttpActionResult Index()
        {
            return Ok(_context.CashFlowSetups.
                Include(c=>c.CashFlowHeading).
                Include(c=>c.AccountMaster).ToList());
        }

        //delete cashflow setup
        [HttpDelete]
        [Route("finance/api/cashflowsetups/{id}")]
        public IHttpActionResult DeleteCashFlowSetup(int id)
        {
            var cashfsInDb = _context.CashFlowSetups.Find(id);
            if (cashfsInDb==null)
            {
                return NotFound();
            }
            _context.CashFlowSetups.Remove(cashfsInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
