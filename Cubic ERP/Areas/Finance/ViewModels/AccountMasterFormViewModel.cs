using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cubic_ERP.Areas.Finance.Dtos;
using Cubic_ERP.Areas.Finance.Models;

namespace Cubic_ERP.Areas.Finance.ViewModels
{
    public class AccountMasterFormViewModel
    {
        public int ActionIndicator { get; set; }
        public AccountMasterDto AccountMasterDto { get; set; }

        public IEnumerable<AccountMaster> AccountMasters { get; set; }
    }
}