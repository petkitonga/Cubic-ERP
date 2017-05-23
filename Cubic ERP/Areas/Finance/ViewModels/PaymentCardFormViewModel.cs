using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cubic_ERP.Areas.Finance.Models;

namespace Cubic_ERP.Areas.Finance.ViewModels
{
    public class PaymentCardFormViewModel
    {
        public int ActionIndicator { get; set; }
        public PaymentCard PaymentCard { get; set; }

        public IEnumerable<CardType> CardTypes { get; set; }
    }
}