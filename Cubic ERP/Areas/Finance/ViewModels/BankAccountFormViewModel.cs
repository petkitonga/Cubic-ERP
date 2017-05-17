using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cubic_ERP.Areas.Finance.Dtos;

namespace Cubic_ERP.Areas.Finance.ViewModels
{
    public class BankAccountFormViewModel
    {
        public int ActionIndicator { get; set; }
        public BankAccountDto BankAccountDto { get; set; }
        public IEnumerable<AccountDto> AccountDtos { get; set; }
    }
}