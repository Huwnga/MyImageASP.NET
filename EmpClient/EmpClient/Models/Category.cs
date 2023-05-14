using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace EmpClient.Models
{
    public partial class Category
    {
        public int CategoryID { get; set; }
        [StringLength(255)]
        [Display(Name = "Product Name")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}