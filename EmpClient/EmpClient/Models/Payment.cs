using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Payment
    {
        public int PaymentID { get; set; }
        [Required]
        [Display(Name = "Payment Name")]
        [StringLength(255)]
        public string PaymentName { get; set; }
    }
}