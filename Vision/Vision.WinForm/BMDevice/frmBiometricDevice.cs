using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL.BMDevice;
using Vision.Model;
using Vision.Model.BMDevice;

namespace Vision.WinForm.BMDevice
{
    public partial class frmBiometricDevice : Template.frmCRUDTemplate
    {
        BiometricDeviceDAL DALObject;
        public frmBiometricDevice()
        {
            InitializeComponent();
            DALObject = new BiometricDeviceDAL();
            FirstControl = txtBMDTitle;
        }

        #region Overriden Methods

        public override void SaveRecord(Model.SavingParemeter Paras)
        {
            DAL.tblBiometricDevice SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblBiometricDevice();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((BiometricDeviceEditListModel)EditRecordDataSource).BMDID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.BMDTitle = txtBMDTitle.Text;
            SaveModel.MachineNo = Model.CommonFunctions.ParseInt(txtMachineNo.Text);
            SaveModel.IPAddress = txtIPAddress.Text;
            SaveModel.PortNo = Model.CommonFunctions.ParseInt(txtPortNo.Text);
            SaveModel.Password = Model.CommonFunctions.ParseInt(txtPassword.Text);

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            DAL.tblBiometricDevice EditingRecord = DALObject.FindSaveModelByPrimeKey(((BiometricDeviceEditListModel)RecordToFill).BMDID);

            txtBMDTitle.Text = EditingRecord.BMDTitle;
            txtMachineNo.Text = EditingRecord.MachineNo.ToString();
            txtIPAddress.Text = EditingRecord.IPAddress;
            txtPortNo.Text = EditingRecord.PortNo.ToString();
            txtPassword.Text = EditingRecord.Password.ToString();
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((BiometricDeviceEditListModel)EditRecordDataSource).BMDID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((BiometricDeviceEditListModel)EditRecordDataSource).BMDID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((BiometricDeviceEditListModel)EditRecordDataSource).BMDID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((BiometricDeviceEditListModel)EditRecordDataSource).BMDID);
        }
        #endregion

        #region Form Methods

        private void txtBMDTitle_Validating(object sender, CancelEventArgs e)
        {
            if (txtBMDTitle.Text == "")
            {
                ErrorProvider.SetError(txtBMDTitle, "Please enter Biometric Device Title");
            }
            else
            {
                ErrorProvider.SetError(txtBMDTitle, "");
            }
        }

        private void txtIPAddress_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtIPAddress.Text, @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$"))
            {
                ErrorProvider.SetError(txtIPAddress, "Please enter valid IP Adderess");
            }
            else if (DALObject.IsDuplicateIPAddress(txtIPAddress.Text,
                (EditRecordDataSource != null ? ((BiometricDeviceEditListModel)EditRecordDataSource).BMDID : 0) ))
            {
                ErrorProvider.SetError(txtIPAddress, "IP Address is already exists, please enter another IP Address.");
            }
            else
            {
                ErrorProvider.SetError(txtIPAddress, "");
            }
        }
        #endregion

        private void btnGetEmployeeAttendance_Click(object sender, EventArgs e)
        {
            gcEmployeeAttendance.DataSource = null;
            using (MSD150SDK.MSD150 device = new MSD150SDK.MSD150(Model.CommonFunctions.ParseInt(txtMachineNo.Text), txtIPAddress.Text,
                Model.CommonFunctions.ParseInt(txtPortNo.Text), Model.CommonFunctions.ParseInt(txtPassword.Text), true))
            {
                if (device == null)
                {
                    MessageBox.Show("Unable to open device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var Result = device.GetEmployeeAttendanceAllLog();
                if (Result.Result == MSD150SDK.eExecutionResult.Succeed)
                {
                    var log = (List<MSD150SDK.GLogInfo>)Result.ResultValue;
                    gcEmployeeAttendance.DataSource = log;

                    //DAL.Employee.EmployeeDAL EmployeeDALObj = new DAL.Employee.EmployeeDAL();
                    //EmployeeDALObj = new DAL.Employee.EmployeeDAL();

                    //var emp = EmployeeDALObj.GetLookupList();

                    //var logfinal = from r in log
                    //               join re in emp on r.enroll equals re.BMDCode into jemp
                    //               from rre in jemp.DefaultIfEmpty()
                    //               select new Model.Payroll.EmployeeTimeLogViewModel() 
                    //               {
                    //                   BMDCode = (rre != null ? rre.BMDCode : 0),
                    //                   EmployeeID = (rre != null ? rre.EmployeeID : 0),
                    //                   EmployeeName = (rre != null ? rre.EmployeeName : "Employee Name Not found"),
                    //                   LogTime = Convert.ToDateTime(r.logtime, System.Globalization.CultureInfo.InvariantCulture),
                    //               };


                    //gcEmployeeAttendance.DataSource = logfinal.ToList();
                    //gvEmployeeAttendance.Columns["LogTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    //gvEmployeeAttendance.Columns["LogTime"].DisplayFormat.FormatString = "t";

                }
                else if (Result.Result == MSD150SDK.eExecutionResult.Error)
                {
                    MessageBox.Show(Result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnConnectDevice_Click(object sender, EventArgs e)
        {
            using (MSD150SDK.MSD150 device = new MSD150SDK.MSD150(Model.CommonFunctions.ParseInt(txtMachineNo.Text), txtIPAddress.Text,
                Model.CommonFunctions.ParseInt(txtPortNo.Text), Model.CommonFunctions.ParseInt(txtPassword.Text), true))
            {
                if(device == null)
                {
                    MessageBox.Show("Unable to open device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Device connected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
