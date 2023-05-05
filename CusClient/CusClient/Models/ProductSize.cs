using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CusClient.Models
{
    public class ProductSize
    {
        public int ProductID { get; set; }
        public int SizeID { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}