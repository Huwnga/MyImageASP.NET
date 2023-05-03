using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public Nullable<int> OrganizationID { get; set; }
        public string PhotoPath { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual Organization Organization { get; set; }
    }
}