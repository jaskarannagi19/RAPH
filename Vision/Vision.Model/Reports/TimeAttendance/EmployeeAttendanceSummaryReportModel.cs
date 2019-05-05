using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class EmployeeAttendanceSummaryReportModel
    {
        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        public string EmployeeName { get; set; }

        [DisplayName("P")]
        public decimal Present { get; set; }

        [DisplayName("A")]
        public decimal Absent { get; set; }

        [DisplayName("W")]
        public decimal Weekends { get; set; }

        [DisplayName("WW")]
        public decimal WeekendsWorked { get; set; }


        [DisplayName("R")]
        public decimal RestDay { get; set; }

        [DisplayName("RW")]
        public decimal RestDayWorked { get; set; }


        [DisplayName("H")]
        public decimal Holidays { get; set; }

        [DisplayName("HW")]
        public decimal HolidaysWorked { get; set; }

        [DisplayName("L")]
        public decimal Leave { get; set; }

        [DisplayName("S")]
        public decimal Safari { get; set; }

        [DisplayName("Total")]
        public decimal TotalDays { get { return Present + Absent + Weekends + WeekendsWorked + RestDay + RestDayWorked + Holidays + HolidaysWorked + Leave + Safari; } }
    }
}
