using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cubic_ERP.Areas.Finance.Dtos;

namespace Cubic_ERP.Areas.Finance.ViewModels
{
    public class CashFlowHeadingFormViewModel
    {
        public int ActionIndicator { get; set; }
        public CashFlowHeadingDto CashFlowHeadingDto { get; set; }
    }
}