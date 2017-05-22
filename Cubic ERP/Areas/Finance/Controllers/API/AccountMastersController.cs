using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cubic_ERP.Models;

namespace Cubic_ERP.Areas.Finance.Controllers.API
{
    public class AccountMastersController : ApiController
    {
        private ApplicationDbContext _context;

        public AccountMastersController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        //Get list of account masters
        [Route("finance/api/accountmasters")]
        public IHttpActionResult Index()
        {
            return Ok(_context.AccountMasters.ToList());
        }

        //Delete Account Master
        [HttpDelete]
        [Route("finance/api/accountmasters/{id}")]
        public IHttpActionResult DeleteAccountMaster(int id)
        {
            var accountMasterInDb = _context.AccountMasters.Find(id);
            if (accountMasterInDb==null)
            {
                return NotFound();
            }
            _context.AccountMasters.Remove(accountMasterInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
