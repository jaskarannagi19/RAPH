using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL.Settings;
using Vision.DAL;

namespace Vision.WinForm.Settings
{
    public partial class frmPayrollMonth : Template.frmNormalTemplate
    {
        PayrollMonthDAL DALObject;

        public frmPayrollMonth()
        {
            InitializeComponent();
            DALObject = new PayrollMonthDAL();
        }

        public override void AssignFormValues()
        
        {
            tblPayrollMonth Record = DALObject.GetLatestPayrollMonthByCompanyID(Vision.Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);

            textPayrollStartDate.Text = Record.PayrollMonthStartDate.ToString();
            textPayrollEndDate.Text = Record.PayrollMonthEndDate.ToString();

            textPreviousMonthName.Text = Record.PayrollMonthName;

           base.AssignFormValues();
        }


    }
}
