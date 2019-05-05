using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL.Employee;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.WinForm.Employee
{
    public partial class frmEmployeeShiftAllocation : Template.frmNormalTemplate
    {
        EmployeeDAL EmployeeDALObj;
        EmployeeShiftDAL EmployeeShiftDalObj;
        EmployeeShiftAllocationDAL DALObj;
        List<EmployeeShiftLookupListModel> dsEmployeeShift;
        List<EmployeeShiftAllocationViewModel> dsEmployee;

        public frmEmployeeShiftAllocation()
        {
            InitializeComponent();

            FirstControl = deWEDateFrom;
            EmployeeDALObj = new EmployeeDAL();
            EmployeeShiftDalObj = new EmployeeShiftDAL();
            DALObj = new EmployeeShiftAllocationDAL();
        }

        public override void LoadLookupDataSource()
        {
            dsEmployeeShift = EmployeeShiftDalObj.GetLookupList(eEmployeeShiftType.Rotation);

            dsEmployee = EmployeeDALObj.GetLookupList((byte)eEmployeeShiftType.Rotation).Select(r => new EmployeeShiftAllocationViewModel()
            {
                EmployeeID = r.EmployeeID,
                EmployeeNoPrefix = r.EmployeeNoPrefix,
                EmployeeNo = r.EmployeeNo,
                FirstName = r.FirstName,
                LastName = r.LastName,
                //EmployeeName = r.EmployeeName,
                Gender = r.Gender,
                Department = r.Department,
                Designation = r.Designation,
                Location = r.Location,
                EmployementTypeID = r.EmployementTypeID,
            }).ToList();

            foreach(var shift in DALObj.GetLatestShiftAllocation())
            {
                var employee = dsEmployee.FirstOrDefault(r => r.EmployeeID == shift.EmployeeID);
                if (employee != null)
                {
                    employee.LastShiftName = shift.EmployeeShiftName;
                    employee.LastShiftWED = shift.WEDateFrom;
                }
            }

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupShift.Properties.DisplayMember = "EmployeeShiftName";
            lookupShift.Properties.ValueMember = "EmployeeShiftID";
            lookupShift.Properties.DataSource = dsEmployeeShift;

            employeeShiftAllocationViewModelBindingSource.DataSource = dsEmployee;

            base.AssignLookupDataSource();
        }

        public override bool ValidateBeforeSave()
        {
            int selectedRecords = ((List<EmployeeShiftAllocationViewModel>)employeeShiftAllocationViewModelBindingSource.List).Count(r => r.Selected);
            if(selectedRecords == 0)
            {
                Alit.WinformControls.MessageBox.Show("Please select employee.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return base.ValidateBeforeSave();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObj.Save((int)lookupShift.EditValue, (DateTime?)deWEDateFrom.EditValue,
                ((List<EmployeeShiftAllocationViewModel>)employeeShiftAllocationViewModelBindingSource.List).Where(r => r.Selected).Select(r => r.EmployeeID).ToArray());

            base.SaveRecord(Paras);
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            if(Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                if(Alit.WinformControls.MessageBox.Show("Do you want to exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }

            base.AfterSaving(Paras);
        }

        private void lookupShift_Validating(object sender, CancelEventArgs e)
        {
            if (lookupShift.EditValue == null)
            {
                ErrorProvider.SetError(lookupShift, "Please select shift.");
            }
            else
            {
                ErrorProvider.SetError(lookupShift, "");
            }
        }

        private void gridViewShiftAllocationHistory_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //gridViewEmployee.PostEditor();
        }
    }
}
