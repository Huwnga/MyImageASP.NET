using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Order
    {
        public int OrderID { get; set; }
        [Required]
        [Display( Name = "Employee" )]
        [Range(1, int.MaxValue)]
        public Nullable<int> EmployeeID { get; set; }
        [Required]
        [Display(Name = "Customer")]
        [Range(1, int.MaxValue)]
        public Nullable<int> CustomerID { get; set; }
        [Required]
        [Display(Name = "StatusOrder")]
        [Range(1, int.MaxValue)]
        public Nullable<int> StatusOrderID { get; set; }
        [Required]
        [Display(Name = "Payment")]
        [Range(1, int.MaxValue)]
        public Nullable<int> PaymentID { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Ship Address")]
        [StringLength(255)]
        public string ShipAddress { get; set; }
        [Display(Name = "Order Date")]
        public Nullable<System.DateTime> OrderAt { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }
    }
}