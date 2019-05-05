using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.WinformControls
{
    [Browsable(true)]
    [ToolboxItem(true)]
    public class myCheckEdit : CheckEdit
    {
        public myCheckEdit()
        {
            EnterMoveNextControl = true;
        }
    }
}
