using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Material
    {
        public int MaterialID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string MaterialName { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }

        public virtual Product Product { get; set; }
    }
}