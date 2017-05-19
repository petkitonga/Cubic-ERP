using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cubic_ERP.Areas.Finance.Dtos;

namespace Cubic_ERP.Areas.Finance.ViewModels
{
    public class CurrencyFormViewModel
    {
        public int ActionIndicator { get; set; }
        public CurrenciesDto CurrenciesDto { get; set; }
    }
}