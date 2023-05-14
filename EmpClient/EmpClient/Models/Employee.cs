using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(25)]
        [Display(Name = "Title Of Courtesy")]
        public string TitleOfCourtesy { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Birth Date")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Hire Date")]
        public Nullable<System.DateTime> HireDate { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(59)]
        public string Mobile { get; set; }
        [DataType(DataType.EmailAddress)]
        [StringLength(320)]
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        [StringLength(255)]
        public string Notes { get; set; }
        [Display(Name = "Manager")]
        public Nullable<int> ManagerID { get; set; }
        [Display(Name = "Organization")]
        public Nullable<int> OrganizationID { get; set; }
        [StringLength(255)]
        public string PhotoPath { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual Organization Organization { get; set; }
    }
}