using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public enum eTAApprovalType
    {
        Overtime = 0,
        Lateness = 1,
        EarlyGoing = 2,
        WeekendWork = 3,
    }

    public class TAApprovalEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int TAApprovalID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }



        [DisplayName("Transaction Date")]
        public DateTime TAApprovedDate { get; set; }

        [Browsable(false)]
        public eTAApprovalType ApprovalTypeID { get; set; }

        [DisplayName("Type")]
        public string ApprovalType
        {
            get
            {
                switch (ApprovalTypeID)
                {
                    case eTAApprovalType.Overtime:
                        return "Overtime";
                    case eTAApprovalType.Lateness:
                        return "Lateness";
                    case eTAApprovalType.EarlyGoing:
                        return "Early Going";
                    case eTAApprovalType.WeekendWork:
                        return "Weekend Work";
                    default:
                        return null;
                }
            }
        }

        [DisplayName("Approved Date")]
        public DateTime ApprovedDate { get; set; }

        [DisplayName("Hours")]
        public decimal ApprovedHours { get; set; }


        [DisplayName("Prefix")]
        public string TAApprovalNoPrefixName { get; set; }

        [DisplayName("Approval No.")]
        public int TAApprovalNo { get; set; }
    }

    public class TAApprovalLookupListModel
    {
        [Browsable(false)]
        public int TAApprovalID { get; set; }

        [DisplayName("Prefix")]
        public string TAApprovalNoPrefixName { get; set; }

        [DisplayName("Approval No.")]
        public int TAApprovalNo { get; set; }


        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }


        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }


        [DisplayName("Transaction Date")]
        public DateTime TAApprovalDate { get; set; }

        [Browsable(false)]
        public eTAApprovalType ApprovalTypeID { get; set; }

        [DisplayName("Type")]
        public string ApprovalType
        {
            get
            {
                switch (ApprovalTypeID)
                {
                    case eTAApprovalType.Overtime:
                        return "Overtime";
                    case eTAApprovalType.Lateness:
                        return "Lateness";
                    case eTAApprovalType.EarlyGoing:
                        return "Early Going";
                    case eTAApprovalType.WeekendWork:
                        return "Weekend Work";
                    default:
                        return null;
                }
            }
        }

        [DisplayName("Approved Date")]
        public DateTime ApprovedDate { get; set; }

        [DisplayName("Hours")]
        public decimal ApprovedHours { get; set; }
    }

    public class TAApprovalImportViewModel
    {
        [Browsable(false)]
        public int TAApprovalID { get; set; }

        [DisplayName("Row No.")]
        public int RowNo { get; set; }

        [Browsable(false)]
        public bool CanImport
        {
            get
            {
                return ApprovalDate != null &&
                    ApprovalNoPrefixID != null &&
                    ApprovalNo != null &&
                    EmployeeID != null &&
                    ApprovedDate != null &&
                    ApprovedHours != null &&
                    ApprovalTypeID != null;
            }
        }

        [DisplayName("Can Import")]
        public string CanImportStatus { get { return CanImport ? "Yes" : "No"; } }

        [Browsable(false)]
        public SavingResult SavingResult { get; set; }

        [DisplayName("Saving Result")]
        public string SavingResultStatus
        {
            get
            {
                if (SavingResult == null)
                {
                    return null;
                }
                else
                {
                    switch (SavingResult.ExecutionResult)
                    {
                        case eExecutionResult.NotExecutedYet:
                            return "Not Saved.";
                        case eExecutionResult.CommitedSucessfuly:
                            return "Saved";
                        case eExecutionResult.ErrorWhileExecuting:
                            return "Not Saved. Error : " + (SavingResult.Exception != null ? SavingResult.Exception.Message : null);
                        case eExecutionResult.ValidationError:
                            return "Not Saved. Caution! " + SavingResult.ValidationError;
                        default:
                            return "N/A";
                    }
                }
            }
        }

        [DisplayName("Transaction Date")]
        public DateTime? ApprovalDate { get; set; }

        [Browsable(false)]
        public string ApprovalDateError { get; set; }



        [DisplayName("Approval No. Prefix")]
        public int? ApprovalNoPrefixID { get; set; }

        [Browsable(false)]
        public string ApprovalNoPrefixName { get; set; }

        [Browsable(false)]
        public string ApprovalNoPrefixNameError { get; set; }



        [DisplayName("Approval No.")]
        public int? ApprovalNo { get; set; }

        [Browsable(false)]
        public string ApprovalNoError { get; set; }




        [DisplayName("E.No. Prefix")]
        public string EmployeeNoPrefixName { get; set; }

        [DisplayName("Emp Code")]
        public int? EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public int? EmployeeID { get; set; }

        [Browsable(false)]
        public string EmployeeName { get; set; }

        [Browsable(false)]
        public string EmployeeNameError { get; set; }



        [DisplayName("Approved Date")]
        public DateTime? ApprovedDate { get; set; }

        [Browsable(false)]
        public string ApprovedDateError { get; set; }



        [DisplayName("Approved Hours")]
        public decimal? ApprovedHours { get; set; }

        [Browsable(false)]
        public string ApprovedHoursError { get; set; }



        //[DisplayName("Type")]
        //public byte? ApprovalTypeID { get; set; }

        public eTAApprovalType? ApprovalTypeID { get; set; }

        //[Browsable(false)]
        //public string ApprovalType
        //{
        //    get
        //    {
        //        switch (ApprovalTypeID)
        //        {
        //            case eTAApprovalType.Overtime:
        //                return "Overtime";
        //            case eTAApprovalType.Lateness:
        //                return "Lateness";
        //            case eTAApprovalType.EarlyGoing:
        //                return "Early Going";
        //            case eTAApprovalType.WeekendWork:
        //                return "Weekend Work";
        //            default:
        //                return null;
        //        }
        //    }
        //}

        [Browsable(false)]
        public string ApprovalTypeIDError { get; set; }


        public string Remark { get; set; }
    }

    public class TAApprovalTypeViewModel
    {
        [Browsable(false)]
        public eTAApprovalType ApprovalTypeID { get; set; }

        [DisplayName("Approval Type")]
        public string ApprovalTypeName
        {
            get
            {
                switch (ApprovalTypeID)
                {
                    case eTAApprovalType.Overtime:
                        return "Overtime";
                    case eTAApprovalType.Lateness:
                        return "Lateness";
                    case eTAApprovalType.EarlyGoing:
                        return "Early Going";
                    case eTAApprovalType.WeekendWork:
                        return "Weekend Work";
                    default:
                        return null;
                }
            }
        }
    }
}