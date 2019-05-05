using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Employee
{
    public class EmployeeAccountingLedgerEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int EmployeeAccountingLedgerID { get; set; }

        [DisplayName("Accounting Ledger")]
        public string EmployeeAccountingLedgerName { get; set; }
    }

    public class EmployeeAccountingLedgerLookupListModel
    {
        [Browsable(false)]
        public int EmployeeAccountingLedgerID { get; set; }

        [DisplayName("Accounting Ledger")]
        public string EmployeeAccountingLedgerName { get; set; }
    }
}
