using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Cart
    {
        public int CartID { get; set; }
        public Nullable<int> CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}