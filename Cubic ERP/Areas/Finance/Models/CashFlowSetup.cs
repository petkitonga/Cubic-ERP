using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cubic_ERP.Areas.Finance.Models
{
    public class CashFlowSetup
    {
        public int Id { get; set; }

        public int CashFlowHeadingId { get; set; }
        public int AccountMasterId { get; set; }

        public CashFlowHeading CashFlowHeading { get; set; }
        public AccountMaster AccountMaster { get; set; }

        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTimeStamp { get; set; }

    }
}