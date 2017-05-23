using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cubic_ERP.Models;

namespace Cubic_ERP.Areas.Finance.Controllers.API
{
    public class CostCentersController : ApiController
    {
        private ApplicationDbContext _context;

        public CostCentersController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        [HttpGet]
        [Route("finance/api/costcenters")]
        public IHttpActionResult Index()
        {
            return Ok(_context.CostCenters.ToList());
        }

        [HttpDelete]
        [Route("finance/api/costcenters/{id}")]
        public IHttpActionResult DeleteCostCenter(int id)
        {
            var costcenterInDb = _context.CostCenters.Find(id);
            if (costcenterInDb==null)
            {
                return NotFound();
            }
            //else we remove the costcenter
            _context.CostCenters.Remove(costcenterInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
