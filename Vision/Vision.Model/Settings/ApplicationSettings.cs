using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Settings
{
    public enum eUILanguage
    {
        Default_English = 0,
        Turkish = 1
    }

    public enum eEmployee_LeaveAccumulateOn
    {
        MonthBeginning = 0,
        MonthEnding = 1,
    }

    public class ApplicationSettingsViewModel
    {
        #region Level 0
        [DisplayName("GUI Version Major")]
        public int GUIVersionMajor { get; set; }

        [DisplayName("GUI Version Minor")]
        public int GUIVersionMinor { get; set; }

        [DisplayName("GUI theme name")]
        public string GUIThemeSkinName { get; set; }

        [DisplayName("GUI Language")]
        public eUILanguage UILanguage { get; set; }

        public int License_NofCompany { get; set; }


        #region No Reply Email Setup
        public string NoReply_EmailID { get; set; }
        public string NoReply_Password { get; set; }
        public string NoReply_SMTPHost { get; set; }
        public int NoReply_SMTPPort { get; set; }
        public bool NoReply_SSL { get; set; }
        #endregion

        #endregion -- Level 0 

        #region Level 1

        #region Document Location
        public string DocumentLocation_EmployeeImage { get; set; }
        public string DocumentLocation_EmployeeDocument { get; set; }
        public string DocumentLocation_LeaveApplicationDocument { get; set; }

        public string DocumentLocation_SafariApplicationDocument { get; set; }

        public string DocumentLocation_LeaveEncashmentDocument { get; set; }

        public string DocumentLocation_LeaveAdjustmentDocument { get; set; }

        public string DocumentLocation_LoanApplicationDocument { get; set; }

        public string DocumentLocation_LoanAdjustmentDocument { get; set; }

        public string DocumentLocation_TAApprovalDocument { get; set; }
        #endregion

        #region License
        public int License_NofEmployee { get; set; }

        public DateTime? License_ValidUpto { get; set; }
        #endregion

        #region Employee
        public eEmployee_LeaveAccumulateOn Employee_CurrentMonthLeaveAccumulateOn { get; set; }
        #endregion

        #region Payroll
        public decimal OvertimeRate { get; set; }

        public decimal DoubleOvertimeRate { get; set; }

        public decimal WorkingHoursPerWeek { get; set; }

        public decimal WorkingHoursPerDay { get; set; }

        public decimal WorkingDaysPerMonth { get; set; }


        public decimal LatenessPenaltyAmount { get; set; }

        public decimal PFContributionEmployer { get; set; }

        public decimal PFContributionEmployee { get; set; }

        #endregion

        #endregion -- End Level 1   

        #region Reports

        #endregion -- End Report
    }

    public class SettingSaveModel
    {
        public string SettingName { get; set; }

        public object SettingValue { get; set; }
    }

    public enum eSettingValueType
    {
        Varchar50 = 1,
        Long = 2,
        Int = 3, 
        DateTime = 4,
        Boolean = 5,
        Decimal = 6
    }

    public class LicenseNofEmployeeViewModel
    {
        [Browsable(false)]
        public int CompanyID { get; set; }

        [DisplayName("Company")]
        public string CompanyName { get; set; }

        [DisplayName("No of Employee")]
        public int NofEmployee { get; set; }

        public DateTime? ValidUpto { get; set; }
    }
}
