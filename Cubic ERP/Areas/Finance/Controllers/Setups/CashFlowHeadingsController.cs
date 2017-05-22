using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Cubic_ERP.Areas.Finance.Dtos;
using Cubic_ERP.Areas.Finance.Models;
using Cubic_ERP.Areas.Finance.ViewModels;
using Cubic_ERP.Models;

namespace Cubic_ERP.Areas.Finance.Controllers.Setups
{
    public class CashFlowHeadingsController : Controller
    {
        private ApplicationDbContext _context;

        public CashFlowHeadingsController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Finance/CashFlowHeadings
        public ActionResult Index()
        {
            var cashflowheaders = _context.CashFlowHeadings.ToList();
            return View(cashflowheaders);
        }

        public ActionResult New()
        {
            var cashfh = new CashFlowHeadingDto
            {
                Id = 0
            };
            var cashfhViewModel = new CashFlowHeadingFormViewModel
            {
                ActionIndicator = 1,
                CashFlowHeadingDto = cashfh
            };
            return View("CashFlowHeadingForm", cashfhViewModel);
        }

        public ActionResult Edit(int id)
        {
            var cashfhInDb = _context.CashFlowHeadings.Find(id);
            var cashfhDto = Mapper.Map<CashFlowHeading, CashFlowHeadingDto>(cashfhInDb);

            var cashfhViewModel = new CashFlowHeadingFormViewModel
            {
                ActionIndicator = 2,
                CashFlowHeadingDto = cashfhDto
            };
            return View("CashFlowHeadingForm", cashfhViewModel);
        }

        [HttpPost]
        public ActionResult Save(CashFlowHeadingFormViewModel cashfhViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CashFlowHeadingForm", cashfhViewModel);
            }
            //else everything is super so we go ahead and save or update
            if (cashfhViewModel.CashFlowHeadingDto.Id==0) //means it's new
            {
                var cashfh = Mapper.Map<CashFlowHeadingDto, CashFlowHeading>(cashfhViewModel.CashFlowHeadingDto);
                _context.CashFlowHeadings.Add(cashfh);
                _context.SaveChanges();
            }
            else
            {
                var cashfhInDb = _context.CashFlowHeadings.Find(cashfhViewModel.CashFlowHeadingDto.Id);
                if (cashfhInDb==null)
                {
                    return HttpNotFound();
                }
                Mapper.Map(cashfhViewModel.CashFlowHeadingDto, cashfhInDb);
                _context.SaveChanges();
            }


            return RedirectToAction("Index");
        }
    }
}