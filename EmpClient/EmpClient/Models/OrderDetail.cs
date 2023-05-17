using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> SizeID { get; set; }
        public Nullable<int> ImageID { get; set; }
        [Display(Name = "Unit Price")]
        public Nullable<decimal> UnitPrice { get; set; }
        [Display(Name = "Item(s)")]
        [Range(0, int.MaxValue)]
        public Nullable<int> Quantity { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public Nullable<int> MaterialID { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        public virtual Image Image { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
        public virtual Material Material { get; set; }
    }
}