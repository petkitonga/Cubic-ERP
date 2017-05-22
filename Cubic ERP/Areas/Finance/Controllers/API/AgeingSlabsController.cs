using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cubic_ERP.Models;

namespace Cubic_ERP.Areas.Finance.Controllers.API
{
    public class AgeingSlabsController : ApiController
    {
        private ApplicationDbContext _context;

        public AgeingSlabsController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get list of Ageing Slabs
        [Route("finance/api/ageingslabs")]
        public IHttpActionResult Index()
        {
            return Ok(_context.AgeingSlabs.ToList());
        }

        //Delete an ageing slab
        [HttpDelete]
        [Route("finance/api/ageingslabs/{id}")]
        public IHttpActionResult DeleteAgeingSlab(int id)
        {
            var ageingSlabInDb = _context.AgeingSlabs.Find(id);
            if (ageingSlabInDb==null)
            {
                return NotFound();
            }
            _context.AgeingSlabs.Remove(ageingSlabInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
