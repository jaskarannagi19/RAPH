using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.WinForm.Reports
{
    public partial class ucEmployeeFilter : UserControl
    {
        #region Fields
        DAL.Employee.EmployeeDepartmentDAL DepartmentDALObj;
        DAL.Employee.EmployeeDesignationDAL DesignationDALObj;
        DAL.Settings.LocationDAL LocationDALObj;

        DAL.Employee.EmployeeDAL EmployeeDAL;
        List<Model.Employee.EmployeeLookupListModel> dsEmployeeLookup;
        List<Model.Employee.EmployeeDepartmentLookupListModel> dsDepartment;
        List<Model.Employee.EmployeeDesignationLookupListModel> dsDesignation;
        List<Model.Settings.LocationLookupListModel> dsLocation;
        #endregion

        #region Properties

        bool ShowDateRangeFilter_;
        [DefaultValue(true)]
        [DisplayName("Show Date Range Filter")]
        public bool ShowDateRangeFilter
        {
            get
            {
                return ShowDateRangeFilter_;
            }
            set
            {
                ShowDateRangeFilter_ = value;
                if (ShowDateRangeFilter_)
                {
                    lcgDateFromTo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    lcgDateFromTo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    deDateFrom.EditValue = null;
                    deDateTo.EditValue = null;
                }
            }
        }

        public DateTime DateFrom
        {
            get { return deDateFrom.DateTime; }
            set { deDateFrom.DateTime = value; }
        }

        public DateTime DateTo
        {
            get { return deDateTo.DateTime; }
            set { deDateTo.DateTime = value; }
        }

        public int DesignationID
        {
            get { return (int?)lookupDesignation.EditValue ?? 0; }
            set { lookupDesignation.EditValue = value; }
        }

        public int DepartmentID
        {
            get { return ((int?)lookupDepartment.EditValue) ?? 0; }
            set { lookupDepartment.EditValue = value; }
        }

        public int LocationID
        {
            get { return ((int?)lookupLocation.EditValue) ?? 0; }
            set { lookupLocation.EditValue = value; }
        }

        public int EmploymentType
        {
            get { return cmbEmployementType.SelectedIndex; }
            set { cmbEmployementType.SelectedIndex = (int)value; }
        }
        #endregion

        #region Event
        public event EventHandler DesignationIDChanged;
        public event EventHandler DepartmentIDChanged;
        public event EventHandler LocationIDChanged;
        public event EventHandler EmployementTypeChanged;
        #endregion

        public ucEmployeeFilter()
        {
            InitializeComponent();

            EmployeeDAL = new DAL.Employee.EmployeeDAL();
            DepartmentDALObj = new DAL.Employee.EmployeeDepartmentDAL();
            DesignationDALObj = new DAL.Employee.EmployeeDesignationDAL();
            LocationDALObj = new DAL.Settings.LocationDAL();

            ShowDateRangeFilter_ = true;
        }

        public void LoadLookupDataSource()
        {
            dsEmployeeLookup = EmployeeDAL.GetLookupList();

            dsDepartment = DepartmentDALObj.GetLookupList();
            dsDepartment.Insert(0, new Model.Employee.EmployeeDepartmentLookupListModel() { EmployeeDepartmentID = -1, EmployeeDepartmentName = "(ALL)" });

            dsDesignation = DesignationDALObj.GetLookupList();
            dsDesignation.Insert(0, new Model.Employee.EmployeeDesignationLookupListModel { EmployeeDesignationID = -1, EmployeeDesignationName = "(ALL)" });

            dsLocation = LocationDALObj.GetLookupList();
            dsLocation.Insert(0, new Model.Settings.LocationLookupListModel { LocationID = -1, LocationName = "(ALL)" });
        }

        public void AssignLookupDataSource()
        {
            lookupDepartment.Properties.ValueMember = "EmployeeDepartmentID";
            lookupDepartment.Properties.DisplayMember = "EmployeeDepartmentName";
            lookupDepartment.Properties.DataSource = dsDepartment;
            lookupDepartment.EditValue = -1;

            lookupDesignation.Properties.ValueMember = "EmployeeDesignationID";
            lookupDesignation.Properties.DisplayMember = "EmployeeDesignationName";
            lookupDesignation.Properties.DataSource = dsDesignation;
            lookupDesignation.EditValue = -1;

            lookupLocation.Properties.ValueMember = "LocationID";
            lookupLocation.Properties.DisplayMember = "LocationName";
            lookupLocation.Properties.DataSource = dsLocation;
            lookupLocation.EditValue = -1;
        }

        private void deDateFrom_Validating(object sender, CancelEventArgs e)
        {
            if (deDateFrom.EditValue == null)
            {
                ErrorProvider.SetError(deDateFrom, "Please enter date from");
            }
            else
            {
                ErrorProvider.SetError(deDateFrom, "");
            }
        }

        private void deDateTo_Validating(object sender, CancelEventArgs e)
        {
            if (deDateTo.EditValue == null)
            {
                ErrorProvider.SetError(deDateTo, "Please enter date to");
            }
            else if (deDateTo.DateTime.Subtract(deDateFrom.DateTime).Days > 31)
            {
                ErrorProvider.SetError(deDateTo, "Date from and to should be in range of maximum 31 days");
            }
            else
            {
                ErrorProvider.SetError(deDateTo, "");
            }
        }

        private void lookupDesignation_EditValueChanged(object sender, EventArgs e)
        {
            DesignationIDChanged?.Invoke(this, null);
        }

        private void lookupDepartment_EditValueChanged(object sender, EventArgs e)
        {
            DepartmentIDChanged?.Invoke(this, null);
        }

        private void lookupLocation_EditValueChanged(object sender, EventArgs e)
        {
            LocationIDChanged?.Invoke(this, null);
        }

        private void cmbEmployementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployementTypeChanged?.Invoke(this, null);
        }
    }
}
