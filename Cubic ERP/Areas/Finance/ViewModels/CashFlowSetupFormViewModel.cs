using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cubic_ERP.Areas.Finance.Models;

namespace Cubic_ERP.Areas.Finance.ViewModels
{
    public class CashFlowSetupFormViewModel
    {
        public int ActionIndicator { get; set; }
        public CashFlowSetup CashFlowSetup { get; set; }

        public IEnumerable<AccountMaster> AccountMasters { get; set; }
        public IEnumerable<CashFlowHeading> CashFlowHeadings { get; set; }
    }
}