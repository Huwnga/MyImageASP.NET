using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpClient.Models
{
    public partial class Image
    {
        public int ImageID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ImageName { get; set; }
        public Nullable<int> ImageSize { get; set; }
        public string ImagePath { get; set; }
        public string ImageType { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }

        public virtual Product Product { get; set; }
    }
}