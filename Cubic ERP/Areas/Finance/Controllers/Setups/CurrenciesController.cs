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
    public class CurrenciesController : Controller
    {
        private ApplicationDbContext _context;

        public CurrenciesController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Finance/Currencies
        public ActionResult Index()
        {
            var currencies = _context.DbCurrencies.ToList();
            return View(currencies);
        }

        public ActionResult New()
        {
            var currenciesDto = new CurrenciesDto
            {
                Id = 0
            };
            var curfViewModel = new CurrencyFormViewModel
            {
                ActionIndicator = 1,
                CurrenciesDto = currenciesDto
            };
            return View("CurrencyForm", curfViewModel);
        }

        public ActionResult Edit(int id)
        {
            var currencyInDb = _context.DbCurrencies.Find(id);
            var cfViewModel = new CurrencyFormViewModel
            {
                ActionIndicator = 2,
                CurrenciesDto = Mapper.Map<Currencies, CurrenciesDto>(currencyInDb)
            };
            return View("CurrencyForm", cfViewModel);
        }

        [HttpPost]
        public ActionResult Save(CurrencyFormViewModel cfViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CurrencyForm", cfViewModel);
            }
            //else everything is fine so we map and save
            if (cfViewModel.CurrenciesDto.Id == 0)//Then it's a new bank account
            {
                var currency = Mapper.Map<CurrenciesDto, Currencies>(cfViewModel.CurrenciesDto);
                _context.DbCurrencies.Add(currency);
                _context.SaveChanges();
            }
            else
            {
                var currencyInDb = _context.DbCurrencies.Find(cfViewModel.CurrenciesDto.Id);
                if (currencyInDb == null)
                {
                    return HttpNotFound();
                }
                Mapper.Map(cfViewModel.CurrenciesDto, currencyInDb);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}