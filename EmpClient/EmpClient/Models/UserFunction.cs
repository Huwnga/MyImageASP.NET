using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class UserFunction
    {
        public int UserID { get; set; }
        public int FunctionID { get; set; }
        public string Description { get; set; }

        public virtual Function Function { get; set; }
        public virtual User User { get; set; }
    }
}