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
    
    public partial class expenseTable
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual userTable userTable { get; set; }
    }
}
