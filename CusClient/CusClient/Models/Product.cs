using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CusClient.Models
{
    public partial class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> MaterialID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReoderLevel { get; set; }

        public virtual Category Category { get; set; }
        public virtual Material Material { get; set; }
    }
}