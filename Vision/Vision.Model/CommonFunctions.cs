using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model
{
    public static class CommonFunctions
    {
        public static bool CheckParseInt(string strValue)
        {
            int v = 0;
            return int.TryParse(strValue, out v);
        }

        public static bool CheckParseLong(string strValue)
        {
            long v = 0;
            return long.TryParse(strValue, out v);
        }

        public static bool CheckParseDecimal(string strValue)
        {
            decimal v = 0;
            return decimal.TryParse(strValue, out v);
        }

        public static int ParseInt(string strValue)
        {
            int v = 0;
            int.TryParse(strValue, out v);
            return v;
        }

        public static long ParseLong(string strValue)
        {
            long v = 0;
            long.TryParse(strValue, out v);
            return v;
        }

        public static decimal ParseDecimal(string strValue)
        {
            decimal v = 0;
            decimal.TryParse(strValue, out v);
            return v;
        }

        public static bool CheckDateCurrentFinPer(DateTime DateValue)
        {
            return (Model.CommonProperties.LoginInfo.LoggedInFinPeriod != null &&
                DateValue >= Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom &&
                (Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo == null ||
                    DateValue <= Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo));
        }

        /// <summary>
        /// Get Initial date for any voucher or data entry form.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetVoucherDate()
        {
            DateTime date = DateTime.Now.Date;
            if (date < Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom)
            {
                date = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.Date;
            }
            else if (Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo != null &&
                        date > Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value)
            {
                date = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.Date;
            }
            return date;
        }

        public static int GetMonthDifference(DateTime DateFrom, DateTime DateTo)
        {
            return ((DateTo.Year - DateFrom.Year) * 12) + DateTo.Month - DateFrom.Month;
        }

        public static object CloneObject(object Source)
        {
            object Destination = Activator.CreateInstance(Source.GetType());
            var fields = Destination.GetType().GetProperties();

            foreach (var field in fields)
            {
                var value = field.GetValue(Source);
                field.SetValue(Destination, value);
            }
            return Destination;
        }

        public static System.Data.Linq.Binary ConvertImageToBinary(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                return new System.Data.Linq.Binary(ms.GetBuffer());
            }
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static string NumbersToWords(decimal inputNumber)
        {
            long inputNo = (long)inputNumber;

            if (inputNo == 0)
                return "Zero";

            long[] numbers = new long[5];
            long first = 0;
            long u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }

            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ", "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore ", "Arab " };

            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs
            numbers[4] = inputNo / 1000000000; // Arab
            numbers[3] = numbers[3] - 100 * numbers[4]; // crores


            for (int i = 4; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (long i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if ((h > 0 || i == 0) && sb.Length > 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }

            if(sb.Length > 0)
            {
                //sb.Append("Rs ");
                int DecValue = (int)(Math.Round(inputNumber - (decimal)inputNo, 2) * 100);
                if(DecValue > 0)
                {
                    string DecText = NumbersToWords(DecValue);
                    DecText = DecText.Substring(0, Math.Max(DecText.Length - 3, 0));
                    if (!DecText.Trim().StartsWith("and"))
                    {
                        DecText = "and " + DecText;
                    }
                    sb.Append(DecText);
                    sb.Append("Ps ");
                }
            }

            return "Rs. " + sb.ToString().TrimEnd();
        }

        public static Users.MenuOptionPermissionViewModel GetCurreUserPermission(long MenuOptionID)
        {
            if (Model.CommonProperties.LoginInfo.UserPermission != null)
            {
                return Model.CommonProperties.LoginInfo.UserPermission.FirstOrDefault(r => r.MenuOptionID == MenuOptionID);
            }
            else
            {
                return null;
            }
        }

        public static void SendEmailFromNoReply(string SendToIds, string Subject, string MessageBody, params Attachment[] Attachments)
        {
            //SendEmail("noreply@alittech.com", "ReplyMe@123.Com", SendToIds, Subject, MessageBody, false, Attachments);
            SendEmail(CommonProperties.LoginInfo.SoftwareSettings.NoReply_EmailID, 
                CommonProperties.LoginInfo.SoftwareSettings.NoReply_Password,
                CommonProperties.LoginInfo.SoftwareSettings.NoReply_SMTPHost,
                CommonProperties.LoginInfo.SoftwareSettings.NoReply_SMTPPort,
                CommonProperties.LoginInfo.SoftwareSettings.NoReply_SSL,
                SendToIds, Subject, MessageBody, 
                Attachments);
        }

        public static async Task SendEmailFromNoReplyAsync(string SendToIds, string Subject, string MessageBody, params Attachment[] Attachments)
        {
            await SendEmailAsync(CommonProperties.LoginInfo.SoftwareSettings.NoReply_EmailID,
                CommonProperties.LoginInfo.SoftwareSettings.NoReply_Password,
                CommonProperties.LoginInfo.SoftwareSettings.NoReply_SMTPHost,
                CommonProperties.LoginInfo.SoftwareSettings.NoReply_SMTPPort,
                CommonProperties.LoginInfo.SoftwareSettings.NoReply_SSL,
                SendToIds, Subject, MessageBody, Attachments);
        }

        //public static void SendEmail(string FromEmailID, string FromEmailPassword, string SendToIds, string Subject, string MessageBody, bool SSL, params Stream[] AttachmentStream)
        //{
        //    SendEmailAsync(FromEmailID, FromEmailPassword, SendToIds, Subject, MessageBody, SSL, AttachmentStream).RunSynchronously();
        //}

        public static void SendEmail(
                    string FromEmailID,
                    string FromEmailPassword,
                    string FromEmailSMTPHost,
                    int FromEmailSMTPPort,
                    bool EnableSSL,
                    
                    string SendToIds,
                    string Subject,
                    string MessageBody,
                    params Attachment[] Attachments)
        {
            // Command line argument must the the SMTP host.
            SmtpClient SMTPClient = new SmtpClient();
            SMTPClient.Host = FromEmailSMTPHost;
            SMTPClient.Port = FromEmailSMTPPort;
            SMTPClient.EnableSsl = EnableSSL;
            //SMTPClient.Timeout = 10000;
            SMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SMTPClient.UseDefaultCredentials = false;

            SMTPClient.Credentials = new System.Net.NetworkCredential(FromEmailID, FromEmailPassword);
            //MailMessage mm = new MailMessage("donotreply@domain.com", "sendtomyemail@domain.co.uk", "test", "test");
            //mm.BodyEncoding = UTF8Encoding.UTF8;
            //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            MailMessage Mail = new MailMessage();// FromEmailID, SendToIds, Subject, MessageBody);
            Mail.From = new MailAddress(FromEmailID);
            Mail.To.Add(new MailAddress(SendToIds));
            Mail.Subject = Subject;
            Mail.Body = MessageBody;
            Mail.Priority = MailPriority.High;
            Mail.IsBodyHtml = true;
            Mail.BodyEncoding = Encoding.Default;

            foreach (var att in Attachments)
            {
                Mail.Attachments.Add(att);
            }

            try
            {
                SMTPClient.Send(Mail);
            }
            catch (Exception) { }
        }

        public static async Task SendEmailAsync(string FromEmailID, 
            string FromEmailPassword,
            string FromEmailSMTPHost,
            int FromEmailSMTPPort,
            bool EnableSSL,
            string SendToIds, 
            string Subject, 
            string MessageBody, 
            params Attachment[] Attachments)
        {
            // Command line argument must the the SMTP host.
            SmtpClient SMTPClient = new SmtpClient();
            SMTPClient.Host = FromEmailSMTPHost;
            SMTPClient.Port = FromEmailSMTPPort;
            SMTPClient.EnableSsl = EnableSSL;
            //SMTPClient.Timeout = 10000;
            SMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SMTPClient.UseDefaultCredentials = false;

            SMTPClient.Credentials = new System.Net.NetworkCredential(FromEmailID, FromEmailPassword);

            //MailMessage mm = new MailMessage("donotreply@domain.com", "sendtomyemail@domain.co.uk", "test", "test");
            //mm.BodyEncoding = UTF8Encoding.UTF8;
            //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            MailMessage Mail = new MailMessage(FromEmailID, SendToIds, Subject, MessageBody);

            foreach (var att in Attachments)
            {
                Mail.Attachments.Add(att);
            }

            try
            {
                await SMTPClient.SendMailAsync(Mail);
            }
            catch (Exception) { }
        }

    }


    public static class CommonProperties
    {
        public static class DevelopmentCompanyInfo
        {
            public const string CompanyName = "Alit Technologies";

            public const string CompanyShortName = "Alit";

            public static string ProductName { get; set; }

            public const string CompanyEmailSMTPHost = "mail.alittech.com";
            public const int CompanyEmailSMTPPort = 25;

        }

        /// <summary>
        /// User Interface Data Formats
        /// </summary>
        public static class UIDataFormats
        {
            public static int AmountDecimalLen { get { return 2; } }
            public static int QuantityDecimalLen { get { return 2; } }
            public static int RateDecimalLen { get { return 2; } }

            public static string AmountFormat { get { return "n" + "".PadRight(AmountDecimalLen, '0'); } }
            public static string QuantityFormat { get { return "n" + "".PadRight(QuantityDecimalLen, '0'); } }
            public static string RateFormat { get { return "n" + "".PadRight(RateDecimalLen, '0'); } }

            public const string CurrencyMask = "n2";
        }

        private static Bitmap BlankImage_;
        public static Bitmap BlankImage
        {
            get
            {
                if (BlankImage_ == null)
                {
                    BlankImage_ = new Bitmap(1, 1);
                }
                return BlankImage_;
            }
        }


        public static class LoginInfo 
        {
            private static Users.UserDetailModel LoggedinUser_;
            public static Users.UserDetailModel LoggedinUser
            {
                get { return LoggedinUser_; }
                set
                {
                    LoggedinUser_ = value;
                }
            }

            private static Settings.CompanyDetailViewModel LoggedInCompany_;
            public static Settings.CompanyDetailViewModel LoggedInCompany
            {
                get { return LoggedInCompany_; }
                set
                {
                    LoggedInCompany_ = value;
                }
            }

            static Settings.FinPeriodDetailModel LoggedInFinPeriod_;
            public static Settings.FinPeriodDetailModel LoggedInFinPeriod
            {
                get { return LoggedInFinPeriod_; }
                set
                {
                    LoggedInFinPeriod_ = value;
                }
            }


            private static Settings.ApplicationSettingsViewModel SoftwareSettings_;
            public static Settings.ApplicationSettingsViewModel SoftwareSettings
            {
                get { return SoftwareSettings_; }
                set
                {
                    SoftwareSettings_ = value;
                }
            }

            public static Model.Reports.CompanyDetailReportModel LoggedInCompanyReportModel
            {
                get;
                set;
            }

            public static List<Model.Users.MenuOptionPermissionViewModel> UserPermission { get; set; }

            //Others.ReportSettingsView ReportSettings_;
            //public Others.ReportSettingsView ReportSettings
            //{
            //    get { return ReportSettings_; }
            //    set
            //    {
            //        ReportSettings_ = value;
            //    }
            //}

            //public string DefaultConnectionString
            //{
            //    get
            //    {
            //        return Model.Properties.Settings.Default.AMWSMConnectionString;
            //    }
            //    set
            //    {
            //        Model.Properties.Settings.Default.AMWSMConnectionString = value;
            //    }
            //}
        }

        public const string MarkerAdminURL = "http://localhost:65447/";
    }

    //[System.AttributeUsage(System.AttributeTargets.Property)]
    //public class DatabaseFieldMapping : System.Attribute
    //{
    //    /// <summary>
    //    /// Indicated that: Is this property is not related to database field. If false then FieldName attribute must assign a value.
    //    /// </summary>
    //    public bool IsNotDatabaseField { get; set; }

    //    /// <summary>
    //    /// Field Name in database
    //    /// </summary>
    //    public string FieldName { get; set; }

    //    /// <summary>
    //    /// Field Data Type
    //    /// </summary>
    //    public Type DataType { get; set; }

    //    /// <summary>
    //    /// Field data length
    //    /// </summary>
    //    public int FieldLength { get; set; }

    //    /// <summary>
    //    /// Field Data length for decimal
    //    /// </summary>
    //    public int FieldDecimalLength { get; set; }

    //    /// <summary>
    //    /// Field Data Type/ Field behaviour
    //    /// </summary>
    //    public eFieldType FieldType { get; set; }

    //    /// <summary>
    //    /// Foreign key relation class.
    //    /// </summary>
    //    public Type ForeignKeyRelationClass { get; set; }

    //    /// <summary>
    //    /// Foriegn key relation Field Name from which it is connected to.
    //    /// </summary>
    //    public string ForeignKeyRelationFieldName { get; set; }

    //    /// <summary>
    //    /// Foriegn key Description Property Name. Property name of the same class in which foriegn key description will fetch and display. It is not related to database field.
    //    /// </summary>
    //    public string ForeignKeyDescriptionPropertyName { get; set; }

    //    public DatabaseFieldMapping() { }

    //    public DatabaseFieldMapping(string FieldName, Type DataType)
    //        : this(FieldName, DataType, 0, 0)
    //    { }

    //    public DatabaseFieldMapping(string FieldName, Type DataType, eFieldType FieldType)
    //        : this(FieldName, DataType, 0, 0, FieldType)
    //    { }

    //    public DatabaseFieldMapping(string FieldName, Type DataType, eFieldType FieldType, Type ForiegnKeyRelationClass)
    //        : this(FieldName, DataType, FieldType)
    //    {
    //        this.ForeignKeyRelationClass = ForiegnKeyRelationClass;
    //    }

    //    public DatabaseFieldMapping(string FieldName, Type DataType, int FieldLength)
    //        : this(FieldName, DataType, FieldLength, 0)
    //    { }

    //    public DatabaseFieldMapping(string FieldName, Type DataType, int FieldLength, eFieldType FieldType)
    //        : this(FieldName, DataType, FieldLength, 0, FieldType)
    //    { }

    //    public DatabaseFieldMapping(string FieldName, Type DataType, int FieldLength, eFieldType FieldType, Type ForiegnKeyRelationClass)
    //        : this(FieldName, DataType, FieldLength, FieldType)
    //    {
    //        this.ForeignKeyRelationClass = ForiegnKeyRelationClass;
    //    }

    //    public DatabaseFieldMapping(string FieldName, Type DataType, int FieldLength, int FieldDecimalLength)
    //        : this(FieldName, DataType, FieldLength, FieldDecimalLength, eFieldType.None)
    //    { }

    //    public DatabaseFieldMapping(string FieldName, Type DataType, int FieldLength, int FieldDecimalLength, eFieldType FieldType)
    //    {
    //        this.FieldName = FieldName;
    //        this.DataType = DataType;
    //        this.FieldLength = FieldLength;
    //        this.FieldDecimalLength = FieldDecimalLength;
    //        this.FieldType = FieldType;
    //    }

    //    public DatabaseFieldMapping(string FieldName, Type DataType, int FieldLength, int FieldDecimalLength, eFieldType FieldType, Type ForiegnKeyRelationClass)
    //        : this(FieldName, DataType, FieldLength, FieldDecimalLength, FieldType)
    //    {
    //        this.ForeignKeyRelationClass = ForiegnKeyRelationClass;
    //    }

    //    public enum eFieldType
    //    {
    //        None = 0,
    //        PrimaryKey = 1,
    //        ForiegnKey = 2
    //    }
    //}


    //[System.AttributeUsage(System.AttributeTargets.Class)]
    //public class DatabaseTableMapping : System.Attribute
    //{
    //    public string TableName { get; set; }

    //    public DatabaseTableMapping()
    //    {

    //    }
    //    public DatabaseTableMapping(string TableName)
    //    {
    //        this.TableName = TableName;
    //    }
    //}

}
