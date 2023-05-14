using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace EmpClient.Models
{
    public partial class Product
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        [Range(0, 32767)]
        [Display(Name = "Units In Stock")]
        public Nullable<short> UnitsInStock { get; set; }
        [Range(0, 32767)]
        [Display(Name = "Units On Order")]
        public Nullable<short> UnitsOnOrder { get; set; }
        [Range(0, 32767)]
        [Display(Name = "Reoder Level")]
        public Nullable<short> ReoderLevel { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Created At")]
        public Nullable<System.DateTime> CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Updated At")]
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        [StringLength(255)]
        public string ImagePath { get; set; }

        public virtual Category Category { get; set; }
    }
}