using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class CartDetail
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> SizeID { get; set; }
        public Nullable<int> ImageID { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<int> Quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Image Image { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}