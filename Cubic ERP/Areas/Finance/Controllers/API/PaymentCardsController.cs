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
    public class PaymentCardsController : ApiController
    {
        private ApplicationDbContext _context;

        public PaymentCardsController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //get list of payment cards
        [HttpGet]
        [Route("finance/api/paymentcards")]
        public IHttpActionResult GetPaymentCards()
        {
            return Ok(_context.PaymentCards.Include(p=>p.CardType).ToList());
        }

        //delete a payment card
        [HttpDelete]
        [Route("finance/api/paymentcards/{id}")]
        public IHttpActionResult DeletePaymentCard(int id)
        {
            var paymentCardInDb = _context.PaymentCards.Find(id);
            if (paymentCardInDb==null)
            {
                return NotFound();
            }
            _context.PaymentCards.Remove(paymentCardInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
