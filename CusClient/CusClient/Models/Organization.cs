using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CusClient.Models
{
    public partial class Organization
    {
        public int OrganizationID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string OrganizationName { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public virtual Organization Parent { get; set; }
    }
}