//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PennyWise
{
    using System;
    using System.Collections.Generic;
    
    public partial class plannerTable
    {
        public int plannerID { get; set; }
        public int userID { get; set; }
        public System.DateTime date_start { get; set; }
        public System.DateTime date_end { get; set; }
        public decimal allowance { get; set; }
        public decimal savings_goal { get; set; }
        public decimal needs_amount { get; set; }
        public decimal wants_amount { get; set; }
        public decimal funds_amount { get; set; }
        public double needs_percentage { get; set; }
        public double wants_percentage { get; set; }
        public double funds_percentage { get; set; }
    
        public virtual userTable userTable { get; set; }
    }
}
