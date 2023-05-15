using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Feedback
    {
        public int FeedbackID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProductID { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> CreatedAt { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}