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
    public class CashFlowSetupController : Controller
    {
        private ApplicationDbContext _context;

        public CashFlowSetupController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get list of cash flow setups
        public ActionResult Index()
        {
            var cashfs = _context.CashFlowSetups.Include(c => c.CashFlowHeading)
                .Include(c => c.AccountMaster)
                .ToList();
            return View(cashfs);
        }

        //create new cash flow setup
        public ActionResult New()
        {
            var cashfs = new CashFlowSetup
            {
                Id = 0
            };
            var cashfsViewModel = new CashFlowSetupFormViewModel
            {
                ActionIndicator = 1,
                AccountMasters = _context.AccountMasters.ToList(),
                CashFlowHeadings = _context.CashFlowHeadings.ToList(),
                CashFlowSetup = cashfs
            };
            return View("CashFlowSetupForm",cashfsViewModel);
        }


        //edit existing cash flow setup
        public ActionResult Edit(int id)
        {
            var cashfsInDb = _context.CashFlowSetups.Find(id);
            var cashfsViewModel = new CashFlowSetupFormViewModel
            {
                ActionIndicator = 2,
                AccountMasters = _context.AccountMasters.ToList(),
                CashFlowHeadings = _context.CashFlowHeadings.ToList(),
                CashFlowSetup = cashfsInDb
            };
            return View("CashFlowSetupForm", cashfsViewModel);
        }

        //save cashflowsetup
        [HttpPost]
        public ActionResult Save(CashFlowSetupFormViewModel cashfsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CashFlowSetupForm", cashfsViewModel);
            }
            //else continue with new or edit
            if (cashfsViewModel.CashFlowSetup.Id==0) //means it's a new one
            {
                var cashfs = cashfsViewModel.CashFlowSetup;
                _context.CashFlowSetups.Add(cashfs);
                _context.SaveChanges();
            }
            else
            {
                var cashfsInDb = _context.CashFlowSetups.Find(cashfsViewModel.CashFlowSetup.Id);
                if (cashfsInDb==null)
                {
                    return HttpNotFound();
                }
                cashfsInDb.AccountMasterId = cashfsViewModel.CashFlowSetup.AccountMasterId;
                cashfsInDb.CashFlowHeadingId = cashfsViewModel.CashFlowSetup.CashFlowHeadingId;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}