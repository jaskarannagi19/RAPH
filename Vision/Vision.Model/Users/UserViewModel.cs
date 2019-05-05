using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Users
{
    public class UserEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int UserID { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Group")]
        public string UserGroupName { get; set; }
    }

    public class UserLookupModel
    {
        [Browsable(false)]
        public int UserID { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }
    }

    public class UserDetailModel
    {
        [Browsable(false)]
        public int UserID { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        public int UserGroupID { get; set; }

        public string UserGroupName { get; set; }

        public bool SuperUser { get; set; }

        public string EMailID { get; set; }
    }
}
