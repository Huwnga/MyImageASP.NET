using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Customer
    {
        public int CustomerID { get; set; }
        [StringLength(50)]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(30)]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        [StringLength(30)]
        [Display(Name = "Contact Title")]
        public string ContactTitle { get; set; }
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(320)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}