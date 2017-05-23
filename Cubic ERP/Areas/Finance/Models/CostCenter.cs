using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cubic_ERP.Areas.Finance.Models
{
    public class CostCenter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public int? AuditUserId { get; set; }
        public DateTimeOffset? AuditTimeStamp { get; set; }
    }
}