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
    public class BankAccountsController : Controller
    {
        private ApplicationDbContext _context;

        public BankAccountsController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Finance/BankAccounts
        public ActionResult Index()
        {
            var bankAccounts = _context.BankAccounts.ToList();
            return View(bankAccounts);
        }

        public ActionResult New()
        {
            var bankAccountDto = new BankAccountDto
            {
                Id = 0
            };
            var baViewModel = new BankAccountFormViewModel
            {
                ActionIndicator = 1,
                BankAccountDto = bankAccountDto,
                AccountDtos = _context.Accounts.ToList().Select(Mapper.Map<Account, AccountDto>)
            };
            return View("BankAccountForm", baViewModel);
        }

        public ActionResult Edit(int id)
        {
            var bankAccountInDb = _context.BankAccounts.Find(id);
            var bankAccountDto = Mapper.Map<BankAccount, BankAccountDto>(bankAccountInDb);
            var bafViewModel = new BankAccountFormViewModel
            {
                ActionIndicator = 2,
                BankAccountDto = bankAccountDto,
                AccountDtos = _context.Accounts.ToList().Select(Mapper.Map<Account, AccountDto>)
            };
            return View("BankAccountForm",bafViewModel);
        }

        [HttpPost]
        public ActionResult Save(BankAccountFormViewModel bafViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("BankAccountForm", bafViewModel);
            }
            //else everything is fine so we map and save
            if (bafViewModel.BankAccountDto.Id==0)//Then it's a new bank account
            {
                var bankaccount = Mapper.Map<BankAccountDto, BankAccount>(bafViewModel.BankAccountDto);
                _context.BankAccounts.Add(bankaccount);
                _context.SaveChanges();
            }else{
                var bankaccountInDb = _context.BankAccounts.Find(bafViewModel.BankAccountDto.Id);
                if (bankaccountInDb==null)
                {
                    return HttpNotFound();
                }
                Mapper.Map(bafViewModel.BankAccountDto, bankaccountInDb);
                _context.SaveChanges();
            }
           
            return RedirectToAction("Index");
        }
    }
}