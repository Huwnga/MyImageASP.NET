using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Size
    {
        public int SizeID { get; set; }
        [Required]
        [StringLength(255)]
        public string SizeName { get; set; }
    }
}