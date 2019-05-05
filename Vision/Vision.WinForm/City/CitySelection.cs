using Alit.WinformControls;
using Vision.DAL.City;
using Vision.Model.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.WinForm.City
{
    public class CitySelection
    {
        public LookUpEdit LookupCountry { get; private set; }
        public LookUpEdit LookupState { get; private set; }
        public LookUpEdit LookupCity { get; private set; }

        public CityEditListModel SelectedCity { get; set; }

        public bool ApplyCityRequiredValidation { get; set; }

        public ErrorProvider ErrorProvider { get; set; }

        public CitySelection(LookUpEdit lueCountry, LookUpEdit lueState, LookUpEdit lueCity, ErrorProvider EP)
        {
            LookupCountry = lueCountry;
            LookupCountry.EditValueChanged += LookupCountry_EditValueChanged;

            LookupState = lueState;
            LookupState.EditValueChanged += LookupState_EditValueChanged;
            
            LookupCity = lueCity;
            LookupCity.Validating += LookupCity_Validating;

            ErrorProvider = EP;
        }

        public void InitializeValues()
        {
            LookupCity.Properties.ValueMember = "CityID";
            LookupCity.Properties.DisplayMember = "CityName";

            LookupState.Properties.ValueMember = "StateID";
            LookupState.Properties.DisplayMember = "StateName";

            CountryDAL CountryDAL = new CountryDAL();
            LookupCountry.Properties.ValueMember = "CountryID";
            LookupCountry.Properties.DisplayMember = "CountryName";
            LookupCountry.Properties.DataSource = CountryDAL.GetEditList();
        }

        void LookupCountry_EditValueChanged(object sender, EventArgs e)
        {
            if (LookupCountry.EditValue == null)
            {
                LookupState.Properties.DataSource = null;
            }
            else
            {
                StateDAL StateDAL = new StateDAL();
                LookupState.Properties.DataSource = StateDAL.GetLookupList((int)LookupCountry.EditValue);
            }
        }

        void LookupState_EditValueChanged(object sender, EventArgs e)
        {
            if (LookupCountry.EditValue == null)
            {
                LookupCity.Properties.DataSource = null;
            }
            else
            {
                CityDAL CityDAL = new CityDAL();
                LookupCity.Properties.DataSource = CityDAL.GetLookupList();
            }
        }

        void LookupCity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(ErrorProvider != null)
            {
                if(LookupCity.EditValue == null)
                {
                    ErrorProvider.SetError(LookupCity, "Please select city.");
                }
                else
                {
                    ErrorProvider.SetError(LookupCity, "");
                }
            }
        }
    }
}
