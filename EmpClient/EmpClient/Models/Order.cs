using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Order
    {
        public int OrderID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> StatusOrderID { get; set; }
        public Nullable<int> PaymentID { get; set; }
        public string Description { get; set; }
        public string ShipAddress { get; set; }
        public Nullable<System.DateTime> OrderAt { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }
    }
}