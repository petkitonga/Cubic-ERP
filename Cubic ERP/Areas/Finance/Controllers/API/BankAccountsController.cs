using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cubic_ERP.Models;

namespace Cubic_ERP.Areas.Finance.Controllers.API
{
    public class BankAccountsController : ApiController
    {
        private ApplicationDbContext _context;

        public BankAccountsController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Get list of bank accounts.
        [Route("finance/api/bankaccounts")]
        public IHttpActionResult GetBankAccounts()
        {

            return Ok(_context.BankAccounts.ToList());
        }
    }
}
