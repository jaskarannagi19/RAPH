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
    
    public partial class tblEmployementTerminationCause
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEmployementTerminationCause()
        {
            this.tblEmployeeServiceDetails = new HashSet<tblEmployeeServiceDetail>();
        }
    
        public byte EmployementTerminationCauseID { get; set; }
        public string EmployementTerminationCauseName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmployeeServiceDetail> tblEmployeeServiceDetails { get; set; }
    }
}
