using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.City;

namespace Vision.Model.Settings
{
    public class CompanyEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int CompanyID { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
    }

    public class CompanyDetailViewModel
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int CityID { get; set; }
        public string PIN { get; set; }
        public string Phone1 { get; set; }
        public string MobileNo1 { get; set; }
        public string EMailID { get; set; }
        public string Website { get; set; }
        public string PAN { get; set; }
        public string GSTIN { get; set; }
        public string LicenseName { get; set; }
        public string LicenseNo { get; set; }
        public string Jurisdiction { get; set; }
        public DateTime BusinessStartedFrom { get; set; }
        public string DirectorName { get; set; }
        public string ServiceTaxNo { get; set; }
        public string BankName { get; set; }
        public string BankCity { get; set; }
        public string BankBranch { get; set; }
        public string BankIFSC { get; set; }
        public string BankAccountNo { get; set; }
        public string BankAccountName { get; set; }

        public CityDetailViewModel City { get; set; }

    }

    public class CompanyMultiSelectLookupModel
    {
        [Browsable(false)]
        public int CompanyID { get; set; }

        [DisplayName("Select")]
        public bool Selected { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
    }

    public class CompanyLookupModel
    {
        [Browsable(false)]
        public int CompanyID { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
    }
}
