using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Cubic_ERP.Areas.Finance.Models;

namespace Cubic_ERP.Areas.Finance.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }

        public int AccountMasterId { get; set; }
        
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
    }
}