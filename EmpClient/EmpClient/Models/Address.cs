using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Address
    {
        public int AddessID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        [StringLength(50)]
        [Display(Name = "Address Name")]
        public string AddressName { get; set; }
        [StringLength(255)]
        public string Address1 { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        public virtual Customer Customer { get; set; }
    }
}