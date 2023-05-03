using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class UserGroup
    {
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public string Description { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}