using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReoderLevel { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string ImagePath { get; set; }

        public virtual Category Category { get; set; }
    }
}