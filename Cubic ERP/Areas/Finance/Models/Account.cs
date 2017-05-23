using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cubic_ERP.Areas.Finance.Models
{
    public class Account
    {
        public int Id { get; set; }

        public int AccountMasterId { get; set; }
        public AccountMaster AccountMaster { get; set; }

        [StringLength(50)]
        [Required]
        public string AccountNumber { get; set; }

        [StringLength(50)]
        public string ExternalCode { get; set; }

        [Required]
        [StringLength(50)]
        public string CurrencyCode { get; set; }

        [Required]
        [StringLength(255)]
        public string AccountName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }


        public bool Confidential { get; set; }
        public bool IsTransactionNode { get; set; }
        public bool SysType { get; set; }

        public int? ParentAccountId { get; set; }


        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTimeStamp { get; set; }
        public bool? Deleted { get; set; }
    }
}