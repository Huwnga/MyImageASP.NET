using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class StatusOrder
    {
        public int StatusOrderID { get; set; }
        [Display(Name = "Status Order Name")]
        public string StatusOrderName { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Created At")]
        public Nullable<System.DateTime> CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Updated At")]
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}