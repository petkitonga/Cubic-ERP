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
    public class CostCentersController : Controller
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

        // GET: Finance/CostCenters
        public ActionResult Index()
        {
            var costcenterslist = _context.CostCenters.ToList();
            return View(costcenterslist);
        }


        //Create new cost center
        public ActionResult New()
        {
            var costcenter = new CostCenter
            {
                Id = 0
            };
            var costcenterViewModel = new CostCenterFormViewModel
            {
                ActionIndicator = 1,
                CostCenter = costcenter
            };

            return View("CostCenterForm", costcenterViewModel);
        }

        //edit existing cost center
        public ActionResult Edit(int id)
        {
            var costcenterInDb = _context.CostCenters.Find(id);
            if (costcenterInDb==null)
            {
                return HttpNotFound();
            }

            var costcenterViewModel = new CostCenterFormViewModel
            {
                ActionIndicator = 2,
                CostCenter = costcenterInDb
            };
            return View("CostCenterForm", costcenterViewModel);
        }

        [HttpPost]
        public ActionResult Save(CostCenterFormViewModel costcenterViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CostCenterForm", costcenterViewModel);
            }
            //else we continue with new or update
            if (costcenterViewModel.CostCenter.Id==0)//then we know it's a new cost center
            {
                var costcenter = costcenterViewModel.CostCenter;
                _context.CostCenters.Add(costcenter);
                _context.SaveChanges();
            }
            else
            {
                var costcenterInDb = _context.CostCenters.Find(costcenterViewModel.CostCenter.Id);
                if (costcenterInDb==null)
                {
                    return HttpNotFound();
                }
                costcenterInDb.Code = costcenterViewModel.CostCenter.Code;
                costcenterInDb.Name = costcenterViewModel.CostCenter.Name;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}