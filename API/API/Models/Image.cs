//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api.Models
{
    using System;
    using System.Collections.Generic;
    
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
