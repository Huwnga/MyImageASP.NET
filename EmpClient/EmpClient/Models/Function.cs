using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Function
    {
        public int FunctionID { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }
    }
}