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
    public class AccountsController : ApiController
    {
        private ApplicationDbContext _context;

        public AccountsController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        //get list of accounts
        [HttpGet]
        [Route("finance/api/accounts")]
        public IHttpActionResult GetAccountsList()
        {
            return Ok(_context.Accounts.Include(a => a.AccountMaster).ToList());
        }

        //delete an account
        [HttpDelete]
        [Route("finance/api/accounts/{id}")]
        public IHttpActionResult DeleteAccount(int id)
        {
            var accountInDb = _context.Accounts.Find(id);
            if (accountInDb==null)
            {
                return NotFound();
            }
            _context.Accounts.Remove(accountInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
