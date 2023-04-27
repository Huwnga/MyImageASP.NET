using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public partial class Size
    {
        public int SizeID { get; set; }
        public Nullable<int> MaterialID { get; set; }
        public string SizeName { get; set; }

        public virtual Material Material { get; set; }
    }
}