//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vision.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblGridLayout
    {
        public int GridLayoutID { get; set; }
        public Nullable<int> GridID { get; set; }
        public string Descr { get; set; }
        public string Layout { get; set; }
        public string PrintOptions { get; set; }
        public string PageSettings { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> FinPerID { get; set; }
        public byte rstate { get; set; }
        public Nullable<int> rcuid { get; set; }
        public Nullable<System.DateTime> rcdt { get; set; }
        public Nullable<int> reuid { get; set; }
        public Nullable<System.DateTime> redt { get; set; }
    
        public virtual tblCompany tblCompany { get; set; }
        public virtual tblFinPeriod tblFinPeriod { get; set; }
    }
}
