using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vision.WinForm
{
    public static class CommonFunctions
    {
        public static void SetCurrencyMask(DevExpress.XtraEditors.TextEdit TextBox)
        {
            TextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            TextBox.Properties.Mask.EditMask = Model.CommonProperties.UIDataFormats.CurrencyMask;
            TextBox.Properties.Mask.BeepOnError = true;
            TextBox.Properties.Mask.UseMaskAsDisplayFormat = true;
            TextBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        }

        public static void SetQuantityMask(DevExpress.XtraEditors.TextEdit TextBox)
        {
            TextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            TextBox.Properties.Mask.EditMask = Model.CommonProperties.UIDataFormats.QuantityFormat;
            TextBox.Properties.Mask.BeepOnError = true;
        }

        public static void LoadLanguage(Model.Settings.eUILanguage Language)
        {
            string LanguageName = (Language == Model.Settings.eUILanguage.Turkish ? "tr" : "en");
            Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageName);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageName);//

            if (LanguageName != "En")
            {
                Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalDigits = 2;
                Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
                Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
                Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = "Rp";
                Thread.CurrentThread.CurrentCulture.NumberFormat.DigitSubstitution = DigitShapes.None;
                Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalDigits = 2;
                Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
                Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
                Thread.CurrentThread.CurrentCulture.NumberFormat.PercentDecimalDigits = 2;
                Thread.CurrentThread.CurrentCulture.NumberFormat.PercentDecimalSeparator = ".";
                Thread.CurrentThread.CurrentCulture.NumberFormat.PercentGroupSeparator = ",";
            }

            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
        }

        public static int EditValueToInt(this Alit.WinformControls.TextEdit obj)
        {
            return Model.CommonFunctions.ParseInt(obj.Text);
        }

        public static decimal EditValueToDecimal(this Alit.WinformControls.TextEdit obj)
        {
            return Model.CommonFunctions.ParseDecimal(obj.Text);
        }

        public static long EditValueToLong(this Alit.WinformControls.TextEdit obj)
        {
            return Model.CommonFunctions.ParseLong(obj.Text);
        }
    }
}
