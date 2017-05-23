using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cubic_ERP.Models;

namespace Cubic_ERP.Areas.Finance.Controllers.API
{
    public class CardTypesController : ApiController
    {
        private ApplicationDbContext _context;

        public CardTypesController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //get list of card types
        [HttpGet]
        [Route("finance/api/cardtypes")]
        public IHttpActionResult GetCardTypesList()
        {
            return Ok(_context.CardTypes.ToList());
        }


        //delete a card type
        [HttpDelete]
        [Route("finance/api/cardtypes/{id}")]
        public IHttpActionResult DeleteCardType(int id)
        {
            var cardTypeInDb = _context.CardTypes.Find(id);
            if (cardTypeInDb==null)
            {
                return NotFound();
            }
            _context.CardTypes.Remove(cardTypeInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
