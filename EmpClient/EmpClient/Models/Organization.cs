using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Organization
    {
        public int OrganizationID { get; set; }
        [Display(Name = "Parent Organization")]
        public Nullable<int> ParentID { get; set; }
        [StringLength(255)]
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }
        [StringLength(255)]
        public string Code { get; set; }
        [StringLength(20)]
        public string Address { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(320)]
        public string Email { get; set; }

        public virtual Organization Parent { get; set; }
    }
}