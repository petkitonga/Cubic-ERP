using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cubic_ERP.Areas.Finance.Models;

namespace Cubic_ERP.Areas.Finance.ViewModels
{
    public class CostCenterFormViewModel
    {
        public int ActionIndicator { get; set; }
        public CostCenter CostCenter { get; set; }
    }
}