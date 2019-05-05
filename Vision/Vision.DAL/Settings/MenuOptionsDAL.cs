using Vision.Model.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL.Settings
{
    public class MenuOptionsDAL
    {
        public List<MenuOptionsViewModel> GetMenus()
        {
            List<MenuOptionsViewModel> res = new List<MenuOptionsViewModel>();
            
            //Settings
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 1001, MenuOptionName = "Company Profile", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 1002, MenuOptionName = "Financial Period", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 1003, MenuOptionName = "Users", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 1004, MenuOptionName = "User Group", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 1005, MenuOptionName = "Settings", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.Normal });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 1006, MenuOptionName = "Biometric Devices", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 1007, MenuOptionName = "Location", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 1008, MenuOptionName = "Tax Slab", MenuOptionGroupName = "Settings", MenuType = eMenuOptionType.CRUD });

            // Others
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 2001, MenuOptionName = "City / Town", MenuOptionGroupName = "Others", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 2002, MenuOptionName = "State / Region", MenuOptionGroupName = "Others", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 2003, MenuOptionName = "Country", MenuOptionGroupName = "Others", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 2004, MenuOptionName = "Currency", MenuOptionGroupName = "Others", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 2005, MenuOptionName = "Bank Name", MenuOptionGroupName = "Others", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 2006, MenuOptionName = "Bank Branch", MenuOptionGroupName = "Others", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 2007, MenuOptionName = "Bank Account", MenuOptionGroupName = "Others", MenuType = eMenuOptionType.CRUD });

            // Payroll
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3001, MenuOptionName = "Leave Type", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3002, MenuOptionName = "Minimum Wage Category", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3003, MenuOptionName = "Non Cash Benefit", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3004, MenuOptionName = "Employee", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3005, MenuOptionName = "Minimum Wage Rate", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Normal });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3006, MenuOptionName = "Employee Designation", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3007, MenuOptionName = "Earning & Deductions", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3008, MenuOptionName = "Employee Department", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3009, MenuOptionName = "Employee WIBA Class", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3010, MenuOptionName = "Employee Prefix No.", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3011, MenuOptionName = "Employee Accounting Ledger", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3012, MenuOptionName = "Holiday Master", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3013, MenuOptionName = "Leave Application", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3014, MenuOptionName = "Safari Application", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3015, MenuOptionName = "Leave Application No. Prefix", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3016, MenuOptionName = "Safari Application No. Prefix", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3017, MenuOptionName = "Leave Encashment No. Prefix", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3018, MenuOptionName = "Leave Adjustment No. Prefix", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3019, MenuOptionName = "Leave Encashment", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3020, MenuOptionName = "Leave Adjustment", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3021, MenuOptionName = "Employee Shift", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3022, MenuOptionName = "Employee Shift Allocation", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3033, MenuOptionName = "Employee Salary Increment", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3023, MenuOptionName = "Loan Application", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3024, MenuOptionName = "Loan Application No. Prefix", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3025, MenuOptionName = "Loan Adjustment", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3026, MenuOptionName = "Loan Adjustment No. Prefix", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3027, MenuOptionName = "T & A Approval", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3028, MenuOptionName = "T & A Approval No. Prefix", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3029, MenuOptionName = "T & A Approval Import", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3030, MenuOptionName = "Rest Day Allocation", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Normal });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3031, MenuOptionName = "Employee WIBA Class Rate", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.CRUD });

            res.Add(new MenuOptionsViewModel() { MenuOptionID = 3032, MenuOptionName = "Employee Payslip", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Normal });

            // Report
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4001, MenuOptionName = "Attendance Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4002, MenuOptionName = "Daily Attendance Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4003, MenuOptionName = "Late In Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4004, MenuOptionName = "Early Going Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4005, MenuOptionName = "Missed Punch Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4006, MenuOptionName = "Daily Attendance Summary Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4007, MenuOptionName = "Attendance Summary Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4008, MenuOptionName = "Attendance Detail Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4009, MenuOptionName = "Leave/Safari Transaction Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4010, MenuOptionName = "Time & Attendance Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4011, MenuOptionName = "Employee Punching Detail Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4012, MenuOptionName = "Employee Monthly Minimum Wages Report & Periodical WIBA Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4013, MenuOptionName = "Employee List", MenuOptionGroupName = "Employee", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4014, MenuOptionName = "Employement Status Report ", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            res.Add(new MenuOptionsViewModel() { MenuOptionID = 4015, MenuOptionName = "Employee Salary Report", MenuOptionGroupName = "Payroll", MenuType = eMenuOptionType.Report });
            return res;
        }
    }
}
