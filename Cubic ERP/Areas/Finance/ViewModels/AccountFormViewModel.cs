using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cubic_ERP.Areas.Finance.Dtos;
using Cubic_ERP.Areas.Finance.Models;

namespace Cubic_ERP.Areas.Finance.ViewModels
{
    public class AccountFormViewModel
    {
        public int ActionIndicator { get; set; }
        public AccountDto AccountDto { get; set; }
        public IEnumerable<AccountMaster> AccountMasters { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Currencies> Currencies { get; set; }
    }
}