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
    
    public partial class ProductState
    {
        public ProductState()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int ProductStateId { get; set; }
        public string ProductStatename { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
