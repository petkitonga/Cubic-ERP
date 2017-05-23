using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class AccountsController : Controller
    {
        private ApplicationDbContext _context;

        public AccountsController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Finance/Accounts
        public ActionResult Index()
        {
            var accountsList = _context.Accounts.Include(a=>a.AccountMaster).ToList();
            return View(accountsList);
        }

        public ActionResult New()
        {
            var accountDto = new AccountDto
            {
                Id = 0
            };

            var accountsViewModel = new AccountFormViewModel
            {
                ActionIndicator = 1,
                AccountDto = accountDto,
                AccountMasters = _context.AccountMasters.ToList(),
                Accounts = _context.Accounts.ToList(),
                Currencies = _context.DbCurrencies.ToList()
            };
            return View("AccountForm", accountsViewModel);
        }

        public ActionResult Edit(int id)
        {
            var accountInDb = _context.Accounts.Find(id);
            var accountDto = Mapper.Map<Account, AccountDto>(accountInDb);

            var accountViewModel = new AccountFormViewModel
            {
                ActionIndicator = 2,
                AccountDto = accountDto,
                AccountMasters = _context.AccountMasters.ToList(),
                Accounts = _context.Accounts.ToList(),
                Currencies = _context.DbCurrencies.ToList()
            };

            return View("AccountForm", accountViewModel);
        }

        [HttpPost]
        public ActionResult Save(AccountFormViewModel accountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AccountForm", accountViewModel);
            }
            //else continue with new or update account
            if (accountViewModel.AccountDto.Id==0)//means it's new
            {
                var account = Mapper.Map<AccountDto, Account>(accountViewModel.AccountDto);
                _context.Accounts.Add(account);
                _context.SaveChanges();
            }
            else
            {
                var accountInDb = _context.Accounts.Find(accountViewModel.AccountDto.Id);
                if (accountInDb==null)
                {
                    return HttpNotFound();
                }
                Mapper.Map(accountViewModel.AccountDto, accountInDb);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}