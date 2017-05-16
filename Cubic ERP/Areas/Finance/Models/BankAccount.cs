using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cubic_ERP.Areas.Finance.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int? MaintainedByUserId { get; set; }
        public bool IsMerchantAccount { get; set; }
        public int? OfficeId { get; set; }

        [StringLength(128)]
        public string BankName { get; set; }

        [StringLength(128)]
        public string BankBranch { get; set; }

        [StringLength(128)]
        public string BankContactNumber { get; set; }

        [StringLength(128)]
        public string BankAccountNumber { get; set; }

        [StringLength(128)]
        public string BankAccountType { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Cell { get; set; }

        [StringLength(128)]
        public string RelationshipOfficerName { get; set; }
        [StringLength(128)]
        public string RelationshipOfficerContactNumber { get; set; }


        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTimeStamp { get; set; }
        public bool? Deleted { get; set; }
    }
}