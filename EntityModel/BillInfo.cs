//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class BillInfo
    {
        public int Id { get; set; }
        public Nullable<int> IdBill { get; set; }
        public Nullable<int> IdFood { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual Food Food { get; set; }
    }
}
