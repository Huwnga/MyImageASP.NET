using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class ProductSize
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductID { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int SizeID { get; set; }
        [Required]
        [Display(Name = "Unit Price")]
        [Range(1, int.MaxValue)]
        public Nullable<decimal> UnitPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}