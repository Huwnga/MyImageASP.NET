using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class User
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please enter your username!")]
        [StringLength(50)]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your password!")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$", ErrorMessage = "Password have at least 1 uppercase, 1 lowercase, 1 number and minimum is 8 letter!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please choose a Employee!")]
        [Range(1, int.MaxValue, ErrorMessage = "Please choose a Employee!")]
        public Nullable<int> EmployeeID { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        public virtual Employee Employee { get; set; }
    }
}