using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cubic_ERP.Areas.Finance.Models
{
    public class AccountMaster
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool NormallyDebit { get; set; }

        public int? ParentAccountMaster { get; set; }
    }
}