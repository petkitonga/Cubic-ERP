using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cubic_ERP.Areas.Finance.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        
        [StringLength(255)]
        public string AccountName { get; set; }
    }
}