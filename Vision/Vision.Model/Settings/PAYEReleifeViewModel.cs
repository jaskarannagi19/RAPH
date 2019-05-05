using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Settings
{
    public enum ePAYEReliefeMandatory
    {
        No = 0,
        Yes = 1,
    }

    public enum ePAYEReliefType
    {
        General = 0,
        PersonalRelief = 1,
    }

    public class PAYEReliefeViewModel : EditUserInfo
    {
        [Browsable(false)]
        public int PAYEReliefID { get; set; }

        [DisplayName("PAYE Relief Name")]
        public string PAYEReliefName { get; set; }

        [DisplayName("Mandatory")]
        public ePAYEReliefeMandatory Mandatory { get; set; }

        [DisplayName("Relief Type")]
        public ePAYEReliefType PAYEReliefType { get; set; }

        [DisplayName("Monthly Limit")]
        public decimal MonthlyLimit { get; set; }

        [DisplayName("Annual Limit")]
        public decimal AnnualLimit { get; set; }

        [DisplayName("Effective From")]
        [Description("Effective from date, it is ready only and it shows the current was effective from which date")]
        public DateTime? WEDate { get; set; }

        public string RowPreview
        {
            get
            {
                string PreviewText = string.Empty;
                if (!String.IsNullOrWhiteSpace(SavingError))
                {
                    PreviewText = SavingError;
                }
                //else if (PAYEReliefID != 0)
                //{
                //    if (!string.IsNullOrWhiteSpace(CreatedUserName) || CreatedDateTime != null)
                //    {
                //        PreviewText = $"Create by {CreatedUserName} AT { (CreatedDateTime.HasValue ? CreatedDateTime.Value.ToString("g") : "")}";
                //    }
                //    if (!string.IsNullOrWhiteSpace(EditedUserName) || EditedDateTime != null)
                //    {
                //        PreviewText += (!String.IsNullOrWhiteSpace(PreviewText) ? "\r\n" : "") + 
                //            $"Edited by {EditedUserName} AT { (EditedDateTime.HasValue ? EditedDateTime.Value.ToString("g") : "")}";
                //    }
                //}
                return PreviewText;
            }
        }

        public string SavingError { get; set; }
    }


    public class PAYEReliefLookupListModel
    {
        [Browsable(false)]
        public int PAYEReliefID { get; set; }

        [DisplayName("PAYE Relief Name")]
        public string PAYEReliefName { get; set; }
    }

    public class PAYEReliefTypeLookupModel
    {
        [DisplayName("Relief Type")]
        public ePAYEReliefType PAYEReliefType { get; set; }
    }
}
