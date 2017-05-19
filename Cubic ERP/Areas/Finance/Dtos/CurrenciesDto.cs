using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cubic_ERP.Areas.Finance.Dtos
{
    public class CurrenciesDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CurrencyCode { get; set; }

        [StringLength(50)]
        public string CurrencySymbol { get; set; }

        [Required]
        [StringLength(50)]
        public string CurrencyName { get; set; }

        [StringLength(50)]
        public string HundredthName { get; set; }
    }
}