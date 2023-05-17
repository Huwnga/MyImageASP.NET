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
        [StringLength(50)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        [StringLength(255)]
        public string PicturePath { get; set; }
    }
}