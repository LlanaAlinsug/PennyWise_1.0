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
    
    public partial class loginTable
    {
        public int loginID { get; set; }
        public int userID { get; set; }
        public System.DateTime login_date { get; set; }
        public System.TimeSpan login_time { get; set; }
        public Nullable<System.DateTime> logout_date { get; set; }
        public Nullable<System.TimeSpan> logout_time { get; set; }
    
        public virtual userTable userTable { get; set; }
    }
}
