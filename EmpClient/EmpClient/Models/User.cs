using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string Description { get; set; }

        public virtual Employee Employee { get; set; }
    }
}