using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cubic_ERP.Areas.Finance.Models;
using Cubic_ERP.Areas.Finance.ViewModels;
using Cubic_ERP.Models;

namespace Cubic_ERP.Areas.Finance.Controllers.Setups
{
    public class CardTypesController : Controller
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


        // GET: Finance/CardTypes
        public ActionResult Index()
        {
            var cardtypeslist = _context.CardTypes.ToList();
            return View(cardtypeslist);
        }

        public ActionResult New()
        {
            var cardType = new CardType
            {
                Id = 0
            };

            var cardTypeViewModel = new CardTypeFormViewModel
            {
                ActionIndicator = 1,
                CardType = cardType
            };
            return View("CardTypeForm", cardTypeViewModel);
        }

        public ActionResult Edit(int id)
        {
            var cardTypeInDb = _context.CardTypes.Find(id);
            if (cardTypeInDb==null)
            {
                return HttpNotFound();
            }

            var cardtypeViewModel = new CardTypeFormViewModel
            {
                ActionIndicator = 2,
                CardType = cardTypeInDb
            };

            return View("CardTypeForm", cardtypeViewModel);
        }

        [HttpPost]
        public ActionResult Save(CardTypeFormViewModel cardTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CardTypeForm", cardTypeViewModel);
            }
            //else check if it's a new card type
            if (cardTypeViewModel.CardType.Id==0)
            {
                var cardType = cardTypeViewModel.CardType;
                _context.CardTypes.Add(cardType);
                _context.SaveChanges();
            }
            else
            {
                var cardTypeInDb = _context.CardTypes.Find(cardTypeViewModel.CardType.Id);
                if (cardTypeInDb==null)
                {
                    return HttpNotFound();
                }
                cardTypeInDb.Code = cardTypeViewModel.CardType.Code;
                cardTypeInDb.Name = cardTypeViewModel.CardType.Name;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}