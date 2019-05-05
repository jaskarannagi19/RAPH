using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.Model;

namespace Vision.WinForm.Payroll
{
    public partial class frmMinimumWageCategoryRateChange : Template.frmNormalTemplate
    {
        DAL.Payroll.MinimumWageCategoryDAL DALObj;
        List<Model.Payroll.MinimumWageCategoryRateChangeListModel> dsRateChange;
        public frmMinimumWageCategoryRateChange()
        {
            InitializeComponent();
            FirstControl = dtpWithEffectDate;
            DALObj = new DAL.Payroll.MinimumWageCategoryDAL();
            FirstControl = dtpWithEffectDate;
        }

        public override void LoadFormValues()
        {
            dsRateChange = DALObj.GetMinimumWageCategoryRate();
            base.LoadFormValues();
        }

        public override void AssignFormValues()
        {
            gcRate.DataSource = dsRateChange;

            gvRate.Columns["MinimumWageCategoryName"].OptionsColumn.AllowFocus = false;
            gvRate.Columns["MinimumWageCategoryName"].OptionsColumn.TabStop = false;
            gvRate.Columns["MinimumWageCategoryName"].OptionsColumn.ReadOnly = true;
            gvRate.Columns["MinimumWageCategoryName"].MaxWidth = 500;

            gvRate.Columns["RuleApplyOn"].OptionsColumn.AllowFocus = false;
            gvRate.Columns["RuleApplyOn"].OptionsColumn.TabStop = false;
            gvRate.Columns["RuleApplyOn"].OptionsColumn.ReadOnly = true;
            gvRate.Columns["RuleApplyOn"].MaxWidth = 150;

            gvRate.Columns["UrbanRate"].MaxWidth = 200;
            gvRate.Columns["RuralRate"].MaxWidth = 200;

            base.AssignFormValues();
        }

        protected override void OnShown(EventArgs e)
        {
            Application.DoEvents();
            SetFocusOnFirstControl();
            base.OnShown(e);
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObj.SaveMinimumWageCategoryRate(dsRateChange, (DateTime?)dtpWithEffectDate.EditValue);

            base.SaveRecord(Paras);
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            if(Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                this.Close();
            }
            base.AfterSaving(Paras);
        }

        private void dtpWithEffectDate_Validating(object sender, CancelEventArgs e)
        {
            if(dtpWithEffectDate.EditValue == null)
            {
                ErrorProvider.SetError(dtpWithEffectDate, "Please enter with effect date.");
            }
            else
            {
                ErrorProvider.SetError(dtpWithEffectDate, "");
            }
        }
    }
}
