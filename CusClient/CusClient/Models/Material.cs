﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CusClient.Models
{
    public partial class Material
    {
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}