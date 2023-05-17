using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace EmpClient.Models
{
    public partial class Material
    {
        public int MaterialID { get; set; }
        public Nullable<int> ProductID { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Material Name")]
        public string MaterialName { get; set; }
        [Display(Name = "Created At")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> CreatedAt { get; set; }
        [Display(Name = "Updated At")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> UpdatedAt { get; set; }

        public virtual Product Product { get; set; }
    }
}