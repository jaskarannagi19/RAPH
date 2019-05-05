using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class EmployeeAttendanceDetailReportModel
    {
        [Browsable(false)]
        public int EmployeeID { get; set; }

        [Display(Name = "E. Prefix", Order = 0)]
        public string EmployeeNoPrefix { get; set; }

        [Display(Name = "Emp Code", Order = 1)]
        public int EmployeeNo { get; set; }

        [Display(Name = "Employee Name", Order = 2)]
        public string EmployeeName { get; set; }

        public List<Payroll.EmployeeAttendanceViewModel> AttendanceDetail { get; set; }

        public decimal Present { get; set; }
        public decimal Absent { get; set; }
        public decimal Weekend { get; set; }
        public decimal WeekendWorked { get; set; }
        public decimal RestDay { get; set; }
        public decimal RestDayWorked { get; set; }
        public decimal Holiday { get; set; }
        public decimal HolidayWorked { get; set; }
        public decimal Leave { get; set; }
        public decimal Safari { get; set; }
        public decimal Total { get { return Present + Absent + Weekend + WeekendWorked + RestDay + RestDayWorked + Holiday + HolidayWorked + Leave + Safari; } }

    }
}
