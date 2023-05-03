using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Feedback
    {
        public int FeedbackID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string Description { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}