using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Employee;
using Vision.Model.Settings;

namespace Vision.Model.Reports.Employee
{
    public class EmployeeMinimumWagesReport
    {
        [Browsable(false)]
        public int? EmployeeID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        public string EmployeeName { get; set; }

        public string Designation { get; set; }
        public string Location { get; set; }
      
        public string Category { get; set; }

        public decimal BasicSalary { get; set; }
        public decimal MinWagesSal { get; set; }
        public decimal Variance { get  { return (BasicSalary-MinWagesSal); } }

        [Browsable(false)]
        public eLocationType LocationTypeID { get; set; }

        public string LocationType
        {
            get
            {
                if (LocationTypeID == eLocationType.Rural)
                {
                    return "Rural";
                }
                else
                {
                    return "Urban";
                }
            }
        }

        [Browsable(false)]
        public eEmploymentType EmployementTypeID { get; set; }

        [DisplayName("Employement Type")]
        public string EmployementType
        {
            get
            {
                switch (EmployementTypeID)
                {
                    case eEmploymentType.Casual:
                        return "Casual";
                    case eEmploymentType.Contract:
                        return "Contract";
                    case eEmploymentType.Permanent:
                        return "Permanent";
                    default:
                        return "N/A";
                }
            }
        }

    }
}
