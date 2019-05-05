using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class EmployeeRestDayViewModel
    {
        public EmployeeRestDayViewModel()
        {
            RestDayDetailDataSource = new EmployeeRestDayDetailViewModel[7];
            for(int ri = 0; ri < RestDayDetailDataSource.Count(); ri++)
            {
                RestDayDetailDataSource[ri] = new EmployeeRestDayDetailViewModel()
                {
                    Day = (DayOfWeek)(ri >= 6 ? 0 : ri + 1),
                    RestDay = false,
                };
            }
        }

        [Browsable(false)]
        public EmployeeRestDayDetailViewModel[] RestDayDetailDataSource { get; set; }

        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Monday")]
        public bool Monday { get { return RestDayDetailDataSource[0].RestDay; } set { RestDayDetailDataSource[0].RestDay = value; } }

        [DisplayName("Tuesday")]
        public bool Tuesday { get { return RestDayDetailDataSource[1].RestDay; } set { RestDayDetailDataSource[1].RestDay = value; } }

        [DisplayName("Wednesday")]
        public bool Wednesday { get { return RestDayDetailDataSource[2].RestDay; } set { RestDayDetailDataSource[2].RestDay = value; } }

        [DisplayName("Thursday")]
        public bool Thursday { get { return RestDayDetailDataSource[3].RestDay; } set { RestDayDetailDataSource[3].RestDay = value; } }

        [DisplayName("Friday")]
        public bool Friday { get { return RestDayDetailDataSource[4].RestDay; } set { RestDayDetailDataSource[4].RestDay = value; } }

        [DisplayName("Saturday")]
        public bool Saturday { get { return RestDayDetailDataSource[5].RestDay; } set { RestDayDetailDataSource[5].RestDay = value; } }

        [DisplayName("Sunday")]
        public bool Sunday { get { return RestDayDetailDataSource[6].RestDay; } set { RestDayDetailDataSource[6].RestDay = value; } }
    }

    public class EmployeeRestDayDetailViewModel
    {
        public DayOfWeek Day { get; set; }

        public bool RestDay { get; set; }
    }

    public class EmployeeRestDayEditDetailModel
    {
        public int EmployeeID { get; set; }

        public DayOfWeek RestDay { get; set; }
    }
}
