using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cubic_ERP.Models;

namespace Cubic_ERP.Areas.Finance.Controllers.API
{
    public class CashFlowHeadingsController : ApiController
    {
        private ApplicationDbContext _context;

        public CashFlowHeadingsController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Get list of cash flow headings
        [Route("finance/api/cashflowheadings")]
        public IHttpActionResult Index()
        {
            return Ok(_context.CashFlowHeadings.ToList());
        }

        // Delete a cashflow heading
        [HttpDelete]
        [Route("finance/api/cashflowheadings/{id}")]
        public IHttpActionResult DeleteCashFlowHeading(int id)
        {
            var cashfhInDb = _context.CashFlowHeadings.Find(id);
            if (cashfhInDb==null)
            {
                return NotFound();
            }
            _context.CashFlowHeadings.Remove(cashfhInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
