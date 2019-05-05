using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL;
using Vision.DAL.Employee;
using Vision.DAL.Payroll;
using Vision.Model;
using Vision.Model.Employee;
using Vision.Model.Payroll;

namespace Vision.WinForm.Payroll
{
    public partial class frmEmployeePayslip : Template.frmCRUDTemplate
    {
        #region Fields

        EmployeePaySlipDAL DALObj;
        EmployeeDAL EmployeeDALObj;
        DAL.Settings.TaxSlabDAL TaxSlabDALObj;

        EarningDeductionDAL EarningDeductionDALObj;
        List<EmployeePayslip_EarningAndDeductionsViewModel> dsEarningAndDeduction;
        List<EmployeePayslip_EarningAndDeductionsViewModel> dsEarning;
        List<EmployeePayslip_EarningAndDeductionsViewModel> dsDeduction;

        NonCashBenefitDAL NonCashBenefitDALObj;
        List<EmployeePayslip_NoncashBenefitViewModel> dsNonCashBenefitDefaultValues;
        List<EmployeePayslip_NoncashBenefitViewModel> dsNonCashBenefit;
        List<EmployeePayslip_NoncashBenefitViewModel> dsVehicle_NonCashBenefit;
        List<EmployeePayslip_NoncashBenefitViewModel> dsGeneral_NonCashBenefit;

        DAL.Settings.PAYEReliefDAL PAYEReliefDALObj;
        List<EmployeePayslip_PAYEReliefeViewModel> dsPAYERelief;

        DateTime DateFrom { get; set; }

        DateTime DateTo { get; set; }

        tblPayrollEmployeeDetail EditingEmployeeDetail;

        #endregion

        #region Properties

        #region Earnings
        public decimal NormalOvertimeHours
        {
            get
            {
                return (decimal?)txtNormalOvertimeHours.EditValue ?? 0;
            }
            set
            {
                txtNormalOvertimeHours.EditValue = value;
            }
        }

        public decimal DoubleOvertimeHours
        {
            get
            {
                return (decimal?)txtDoubleOvertimeHours.EditValue ?? 0;
            }
            set
            {
                txtDoubleOvertimeHours.EditValue = value;
            }
        }

        public decimal AbsentDays
        {
            get
            {
                return (decimal?)txtAbsemtDays.EditValue ?? 0;
            }
            set
            {
                txtAbsemtDays.EditValue = value;
            }
        }

        public decimal MissedPunchDays
        {
            get
            {
                return (decimal?)txtMissedPunchDays.EditValue ?? 0;
            }
            set
            {
                txtMissedPunchDays.EditValue = value;
            }
        }

        public decimal NoticePayDay
        {
            get
            {
                return (decimal?)txtNoticePayDays.EditValue ?? 0;
            }
            set
            {
                txtNoticePayDays.EditValue = value;
            }
        }

        public decimal LeaveEncashmentDays
        {
            get
            {
                return (decimal?)txtLeaveEncashmentDays.EditValue ?? 0;
            }
            set
            {
                txtLeaveEncashmentDays.EditValue = value;
            }
        }

        public decimal WeekendWorkedDays
        {
            get
            {
                return (decimal?)txtWeekendWorkedDays.EditValue ?? 0;
            }
            set
            {
                txtWeekendWorkedDays.EditValue = value;
            }
        }
        #endregion

        #region Deductions
        public decimal LatenessDays
        {
            get
            {
                return (decimal?)txtLateDays.EditValue ?? 0;
            }
            set
            {
                txtLateDays.EditValue = value;
            }
        }

        public decimal LoanInstallmentAmt
        {
            get
            {
                return (decimal?)txtLoanInstAmt.EditValue ?? 0;
            }
            set
            {
                txtLoanInstAmt.EditValue = value;
            }
        }
        #endregion

        #region PAYE
        public decimal BasicIncome
        {
            get
            {
                return (decimal?)txtBasicSalary.EditValue ?? 0;
            }
            set
            {
                txtBasicSalary.EditValue = value;
                TotalBasicIncomeHRA = value + HRA;
            }
        }

        public decimal HRA
        {
            get
            {
                return (decimal?)txtHRAAmount.EditValue ?? 0;
            }
            set
            {
                txtHRAAmount.EditValue = value;
                TotalBasicIncomeHRA = BasicIncome + value;
            }
        }

        public decimal TotalBasicIncomeHRA
        {
            get
            {
                return (decimal?)txtTotalBasicHRA.EditValue ?? 0;
            }
            set
            {
                txtTotalBasicHRA.EditValue = value;
            }
        }

        public decimal GrossIncome
        {
            get
            {
                return (decimal?)txtGrossSalary.EditValue ?? 0;
            }
            set
            {
                txtGrossSalary.EditValue = value;
            }
        }

        public decimal TaxableIncome
        {
            get
            {
                return (decimal?)txtTaxableIncome.EditValue ?? 0;
            }

            set
            {
                txtTaxableIncome.EditValue = value;
            }
        }

        public decimal NetTaxableIncome
        {
            get
            {
                return (decimal?)txtNetTaxableIncome.EditValue ?? 0;
            }
            set
            {
                txtNetTaxableIncome.EditValue = value;
            }
        }

        public decimal GrossPAYEValue
        {
            get
            {
                return (decimal?)txtGrossPAYE.EditValue ?? 0;
            }
            set
            {
                txtGrossPAYE.EditValue = value;
            }
        }

        public decimal PAYERelief_PersonalRelief
        {
            get
            {
                return (decimal?)txtPersonalRelief.EditValue ?? 0;
            }

            set
            {
                txtPersonalRelief.EditValue = value;
            }
        }

        public decimal PAYEValue
        {
            get
            {
                return (decimal?)txtPAYEValue.EditValue ?? 0;
            }
            set
            {
                txtPAYEValue.EditValue = value;
            }
        }

        public decimal NHIFValue
        {
            get
            {
                return (decimal?)txtNHIFValue.EditValue ?? 0;
            }
            set
            {
                txtNHIFValue.EditValue = value;
            }
        }

        public decimal NSSFValue
        {
            get
            {
                return (decimal?)txtNSSFValue.EditValue ?? 0;
            }
            set
            {
                txtNSSFValue.EditValue = value;
            }
        }

        public decimal PFValue
        {
            get
            {
                return (decimal?)txtPFValue.EditValue ?? 0;
            }
            set
            {
                txtPFValue.EditValue = value;
            }
        }
        #endregion

        #endregion

        public frmEmployeePayslip() : base(new CRUDMTemplateParas() { ShowFormAs = eShowFormAs.RegularForm, FormDefaultUI = eFormCurrentUI.NewEntry, FormAllowedUIs = eFormAllowedUIs.NewEntry })
        {
            InitializeComponent();

            DALObj = new EmployeePaySlipDAL();
            EmployeeDALObj = new EmployeeDAL();
            EarningDeductionDALObj = new EarningDeductionDAL();
            NonCashBenefitDALObj = new NonCashBenefitDAL();
            PAYEReliefDALObj = new DAL.Settings.PAYEReliefDAL();
            TaxSlabDALObj = new DAL.Settings.TaxSlabDAL();

            DateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1).Add(new TimeSpan(23, 59, 59));
            DateFrom = new DateTime(DateTo.Year, DateTo.Month, 1);
            txtDateTitle.Text = DateFrom.ToString("MMMM-yyyy");
        }

        List<Model.Employee.EmployeeLookupListModel> dsEmployee;
        public override void LoadLookupDataSource()
        {
            dsEmployee = EmployeeDALObj.GetLookupList();

            dsEarningAndDeduction = DALObj.GetEarningsAndDeductions();
            dsEarning = dsEarningAndDeduction.Where(r => r.RecordType == eEarningDeductionType.Earning).ToList();
            dsDeduction = dsEarningAndDeduction.Where(r => r.RecordType == eEarningDeductionType.Deduction).ToList();

            dsNonCashBenefitDefaultValues = DALObj.GetNonCashBenefitList();
            dsNonCashBenefit = DALObj.GetNonCashBenefitList();

            foreach (var r in dsNonCashBenefit.Where(r => r.NonCashBenefitKRAValueType == eNonCashBenefitKRAValueType.Percentage))
            {
                r.KRAValue = Math.Round(r.CostValue * r.KRAValuePercentage, 2);
            }

            dsPAYERelief = DALObj.GetPAYERelief(DateTo);
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.DataSource = dsEmployee;

            employeePayslipDeductionsBindingSource.DataSource = dsDeduction;
            employeePayslipEarningsBindingSource.DataSource = dsEarning;

            lookUpVehicle_NonCashBenefit.Properties.ValueMember = "NonCashBenefitID";
            lookUpVehicle_NonCashBenefit.Properties.DisplayMember = "NonCashBenefitName";
            dsVehicle_NonCashBenefit = dsNonCashBenefit.Where(r => r.NonCashBenefitType == eNonCashBenefitType.Vehicle).ToList();
            dsVehicle_NonCashBenefit.Insert(0, new EmployeePayslip_NoncashBenefitViewModel()
            {
                NonCashBenefitID = -1,
                NonCashBenefitName = "(None)",
                NonCashBenefitType = eNonCashBenefitType.Vehicle,
            });

            lookUpVehicle_NonCashBenefit.Properties.DataSource = dsVehicle_NonCashBenefit;
            lookUpVehicle_NonCashBenefit.Properties.PopulateColumns();
            Application.DoEvents();
            if (lookUpVehicle_NonCashBenefit.Properties.Columns.Count > 0)
            {
                lookUpVehicle_NonCashBenefit.Properties.Columns["Selected"].Visible = false;
                lookUpVehicle_NonCashBenefit.Properties.Columns["Recurrning"].Visible = false;
            }

            dsGeneral_NonCashBenefit = dsNonCashBenefit.Where(r => r.NonCashBenefitType == eNonCashBenefitType.General).ToList();
            employeePayslipNoncashBenefitViewModelBindingSource.DataSource = dsGeneral_NonCashBenefit;

            employeePayslipPAYEReliefeViewModelBindingSource.DataSource = dsPAYERelief;

            //--
            ClearPayrollValues();

            base.AssignLookupDataSource();
        }

        private void lookupEmployee_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEmployee.EditValue != null)
            {
                GetPaySlipData((int?)lookupEmployee.EditValue ?? 0);
            }
            else
            {
                ClearPayrollValues();
            }
        }

        tblEmployee EmployeeSaveModel;
        tblEmployeeServiceDetail ServiceSaveModel;
        void GetPaySlipData(int EmployeeID)
        {
            ClearPayrollValues();
            //--
            EmployeeSaveModel = EmployeeDALObj.FindSaveModelByPrimeKey(EmployeeID);
            if (EmployeeSaveModel == null)
            {
                return;
            }

            ServiceSaveModel = EmployeeSaveModel.tblEmployeeServiceDetail;
            if (ServiceSaveModel == null)
            {
                return;
            }

            if (((eTAAttendanceType)EmployeeSaveModel.TAAttendanceType) == eTAAttendanceType.Integrated)
            {
                ProcessAttendanceData(EmployeeSaveModel, ServiceSaveModel);
            }

            CalculatePAYE();
        }

        void ProcessAttendanceData(tblEmployee EmployeeSaveModel, tblEmployeeServiceDetail ServiceSaveModel)
        {
            //ClearPayrollValues();
            Model.Employee.eTAAttendanceType AttendanceType = ((Model.Employee.eTAAttendanceType)EmployeeSaveModel.TAAttendanceType);

            EditingEmployeeDetail = DALObj.FindPayrollEmployeeDetail(DateFrom.Month, DateFrom.Year, EmployeeSaveModel.EmployeeID);
            if (EditingEmployeeDetail != null)
            {
                NormalOvertimeHours = EditingEmployeeDetail.NormalOvertimeHours;
                DoubleOvertimeHours = EditingEmployeeDetail.DoubleOvertimeHours;
                AbsentDays = EditingEmployeeDetail.AbsentDays;
                MissedPunchDays = EditingEmployeeDetail.MissedPunchDays;
                WeekendWorkedDays = EditingEmployeeDetail.WeekendWorkedDays;
                LeaveEncashmentDays = EditingEmployeeDetail.LeaveEncashmentDays;
                NoticePayDay = EditingEmployeeDetail.NoticePayDays;

                LatenessDays = EditingEmployeeDetail.LateDays;
                LoanInstallmentAmt = EditingEmployeeDetail.LoanInstallmentAmount;
                lookUpVehicle_NonCashBenefit.EditValue = EditingEmployeeDetail.Vehicle_NoncashBenefitID;

                foreach (var r in EditingEmployeeDetail.tblPayrollEmployeeEarningsDeductions)
                {
                    var ViewModel = dsEarningAndDeduction.FirstOrDefault(rr => rr.EarningAndDeductionID == r.EarningsDeductionID && r.Value != 0);
                    if (ViewModel != null)
                    {
                        ViewModel.Value = r.Value;
                    }
                }
                gvEarnings.RefreshData();
                gvDeductions.RefreshData();

                foreach (var r in EditingEmployeeDetail.tblPayrollEmployeeNonCashBenefits)
                {
                    var ViewModel = dsNonCashBenefit.FirstOrDefault(rr => rr.NonCashBenefitID == r.NonCashBenefitID);
                    if (ViewModel != null)
                    {
                        ViewModel.Selected = true;
                        ViewModel.CostValue = r.CostValue;
                        ViewModel.KRAValuePercentage = r.KRAPerc;
                        ViewModel.KRAValue = r.KRAValue;
                        ViewModel.Recurrning = r.Recurring;
                    }
                }
                gvNonCashBenefit.RefreshData();

                foreach (var r in EditingEmployeeDetail.tblPayrollEmployePAYEReliefs)
                {
                    var ViewModel = dsPAYERelief.FirstOrDefault(rr => rr.PAYEReliefID == r.PAYEReliefID && r.PAYEReliefAmt != 0);
                    if (ViewModel != null)
                    {
                        ViewModel.Selected = true;
                        ViewModel.PAYEReliefAmt = r.PAYEReliefAmt;
                    }
                }
            }

            if (AttendanceType == eTAAttendanceType.Integrated)
            {
                EmployeeAttendanceDAL AttendanceDALObj = new EmployeeAttendanceDAL();
                var dsAttendance = AttendanceDALObj.GetEmployeeAttendanceData(DateFrom, DateTo, EmployeeSaveModel.EmployeeID);

                NormalOvertimeHours = dsAttendance.Sum(r => r.NormalOvertimeHour);

                if (((Model.Employee.eTAWeekEndAttendance)EmployeeSaveModel.TAWeekEndAttendance) == Model.Employee.eTAWeekEndAttendance.Overtime)
                {
                    DoubleOvertimeHours = dsAttendance.Sum(r => r.DoubleOvertimeHour);
                }

                AbsentDays = dsAttendance.Sum(r => r.AbsentCount);

                if (((eTAMissPunch)EmployeeSaveModel.TAMissPunch) == eTAMissPunch.Abscent)
                {
                    AbsentDays = AbsentDays + dsAttendance.Count(r => r.MissedPunch);
                }

                LeaveEncashmentDays = DALObj.CountLeaveEncashmentDays(EmployeeSaveModel.EmployeeID, DateFrom, DateTo);

                if (((Model.Employee.eTAWeekEndAttendance)EmployeeSaveModel.TAWeekEndAttendance) == Model.Employee.eTAWeekEndAttendance.Allowance)
                {
                    WeekendWorkedDays = dsAttendance.Count(r =>
                        ((r.Weekend == eEmployeeWeekendDayType.WeekendWorked && r.WeekendWorkedApproved) ||
                        (r.RestDay == eEmployeeRestDayDayType.RestDayWorked || r.RestDayWorkedApproved)) && (((eTAMissPunch)EmployeeSaveModel.TAMissPunch) == eTAMissPunch.Present || !r.MissedPunch));
                }

                if (((Model.Employee.eTALatenessCharges)EmployeeSaveModel.TALatenessCharges) == Model.Employee.eTALatenessCharges.Applicable)
                {
                    LatenessDays = dsAttendance.Count(r => r.LateIn && !r.LatenessApproved);
                    //LatenessAmt = Math.Round(Model.CommonProperties.LoginInfo.SoftwareSettings.LatenessPenaltyAmount * LateInCount, 2);
                }


                LoanInstallmentAmt = DALObj.GetLoanInstallmentAmt(EmployeeSaveModel.EmployeeID, DateFrom, DateTo);

                //--
                //txtNormalOvertimeHours.Enabled = false;
                //txtDoubleOvertimeHours.Enabled = false;

                //txtAbsemtDays.Enabled = false;
                //txtWeekendWorkedDays.Enabled = false;
            }
            //else if(AttendanceType == eTAAttendanceType.Import)
            //{
            //}
            //else if(AttendanceType == eTAAttendanceType.NotApplicable)
            //{
            //    //--
            //    txtNormalOvertimeHours.Enabled = true;
            //    txtDoubleOvertimeHours.Enabled = true;

            //    txtAbsemtDays.Enabled = true;
            //    txtWeekendWorkedDays.Enabled = true;
            //}
        }

        void ClearPayrollValues()
        {
            EmployeeSaveModel = null;
            ServiceSaveModel = null;
            EditingEmployeeDetail = null;
            NormalOvertimeHours = 0;
            DoubleOvertimeHours = 0;
            AbsentDays = 0;
            NoticePayDay = 0;
            LeaveEncashmentDays = 0;
            WeekendWorkedDays = 0;

            LatenessDays = 0;
            //LatenessAmt = 0;
            LoanInstallmentAmt = 0;

            lookUpVehicle_NonCashBenefit.EditValue = null;

            dsEarningAndDeduction.ForEach(r => r.Value = 0);
            gvEarnings.RefreshData();
            gvDeductions.RefreshData();

            dsNonCashBenefit.ForEach(r =>
            {
                r.Selected = false;
                r.Recurrning = false;

                var defaultValues = dsNonCashBenefitDefaultValues.FirstOrDefault(dr => dr.NonCashBenefitID == r.NonCashBenefitID);
                if (defaultValues != null)
                {
                    r.KRAValue = defaultValues.KRAValue;
                    r.KRAValuePercentage = defaultValues.KRAValuePercentage;
                    r.CostValue = defaultValues.CostValue;
                }
            });
            gvNonCashBenefit.RefreshData();

            dsPAYERelief.ForEach(r =>
            {
                if (r.Mandatory == Model.Settings.ePAYEReliefeMandatory.Yes)
                {
                    r.Selected = true;
                    r.PAYEReliefAmt = r.MonthlyLimit;
                }
                else
                {
                    r.Selected = false;
                }
                //r.PAYEReliefAmt = 0;
            });
            gvPAYERelief.RefreshData();

            cmbNSSF.SelectedIndex = 1;
            cmbNHIFApplicable.SelectedIndex = 1;

            BasicIncome = 0;
            HRA = 0;
            GrossIncome = 0;
            TaxableIncome = 0;
            NetTaxableIncome = 0;

            PAYETaxableEarningBindingSource.Clear();
            gvTaxableEarnings.RefreshData();

            PAYENoncashBenefitBindingSource.Clear();
            gvPAYE_NonCashBenefit.RefreshData();

            PAYEReliefeBindingSource.Clear();
            gvPAYE_PAYERelief.RefreshData();
        }

        void CalculatePAYE()
        {
            if (EmployeeSaveModel == null || ServiceSaveModel == null)
            {
                return;
            }
            BasicIncome = ServiceSaveModel.BasicSalary;
            txtIncomeType.Text = (EmployeeSaveModel.IncomeType ? "Primary" : "Secondry") + " Income";
            HRA = ServiceSaveModel.HousingAllowance;
            IEnumerable<EmployeePayslip_EarningAndDeductionsViewModel> dsTaxableIncome = dsEarningAndDeduction.Where(r => r.RecordType == eEarningDeductionType.Earning && r.Taxable);
            PAYETaxableEarningBindingSource.DataSource = dsTaxableIncome;
            GrossIncome = BasicIncome + HRA + (dsTaxableIncome.Sum(r => (decimal?)r.Value) ?? 0);

            decimal taxableValue = 0;
            decimal TaxValue = 0;

            // NHIF            
            if (cmbNHIFApplicable.SelectedIndex == 1)
            {
                var dsNHIFTaxSlab = TaxSlabDALObj.GetLatestTaxSlab(Model.Settings.eTaxSlab_TaxType.NHIF, eIncomeType.Primary).OrderBy(r => r.TaxableSalaryFromValue);

                taxableValue = BasicIncome + HRA;
                var MatchingSlab = dsNHIFTaxSlab.Where(r => r.TaxableSalaryFromValue <= taxableValue).OrderByDescending(r => r.TaxableSalaryFromValue).FirstOrDefault();
                if (MatchingSlab != null)
                {
                    NHIFValue = MatchingSlab.TaxValueEmployee;
                }
                else
                {
                    NHIFValue = 0;
                }
                //TaxValue = 0;
                //foreach (var r in dsNHIFTaxSlab)
                //{
                //    if (r.TaxableSalaryToValue <= taxableValue)
                //    {
                //        TaxValue += r.TaxValueEmployee;
                //    }
                //}
                //NHIFValue = TaxValue;
            }
            else
            {
                NHIFValue = 0;
            }

            // NSSF
            if (cmbNSSF.SelectedIndex == 1)
            {
                taxableValue = BasicIncome + HRA;
                var dsNSSFTaxSlab = TaxSlabDALObj.GetTaxSlab(Model.Settings.eTaxSlab_TaxType.NSSF, DateTo);
                var SelectedTaxSlab = dsNSSFTaxSlab.Where(r => r.TaxableSalaryFromValue <= taxableValue).OrderByDescending(r => r.TaxableSalaryFromValue).FirstOrDefault();
                if (SelectedTaxSlab != null)
                {
                    NSSFValue = Math.Round(Math.Min(taxableValue * SelectedTaxSlab.TaxPercEmployee, SelectedTaxSlab.MaxTaxValueEmployee), 2);
                }
                else
                {
                    NSSFValue = 0;
                }
            }
            else
            {
                NSSFValue = 0;
            }

            // P.F.
            if ((Model.Employee.eProvidentFund)EmployeeSaveModel.ProvidentFund == eProvidentFund.Applicable)
            {
                PFValue = Math.Round(BasicIncome * Model.CommonProperties.LoginInfo.SoftwareSettings.PFContributionEmployee, 2);
            }
            else
            {
                PFValue = 0;
            }


            List<EmployeePayslip_NoncashBenefitViewModel> dsPAYENonCashBenefit = dsNonCashBenefit.Where(r => r.Selected).ToList();
            PAYENoncashBenefitBindingSource.DataSource = dsPAYENonCashBenefit;
            decimal VehicleValue = 0;
            if (lookUpVehicle_NonCashBenefit.EditValue != null)
            {
                var VehicleSaveModel = NonCashBenefitDALObj.FindSaveModelByPrimeKey((int)lookUpVehicle_NonCashBenefit.EditValue);
                if (VehicleSaveModel != null)
                {
                    PAYENoncashBenefitBindingSource.Add(new EmployeePayslip_NoncashBenefitViewModel()
                    {
                        NonCashBenefitID = VehicleSaveModel.NonCashBenefitID,
                        NonCashBenefitName = VehicleSaveModel.NonCashBenefitName,
                        CostValue = VehicleSaveModel.CostValue,
                        KRAValue = VehicleSaveModel.KRAValue,
                        KRAValuePercentage = VehicleSaveModel.VehicleCostKRAPerc,
                    });
                    VehicleValue = VehicleSaveModel.KRAValue;
                }
            }

            List<EmployeePayslip_PAYEReliefeViewModel> dsPAYEpayeRelief = dsPAYERelief.Where(r => r.Selected && r.PAYEReliefAmt != 0).ToList();
            dsPAYEpayeRelief.Add(new EmployeePayslip_PAYEReliefeViewModel()
            {
                PAYEReliefName = "NSSF",
                PAYEReliefAmt = NSSFValue
            });
            dsPAYEpayeRelief.Add(new EmployeePayslip_PAYEReliefeViewModel()
            {
                PAYEReliefName = "Provident Fund",
                PAYEReliefAmt = PFValue
            });

            PAYERelief_PersonalRelief = ((dsPAYEpayeRelief.Where(r => r.PAYEReliefType == Model.Settings.ePAYEReliefType.PersonalRelief).Sum(r => (decimal?)r.PAYEReliefAmt) ?? 0));
            dsPAYEpayeRelief.RemoveAll(r => r.PAYEReliefType == Model.Settings.ePAYEReliefType.PersonalRelief);


            PAYEReliefeBindingSource.DataSource = dsPAYEpayeRelief;

            TaxableIncome = GrossIncome + (dsPAYENonCashBenefit.Sum(r => (decimal?)r.KRAValue) ?? 0);
            NetTaxableIncome = TaxableIncome - dsPAYEpayeRelief.Sum(r => r.PAYEReliefAmt);

            // PAYE Calculation 
            var dsPAYEtaxSlab = TaxSlabDALObj.GetLatestTaxSlab(Model.Settings.eTaxSlab_TaxType.PAYE, EmployeeSaveModel.IncomeType ? eIncomeType.Primary : eIncomeType.Secondary).OrderBy(r => r.TaxableSalaryFromValue);
            taxableValue = NetTaxableIncome;

            var FirstSlab = dsPAYEtaxSlab.OrderBy(r => r.TaxableSalaryFromValue).FirstOrDefault();
            if (FirstSlab == null || FirstSlab.TaxableSalaryToValue < taxableValue)
            {
                //--
                foreach (var r in dsPAYEtaxSlab)
                {
                    if (r.TaxableSalaryFromValue > taxableValue)
                    {
                        break;
                    }

                    decimal CalculateOnAmt = 0;
                    if (r.TaxableSalaryToValue <= taxableValue)
                    {
                        CalculateOnAmt = r.TaxableSalaryToValue - r.TaxableSalaryFromValue;
                    }
                    else
                    {
                        CalculateOnAmt = taxableValue - r.TaxableSalaryFromValue;
                    }

                    TaxValue += Math.Round(CalculateOnAmt * r.TaxPercEmployee, 2);
                }
                GrossPAYEValue = TaxValue;
                PAYEValue = TaxValue - PAYERelief_PersonalRelief;
            }
            else
            {
                GrossPAYEValue = 0;
                PAYEValue = 0;
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DateTo = new DateTime(dateEdit1.DateTime.Year, dateEdit1.DateTime.Month, 1).AddMonths(1).AddDays(-1).Add(new TimeSpan(23, 59, 59));
            DateFrom = new DateTime(DateTo.Year, DateTo.Month, 1);
            txtDateTitle.Text = DateFrom.ToString("MMMM-yyyy");

            if (lookupEmployee.EditValue != null)
            {
                GetPaySlipData((int)lookupEmployee.EditValue);
            }
        }

        #region Template Methods

        public override bool ValidateBeforeSave()
        {
            lookUpVehicle_NonCashBenefit_Validating(null, null);

            return base.ValidateBeforeSave();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            int MonthFrom = DateFrom.Month;
            int YearFrom = DateFrom.Year;
            int EmployeeID = (int)lookupEmployee.EditValue;

            tblPayrollEmployeeDetail EmployeeDetailSaveModel = null;

            if (EditingEmployeeDetail != null && EditingEmployeeDetail.PayrollEmployeeDetailID != 0)
            {
                EmployeeDetailSaveModel = DALObj.FindPayrollEmployeeDetailByID(EditingEmployeeDetail.PayrollEmployeeDetailID);
            }
            if (EmployeeDetailSaveModel == null)
            {
                EmployeeDetailSaveModel = new tblPayrollEmployeeDetail();
            }

            EmployeeDetailSaveModel.EmployeeID = EmployeeID;
            EmployeeDetailSaveModel.NormalOvertimeHours = NormalOvertimeHours;
            EmployeeDetailSaveModel.DoubleOvertimeHours = DoubleOvertimeHours;
            EmployeeDetailSaveModel.AbsentDays = AbsentDays;
            EmployeeDetailSaveModel.MissedPunchDays = MissedPunchDays;
            EmployeeDetailSaveModel.WeekendWorkedDays = WeekendWorkedDays;
            EmployeeDetailSaveModel.LeaveEncashmentDays = LeaveEncashmentDays;
            EmployeeDetailSaveModel.NoticePayDays = NoticePayDay;

            EmployeeDetailSaveModel.LateDays = LatenessDays;
            EmployeeDetailSaveModel.LoanInstallmentAmount = LoanInstallmentAmt;

            EmployeeDetailSaveModel.Vehicle_NoncashBenefitID = (int?)lookUpVehicle_NonCashBenefit.EditValue;
            if (EmployeeDetailSaveModel.Vehicle_NoncashBenefitID == -1)
            {
                EmployeeDetailSaveModel.Vehicle_NoncashBenefitID = null;
            }

            Paras.SavingResult = DALObj.SavePayroll(DateFrom.Month, DateFrom.Year, EmployeeDetailSaveModel, dsEarningAndDeduction, dsNonCashBenefit, dsPAYERelief);
            base.SaveRecord(Paras);
        }

        #endregion

        private void gcEarnings_Click(object sender, EventArgs e)
        {

        }

        private void lookUpVehicle_NonCashBenefit_Validating(object sender, CancelEventArgs e)
        {
            if (lookUpVehicle_NonCashBenefit.EditValue != null && ((int?)lookUpVehicle_NonCashBenefit.EditValue ?? 0) != -1 && lookupEmployee.EditValue != null)
            {
                if (DALObj.IsVehicleAssignedToOtherEmployee((int)lookUpVehicle_NonCashBenefit.EditValue, (int)lookupEmployee.EditValue, DateFrom.Month, DateFrom.Year))
                {
                    ErrorProvider.SetError(lookUpVehicle_NonCashBenefit, "Selected Vehicle already assigned to someone else");
                }
            }
            else
            {
                ErrorProvider.SetError(lookUpVehicle_NonCashBenefit, null);
            }
        }

        private void lookupEmployee_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEmployee.EditValue == null)
            {
                ErrorProvider.SetError(lookupEmployee, "Please select employee");
            }
            else
            {
                ErrorProvider.SetError(lookupEmployee, "");
            }
        }

        private void gvPAYERelief_ShowingEditor(object sender, CancelEventArgs e)
        {
            var Row = (EmployeePayslip_PAYEReliefeViewModel)gvPAYERelief.GetFocusedRow();
            if (Row == null)
            {
                return;
            }

            if (gvPAYERelief.FocusedColumn == colSelectedPAYERelief)
            {
                if (Row.Mandatory == Model.Settings.ePAYEReliefeMandatory.Yes)
                {
                    e.Cancel = true;
                }
            }
            else if (gvPAYERelief.FocusedColumn == colPAYEReliefAmt)
            {
                if (!Row.Selected)
                {
                    e.Cancel = true;
                }
            }
        }

        private void gvPAYERelief_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            var Row = (EmployeePayslip_PAYEReliefeViewModel)gvPAYERelief.GetFocusedRow();
            if (Row == null)
            {
                return;
            }
            //--
            if (gvPAYERelief.FocusedColumn == colPAYEReliefAmt)
            {
                if (e.Value == null)
                {
                    e.ErrorText = "Please enter valid numeric value.";
                    e.Valid = false;
                }
                else if ((decimal)e.Value == 0)
                {
                    e.ErrorText = "Please enter value.";
                    e.Valid = false;
                }
                else if ((decimal)e.Value > Row.MonthlyLimit)
                {
                    e.ErrorText = "Amt can not be greater than Monthly Limit Amount.";
                    e.Valid = false;
                }
            }
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (e.Page == lcgPAYE)
            {
                CalculatePAYE();
            }
        }

        private void gvNonCashBenefit_ShowingEditor(object sender, CancelEventArgs e)
        {
            EmployeePayslip_NoncashBenefitViewModel Row = (EmployeePayslip_NoncashBenefitViewModel)gvNonCashBenefit.GetFocusedRow();
            if (Row == null)
            {
                return;
            }

            if (!Row.Selected && gvNonCashBenefit.FocusedColumn != colSelectedNonCashBenefit)
            {
                e.Cancel = true;
                return;
            }

            if (gvNonCashBenefit.FocusedColumn == colCostValue1)
            {

                if (Row.NonCashBenefitKRAValueType == eNonCashBenefitKRAValueType.Fixed)
                {
                    e.Cancel = true;
                }
            }
        }

        private void gvNonCashBenefit_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == colCostValue1)
            {
                EmployeePayslip_NoncashBenefitViewModel Row = (EmployeePayslip_NoncashBenefitViewModel)gvNonCashBenefit.GetRow(e.RowHandle);
                if (Row == null)
                {
                    return;
                }
                if (e.RowHandle != gvNonCashBenefit.FocusedRowHandle && Row.NonCashBenefitCostValueType == eNonCashBenefitCostValueType.Fixed)
                {
                    e.Appearance.BackColor = Color.Cornsilk;
                }
            }
        }
    }
}
