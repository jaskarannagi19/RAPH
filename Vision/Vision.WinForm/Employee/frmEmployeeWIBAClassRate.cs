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
    public partial class frmEmployeeWIBAClassRate : Template.frmNormalTemplate
    {
        EmployeeWIBAClassRateDAL DALObj;
        List<EmployeeWIBAClassRateViewModel> dsEmployeeWIBAClassRate;

        public frmEmployeeWIBAClassRate()
        {
            InitializeComponent();
            DALObj = new EmployeeWIBAClassRateDAL();
            
        }

        public override void LoadLookupDataSource()
        {
            dsEmployeeWIBAClassRate = DALObj.GetEmployeeWIBAClassRate();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            employeeWIBAClassRateViewModelBindingSource.DataSource = dsEmployeeWIBAClassRate;
            base.AssignLookupDataSource();
        }


        public override void SaveRecord(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObj.UpdateWIBAClassRate((DateTime?)deWEDate.EditValue, dsEmployeeWIBAClassRate);
            base.SaveRecord(Paras);
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            if(Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                if(MessageBox.Show("Rate updated successfully. Do you want to exit ?", "Exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            base.AfterSaving(Paras);
        }

        private void gridViewRate_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var Row = (EmployeeWIBAClassRateViewModel)gridViewRate.GetRow(e.RowHandle);
            if(Row == null)
            {
                return;
            }
            if(!Row.Selected)
            {
                Row.Selected = true;
            }
        }
    }
}
