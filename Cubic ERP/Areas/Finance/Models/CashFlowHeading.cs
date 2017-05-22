using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cubic_ERP.Areas.Finance.Models
{
    public class CashFlowHeading
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string CashFlowHeadingCode { get; set; }

        [Required]
        [StringLength(255)]
        public string CashFlowHeadingName { get; set; }

        [Required]
        [StringLength(1)]
        public string CashFlowHeadingType { get; set; }

        public bool IsDebit { get; set; }
        public bool IsSales { get; set; }
        public bool IsPurchase { get; set; }

        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTimeStamp { get; set; }
        public bool? Deleted { get; set; }
    }
}