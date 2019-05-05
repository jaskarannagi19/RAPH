using Vision.Model;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.WinForm.Template
{
    public class BaseTemplate : XtraForm
    {
        int MenuOptionID_;
        public int MenuOptionID
        {
            get
            {
                return MenuOptionID_;
            }
            set
            {
                if (MenuOptionID_ != value)
                {
                    MenuOptionID_ = value;

                    //DAL.Users.UserGroupDAL UGDALObj = new DAL.Users.UserGroupDAL();
                    var perm = CommonProperties.LoginInfo.UserPermission.FirstOrDefault(r => r.MenuOptionID == MenuOptionID_);
                    if (perm != null)
                    {
                        MenuOptionPermission = perm;
                    }
                    else
                    {
                        MenuOptionPermission = new Model.Users.MenuOptionPermissionViewModel()
                        {
                            MenuOptionID = MenuOptionID_,
                            CanAdd = true,
                            CanDelete = true,
                            CanEdit = true,
                            CanView = true,
                            CanAuthorize = true,
                            CanUnAuthorize = true,
                        };
                    }
                    if (CommonProperties.LoginInfo.LoggedinUser.SuperUser)
                    {
                        MenuOptionPermission.CanAdd = true;
                        MenuOptionPermission.CanEdit = true;
                        MenuOptionPermission.CanDelete = true;
                        MenuOptionPermission.CanAuthorize = true;
                        MenuOptionPermission.CanUnAuthorize = true;
                    }
                }
            }
        }

        public BaseTemplate()
        {
        }

        public Model.Users.MenuOptionPermissionViewModel MenuOptionPermission { get; set; }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            MemoryManagement.FlushMemory();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseTemplate));
            this.SuspendLayout();
            // 
            // BaseTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "BaseTemplate";
            this.ResumeLayout(false);

        }
    }
}
