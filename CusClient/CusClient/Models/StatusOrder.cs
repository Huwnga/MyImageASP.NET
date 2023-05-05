using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CusClient.Models
{
    public partial class StatusOrder
    {
        public int StatusOrderID { get; set; }
        public string StatusOrderName { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}