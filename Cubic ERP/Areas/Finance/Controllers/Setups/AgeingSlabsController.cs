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
    public class AgeingSlabsController : Controller
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



        // GET: Finance/AgeingSlabs
        public ActionResult Index()
        {
            var ageingSlabsList = _context.AgeingSlabs.ToList();
            return View(ageingSlabsList);
        }

        public ActionResult New()
        {
            var ageingSlab = new AgeingSlab
            {
                Id = 0
            };
            var ageingSViewModel = new AgeingSlabFormViewModel
            {
                ActionIndicator = 1,
                AgeingSlab = ageingSlab
            };
            return View("AgeingSlabForm", ageingSViewModel);
        }

        public ActionResult Edit(int id)
        {
            var ageingslabInDb = _context.AgeingSlabs.Find(id);
            if (ageingslabInDb==null)
            {
                return HttpNotFound();
            }
            var ageingSViewModel = new AgeingSlabFormViewModel
            {
                ActionIndicator = 2,
                AgeingSlab = ageingslabInDb
            };
            return View("AgeingSlabForm", ageingSViewModel);
        }

        [HttpPost]
        public ActionResult Save(AgeingSlabFormViewModel ageingSViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AgeingSlabForm", ageingSViewModel);
            }
            //else we continue
            if (ageingSViewModel.AgeingSlab.Id==0) //then it's a new one
            {
                _context.AgeingSlabs.Add(ageingSViewModel.AgeingSlab);
                _context.SaveChanges();
            }
            else
            {
                var ageingSlabInDb = _context.AgeingSlabs.Find(ageingSViewModel.AgeingSlab.Id);
                if (ageingSlabInDb==null)
                {
                    return HttpNotFound();
                }
                ageingSlabInDb.Name = ageingSViewModel.AgeingSlab.Name;
                ageingSlabInDb.FromDays = ageingSViewModel.AgeingSlab.FromDays;
                ageingSlabInDb.ToDays = ageingSViewModel.AgeingSlab.ToDays;

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}