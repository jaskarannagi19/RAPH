using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class LeaveTypeEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int LeaveTypeID { get; set; }

        [DisplayName("Leave Type")]
        public string LeaveTypeName { get; set; }
    }

    public class LeaveTypeLookupListModel
    {
        [Browsable(false)]
        public int LeaveTypeID { get; set; }

        [DisplayName("Leave Type")]
        public string LeaveTypeName { get; set; }

        [Browsable(false)]
        public byte ApplicableTo { get; set; }

        [Browsable(false)]
        public bool Encashable { get; set; }
    }

    public enum eLeaveApplicableTo
    {
        Male = 0,
        Female = 1,
        Both = 2
    }

    public enum eLeaveTypeDistribute
    {
        Yearly = 0,
        Monthly = 1,
    }
}
