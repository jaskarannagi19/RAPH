using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class LeaveEncashmentEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int LeaveEncashmentID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Type")]
        public string LeaveType { get; set; }

        [DisplayName("Application Date")]
        public DateTime LeaveApplicateDate { get; set; }

        [DisplayName("Prefix")]
        public string LeaveEncashmentNoPrefixName { get; set; }

        [DisplayName("No")]
        public int LeaveEncashmentNo { get; set; }
    }

    public class LeaveEncashmentLookupListModel
    {
        [Browsable(false)]
        public int LeaveEncashmentID { get; set; }

        [Browsable(false)]
        public string LeaveEncashmentNoPrefixName { get; set; }

        [Browsable(false)]
        public int LeaveEncashmentNo { get; set; }

        [DisplayName("No")]
        public string LeaveEncashmentNostr { get { return (LeaveEncashmentNoPrefixName ?? "") + LeaveEncashmentNo.ToString(); } }

        [DisplayName("Application Date")]
        public DateTime LeaveApplicateDate { get; set; }

        [Browsable(false)]
        public string EmployeeNoPrefix { get; set; }


        [Browsable(false)]
        public int EmployeeNo { get; set; }

        [DisplayName("Emp Code")]
        public string EmployeeNoWithPrefix { get { return (EmployeeNoPrefix ?? "") + EmployeeNo.ToString(); } }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }


        [DisplayName("Type")]
        public string LeaveType { get; set; }
    }
}