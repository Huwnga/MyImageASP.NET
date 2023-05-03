using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class FunctionGroup
    {
        public int FunctionID { get; set; }
        public int GroupID { get; set; }
        public string Description { get; set; }

        public virtual Function Function { get; set; }
        public virtual Group Group { get; set; }
    }
}