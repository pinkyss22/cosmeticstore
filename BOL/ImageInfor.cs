//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ImageInfor
    {
        public int ImageInforId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string ImagePath { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
