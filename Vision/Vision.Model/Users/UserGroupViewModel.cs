using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Users
{
    public class UserGroupEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int UserGroupID { get; set; }

        [DisplayName("User Group Name")]
        public string UserGroupName { get; set; }

        //[DisplayName("Role")]
        //public string UserGroupRoleName { get; set; }
    }

    public class UserGroupLookupModel
    {
        [Browsable(false)]
        public int UserGroupID { get; set; }

        [DisplayName("User Group Name")]
        public string UserGroupName { get; set; }
    }

    public class MenuOptionPermissionViewModel
    {
        [Browsable(false)]
        public int MenuOptionID { get; set; }

        [DisplayName("Menu")]
        public string MenuOptionName { get; set; }

        [DisplayName("Group")]
        public string MenuOptionGroupName { get; set; }

        [Browsable(false)]
        public Model.Settings.eMenuOptionType MenuOptionType { get; set; }

        [DisplayName("Can View")]
        public bool CanView { get; set; }

        [DisplayName("Can Add")]
        public bool CanAdd { get; set; }

        [DisplayName("Can Edit")]
        public bool CanEdit { get; set; }

        [DisplayName("Can Delete")]
        public bool CanDelete { get; set; }

        [DisplayName("Can Authorize")]
        public bool CanAuthorize { get; set; }

        [DisplayName("Can Un-Authorize")]
        public bool CanUnAuthorize { get; set; }
    }

    public class LocationUserGroupAccessMultiSelectListModel
    {
        [DisplayName("Select")]
        public bool Selected { get; set; }

        [Browsable(false)]
        public int LocationID { get; set; }

        [DisplayName("Location Name")]
        public string LocationName { get; set; }

        [Browsable(false)]
        public int CompanyID { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
    }
}
