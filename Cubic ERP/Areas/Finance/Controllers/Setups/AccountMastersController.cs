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
    public class AccountMastersController : Controller
    {
        private ApplicationDbContext _context;

        public AccountMastersController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        // GET: Finance/AccountMasters
        public ActionResult Index()
        {
            var accountMastersList = _context.AccountMasters.ToList();
            return View(accountMastersList);
        }

        //Create a new Account Master
        public ActionResult New()
        {
            var accountMasterDto = new AccountMasterDto
            {
                Id = 0
            };
            var accountMViewModel = new AccountMasterFormViewModel
            {
                ActionIndicator = 1,
                AccountMasterDto = accountMasterDto,
                AccountMasters = _context.AccountMasters.ToList()
            };
            return View("AccountMasterForm", accountMViewModel);
        }

        public ActionResult Edit(int id)
        {
            var accountMasterInDb = _context.AccountMasters.Find(id);
            if (accountMasterInDb==null)
            {
                return HttpNotFound();
            }

            var accountMasterDto = Mapper.Map<AccountMaster, AccountMasterDto>(accountMasterInDb);
            var accountMViewModel = new AccountMasterFormViewModel
            {
                ActionIndicator = 2,
                AccountMasterDto = accountMasterDto,
                AccountMasters = _context.AccountMasters.ToList()
            };

            return View("AccountMasterForm", accountMViewModel);
        }

        [HttpPost]
        public ActionResult Save(AccountMasterFormViewModel accountMViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AccountMasterForm", accountMViewModel);
            }
            //else we continue
            if (accountMViewModel.AccountMasterDto.Id==0)//Then it's a new account master
            {
                var accountMaster = Mapper.Map<AccountMasterDto, AccountMaster>(accountMViewModel.AccountMasterDto);
                _context.AccountMasters.Add(accountMaster);
                _context.SaveChanges();
            }
            else
            {
                var accountMasterInDb = _context.AccountMasters.Find(accountMViewModel.AccountMasterDto.Id);
                if (accountMasterInDb==null)
                {
                    return HttpNotFound();
                }
                Mapper.Map(accountMViewModel.AccountMasterDto, accountMasterInDb);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}