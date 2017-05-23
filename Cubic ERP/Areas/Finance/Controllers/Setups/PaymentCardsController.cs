using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cubic_ERP.Areas.Finance.Models;
using Cubic_ERP.Areas.Finance.ViewModels;
using Cubic_ERP.Models;

namespace Cubic_ERP.Areas.Finance.Controllers.Setups
{
    public class PaymentCardsController : Controller
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

        
        // GET: Finance/PaymentCards
        public ActionResult Index()
        {
            var paymentCardsList = _context.PaymentCards.Include(p=>p.CardType).ToList();
            return View(paymentCardsList);
        }

        //create new payment card
        public ActionResult New()
        {
            var paymentCard = new PaymentCard
            {
                Id = 0
            };

            var paymentCardViewModel = new PaymentCardFormViewModel
            {
                ActionIndicator = 1,
                PaymentCard = paymentCard,
                CardTypes = _context.CardTypes.ToList()
            };
            return View("PaymentCardForm", paymentCardViewModel);
        }

        public ActionResult Edit(int id)
        {
            var paymentCardInDb = _context.PaymentCards.Find(id);
            if (paymentCardInDb==null)
            {
                return HttpNotFound();
            }
            var paymentCardViewModel = new PaymentCardFormViewModel
            {
                ActionIndicator = 2,
                PaymentCard = paymentCardInDb,
                CardTypes = _context.CardTypes.ToList()
            };
            return View("PaymentCardForm", paymentCardViewModel);
        }

        [HttpPost]
        public ActionResult Save(PaymentCardFormViewModel paymentCardViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("PaymentCardForm", paymentCardViewModel);
            }
            //check if it's a new payment card
            if (paymentCardViewModel.PaymentCard.Id==0)
            {
                var paymentCard = paymentCardViewModel.PaymentCard;
                _context.PaymentCards.Add(paymentCard);
                _context.SaveChanges();
            }
            else
            {
                var paymentCardInDb = _context.PaymentCards.Find(paymentCardViewModel.PaymentCard.Id);
                if (paymentCardInDb==null)
                {
                    return HttpNotFound();
                }
                paymentCardInDb.Code = paymentCardViewModel.PaymentCard.Code;
                paymentCardInDb.Name = paymentCardViewModel.PaymentCard.Name;
                paymentCardInDb.CardTypeId = paymentCardViewModel.PaymentCard.CardTypeId;

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}