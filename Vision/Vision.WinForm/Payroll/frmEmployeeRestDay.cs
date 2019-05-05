using DevExpress.Skins;
using DevExpress.XtraGrid.Columns;
using DevExpress.LookAndFeel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vision.DAL.Payroll;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.WinForm.Payroll
{
    public partial class frmEmployeeRestDay : Template.frmNormalTemplate
    {
        EmployeeRestDayDAL EmployeeRestDayDALObj;
        List<EmployeeRestDayViewModel> dsEmployeeRestDay;

        public frmEmployeeRestDay()
        {
            InitializeComponent();

            EmployeeRestDayDALObj = new EmployeeRestDayDAL();

            SkinElement element = SkinManager.GetSkinElement(SkinProductId.Editors, DevExpress.LookAndFeel.UserLookAndFeel.Default, EditorsSkins.SkinCheckBox);
            element.Size.MinSize = new System.Drawing.Size(18, 18);
            element.Image.Stretch = SkinImageStretch.Stretch;
            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
        }

        public override void LoadLookupDataSource()
        {
            dsEmployeeRestDay = EmployeeRestDayDALObj.GetEmployeeList();
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            employeeRestDayViewModelBindingSource.DataSource = dsEmployeeRestDay;

            deDateFrom.DateTime = DateTime.Now.Date.AddDays((DateTime.Now.DayOfWeek == DayOfWeek.Sunday ? -6 : DayOfWeek.Monday - DateTime.Now.DayOfWeek));

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            Paras.SavingResult = EmployeeRestDayDALObj.SaveNewRecord(deDateFrom.DateTime, deDateTo.DateTime, dsEmployeeRestDay);

            base.SaveRecord(Paras);
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                if (Alit.WinformControls.MessageBox.Show("Data saved successfully. Do you want to exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }

            base.AfterSaving(Paras);
        }

        private void deDateTo_Validating(object sender, CancelEventArgs e)
        {
            if (deDateTo.DateTime < deDateFrom.DateTime)
            {
                ErrorProvider.SetError(deDateTo, "Date to must be greater than Date From.");
            }
            else
            {
                ErrorProvider.SetError(deDateTo, "");
            }
        }

        private void deDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (deDateFrom.DateTime > deDateTo.DateTime)
            {
                deDateTo.DateTime = deDateFrom.DateTime.AddDays(6);
            }
            else
            {
                LoadRestDay();
            }
        }

        private void deDateTo_EditValueChanged(object sender, EventArgs e)
        {
            LoadRestDay();
        }

        private void LoadRestDay()
        {
            DateTime DateFrom = deDateFrom.DateTime;
            DateTime DateTo = deDateTo.DateTime;
            int NofDays = Math.Min(DateTo.Subtract(DateFrom).Days + 1, 7);

            if (NofDays < 7)
            {
                for (int ci = 3; ci < 10; ci++)
                {
                    //gridViewEmployee.Columns[ci].Visible = false;
                    DisableColumn(gridViewEmployee.Columns[ci]);
                }
                for (DateTime date = DateFrom; date <= DateTo; date = date.AddDays(1))
                {
                    int DayIndex = (int)date.DayOfWeek;
                    if (DayIndex == 0)
                    {
                        DayIndex = 7;
                    }

                    EnableColumn(gridViewEmployee.Columns[DayIndex + 2]);
                    //gridViewEmployee.Columns[DayIndex + 2].Visible = true;
                    //gridViewEmployee.Columns[DayIndex + 2].VisibleIndex = DayIndex + 1;
                }
            }
            else
            {
                for (int ci = 3; ci < 10; ci++)
                {
                    EnableColumn(gridViewEmployee.Columns[ci]);
                    //gridViewEmployee.Columns[ci].Visible = true;
                    //gridViewEmployee.Columns[ci].VisibleIndex = ci - 1;
                }
            }

            var dsRestDay = EmployeeRestDayDALObj.GetRestDayDetails(DateFrom, DateTo);

            foreach (var Employee in dsEmployeeRestDay)
            {
                foreach(var dayView in Employee.RestDayDetailDataSource)
                {
                    dayView.RestDay = dsRestDay.Any(r => r.EmployeeID == Employee.EmployeeID && r.RestDay == dayView.Day);
                }
                //for (int ri = 0; ri < NofDays; ri++)
                //{
                //    DayOfWeek Day = (DayOfWeek)(ri >= 6 ? 0 : ri + 1);
                //    Employee.RestDayDetailDataSource[ri].RestDay = dsRestDay.Any(r => r.EmployeeID == Employee.EmployeeID && r.RestDay == Day);
                //}
            }

            if (NofDays < 7)
            {
                foreach (var Employee in dsEmployeeRestDay)
                {
                    for (int ri = NofDays; ri < 7; ri++)
                    {
                        Employee.RestDayDetailDataSource[ri].RestDay = false;
                    }
                }
            }

            gridViewEmployee.RefreshData();
            gridViewEmployee.Invalidate();
        }

        void EnableColumn(GridColumn Column)
        {
            Column.OptionsColumn.ReadOnly = false;
            Column.OptionsColumn.AllowEdit = true;
            Column.OptionsColumn.TabStop = true;
            Column.AppearanceCell.BackColor = Color.Empty;
        }

        void DisableColumn(GridColumn Column)
        {
            Column.OptionsColumn.ReadOnly = true;
            Column.OptionsColumn.AllowEdit = false;
            Column.OptionsColumn.TabStop = false;
            Column.AppearanceCell.BackColor = Color.LightGray;
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            gridViewEmployee.PostEditor();
        }
    }
}
