using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MSD150SDK
{
    public class MSD150  : IDisposable
    {
        #region Private Members
        int DATASIZE = (1404 + 12) / 4;
        int DATASIZE_FACE = (27668) / 4;
        //int NAMESIZE = 54;
        int[] gTemplngEnrollData =null;
        //Byte[] gbytEnrollData;
        //Byte[] gbytEnrollData1;
        //int[] gTempEnrollName;
        int glngEnrollPData;
        //ASCIIEncoding ascii;
        #endregion

        public int MachineNo { get; }

        public string IPAddress { get; }

        public int PortNo { get; set; }

        public int Password { get; set; }

        public bool DeviceConnected { get; set; }

        public MSD150(int machineNo, string iPAddress, int portNo, int password) : this(machineNo, iPAddress, portNo, password, true)
        {

        }

        public MSD150(int machineNo, string iPAddress, int portNo, int password, bool ConnectImmediately)
        {
            this.MachineNo = machineNo;
            this.IPAddress = iPAddress;
            this.PortNo = portNo;
            this.Password = password;

            if (ConnectImmediately)
            {
                Connect();
            }
        }

        ~MSD150()
        {
            if (DeviceConnected)
            {
                Disconnect();
            }
        }

        public void Dispose()
        {
            if (DeviceConnected)
            {
                Disconnect();
            }
        }

        public void Connect()
        {
            DeviceConnected = SBXPCDLL.ConnectTcpip(this.MachineNo, this.IPAddress, this.PortNo, this.Password);
        }

        public void Disconnect()
        {
            //try
            {
                SBXPCDLL.Disconnect(this.MachineNo);
            }
            //catch { }
            DeviceConnected = false;
        }

        #region Low level method/functions
        public enum eEnrollmentData_BackupNo
        {
            FingerPrint0 = 0,
            FingerPrint1 = 1,
            FingerPrint2 = 2,
            FingerPrint3 = 3,
            FingerPrint4 = 4,
            FingerPrint5 = 5,
            FingerPrint6 = 6,
            FingerPrint7 = 7,
            FingerPrint8 = 8,
            FingerPrint9 = 9,
            /// <summary>
            /// Zero begginning not allowed
            /// </summary>
            Password1 = 10,
            Card = 11,
            UserTimeZone = 14,
            /// <summary>
            /// Zero begginning is allowed
            /// </summary>
            Passwrod2 = 15,
            UserDepartment = 16,
        }

        protected APIResultViewModel GetEnrollmentData(int vEnrollNumber, eEnrollmentData_BackupNo BackupNo)
        {
            int vEMachineNumber;
            int vFingerNumber;
            int vPrivilege = 0;
            Boolean vRet;
            int vErrorCode = 0;
            int i;

            GCHandle gh;
            IntPtr AddrOfTemplngEnrollData;

            APIResultViewModel Result = new APIResultViewModel();

            vRet = SBXPCDLL.EnableDevice(this.MachineNo, 0); // 0 : false
            if (!vRet)
            {
                Result.Result = eExecutionResult.Error;
                Result.Error = "Can not connect to device.";
                return Result;
            }

            vFingerNumber = (int)BackupNo;
            if (vFingerNumber == 10) vFingerNumber = 15;
            vEMachineNumber = this.MachineNo;

            gh = GCHandle.Alloc(gTemplngEnrollData, GCHandleType.Pinned);
            AddrOfTemplngEnrollData = gh.AddrOfPinnedObject();

            glngEnrollPData = 0;

            vRet = SBXPCDLL.GetEnrollData1(this.MachineNo, vEnrollNumber, vFingerNumber, out vPrivilege, AddrOfTemplngEnrollData, out glngEnrollPData);

            gh.Free();

            if (vRet)
            {
                if (vFingerNumber == 11) // Card Number
                {
                    Result.ResultValue = Convert.ToString(glngEnrollPData, 16).ToUpper();
                }
                else if (vFingerNumber == 14) // User timezone
                {
                    Result.ResultValue = Convert.ToString(glngEnrollPData % 64); glngEnrollPData = glngEnrollPData / 64;
                    Result.ResultValue += Convert.ToString(glngEnrollPData % 64); glngEnrollPData = glngEnrollPData / 64;
                    Result.ResultValue += Convert.ToString(glngEnrollPData % 64); glngEnrollPData = glngEnrollPData / 64;
                    Result.ResultValue += Convert.ToString(glngEnrollPData % 64); glngEnrollPData = glngEnrollPData / 64;
                    Result.ResultValue += Convert.ToString(glngEnrollPData % 64); glngEnrollPData = glngEnrollPData / 64;
                }
                else if (vFingerNumber == 15) // Password
                {
                    Result.ResultValue = "";
                    while (glngEnrollPData > 0)
                    {
                        i = glngEnrollPData % 16 - 1;
                        Result.ResultValue += Convert.ToString(i);
                        glngEnrollPData = glngEnrollPData / 16;
                    }
                }
                else if (vFingerNumber == 16) // User department
                {
                    Result.ResultValue = Convert.ToString(glngEnrollPData);
                }
                else if (vFingerNumber == 17) // Face Data
                {
                    Result.ResultValue = "";
                    for (i = 0; i < DATASIZE_FACE; i++)
                        Result.ResultValue += Convert.ToString(gTemplngEnrollData[i]);
                }
                else // other
                {
                    Result.ResultValue = "";
                    for (i = 0; i < DATASIZE; i++)
                        Result.ResultValue += Convert.ToString(gTemplngEnrollData[i]);
                }
            }
            else
            {
                SBXPCDLL.GetLastError(this.MachineNo, out vErrorCode);
                Result.Result = eExecutionResult.Error;
                Result.Error = util.ErrorPrint(vErrorCode);
            }

            SBXPCDLL.EnableDevice(this.MachineNo, 1);
            //--
            return Result;
        }
        #endregion

        #region Public Methods/Function
        public APIResultViewModel GetEmployeeName(int BMDCode)
        {
            Boolean vRet;
            int vErrorCode = 0;
            APIResultViewModel Result = new APIResultViewModel();

            vRet = SBXPCDLL.EnableDevice(this.MachineNo, 0); // 0 : false
            if (!vRet)
            {
                Result.Result = eExecutionResult.Error;
                Result.Error = util.gstrNoDevice;
                return Result;
            }

            string vName = "";
            vRet = SBXPCDLL.GetUserName1(this.MachineNo, BMDCode, out vName);
            if (vRet)
            {
                Result.Result = eExecutionResult.Succeed;
                Result.ResultValue = vName;
            }
            else
            {
                SBXPCDLL.GetLastError(this.MachineNo, out vErrorCode);
                Result.Error = util.ErrorPrint(vErrorCode);
                Result.Result = eExecutionResult.Error;
            }

            SBXPCDLL.EnableDevice(this.MachineNo, 1); // 1 : true

            return Result;
        }

        public APIResultViewModel SetEmployeeName(int BMDCode, string EmployeeName)
        {
            Boolean vRet;
            int vErrorCode = 0;
            APIResultViewModel Result = new APIResultViewModel();

            vRet = SBXPCDLL.EnableDevice(this.MachineNo, 0); // 0 : false
            if (!vRet)
            {
                Result.Result = eExecutionResult.Error;
                Result.Error = util.gstrNoDevice;
                return Result;
            }

            vRet = SBXPCDLL.SetUserName1(this.MachineNo, BMDCode, EmployeeName);
            if (vRet)
            {
                Result.Result = eExecutionResult.Succeed;
            }
            else
            {
                SBXPCDLL.GetLastError(this.MachineNo, out vErrorCode);
                Result.Error = util.ErrorPrint(vErrorCode);
                Result.Result = eExecutionResult.Error;
            }

            SBXPCDLL.EnableDevice(this.MachineNo, 1); // 1 : true

            return Result;
        }

        public APIResultViewModel GetEmployeeAttendanceAllLog()
        {
            APIResultViewModel Result = new APIResultViewModel();
            Boolean vRet;
            int vErrorCode = 0;
            vRet = SBXPCDLL.EnableDevice(MachineNo, 0); // 0 : Disable device

            if (!vRet)
            {
                Result.Result = eExecutionResult.Error;
                Result.Error = "Can not open device. No device found.";
                return Result;
            }

            vRet = SBXPCDLL.ReadAllGLogData(MachineNo);
            if (!vRet)
            {
                SBXPCDLL.GetLastError(MachineNo, out vErrorCode);
                Result.Result = eExecutionResult.Error;
                Result.Error = "Can not read attendance. " + util.ErrorPrint(vErrorCode);

                vRet = SBXPCDLL.EnableDevice(MachineNo, 1); // 0 : Enable device
                return Result;
            }

            if (vRet)
            {
                List<GLogInfo> glogs_ = new List<GLogInfo>();
                while (true)
                {
                    GLogInfo gi = new GLogInfo();
                    vRet = SBXPCDLL.GetAllGLogData(MachineNo,
                                                out gi.tmno,
                                                out gi.seno,
                                                out gi.smno,
                                                out gi.vmode,
                                                out gi.yr,
                                                out gi.mon,
                                                out gi.day,
                                                out gi.hr,
                                                out gi.min,
                                                out gi.sec);
                    if (!vRet) break;
                    glogs_.Add(gi);
                }
                Result.Result = eExecutionResult.Succeed;
                Result.ResultValue = glogs_;
            }
            vRet = SBXPCDLL.EnableDevice(MachineNo, 1); // 0 : Enable device
            return Result;
        }

        public enum eEnroll_FingerNo
        {
            Finger0 = 0,
            Finger1 = 1,
            Finger2 = 2,
            Finger3 = 3,
            Finger4 = 4,
            Finger5 = 5,
            Finger6 = 6,
            Finger7 = 7,
            Finger8 = 8,
            Finger9 = 9,
            Password = 10
        }

        public enum eEnroll_UserLevl
        {
            Employee = 0,
            Admin = 1,
            EnrollmentAdmin = 2,
            SetupManager = 3
        }

        public APIResultViewModel EnrollNewEmployee(int BMDCode, string EmployeeName)
        {
            APIResultViewModel Result = new APIResultViewModel();
            Boolean vRet;
            int vErrorCode = 0;

            eEnroll_FingerNo FingerNo = eEnroll_FingerNo.Password;
            // Setting password
            glngEnrollPData = 1; // setting password statically value "1"

            eEnroll_UserLevl UserLevel = eEnroll_UserLevl.Employee;

            GCHandle gh;
            IntPtr AddrOfTemplngEnrollData;

            vRet = SBXPCDLL.EnableDevice(MachineNo, 0); // 0 : false

            if (!vRet)
            {
            }

            gh = GCHandle.Alloc(gTemplngEnrollData, GCHandleType.Pinned);
            AddrOfTemplngEnrollData = gh.AddrOfPinnedObject();

            vRet = SBXPCDLL.SetEnrollData1(MachineNo, BMDCode, (int)FingerNo, (int)UserLevel, 
                AddrOfTemplngEnrollData, glngEnrollPData);

            gh.Free();

            if (vRet)
            {
                Result.Result = eExecutionResult.Succeed;
            }
            else
            {
                Result.Result = eExecutionResult.Error;
                if(SBXPCDLL.GetLastError(MachineNo, out vErrorCode))
                {
                    Result.Error = util.ErrorPrint(vErrorCode);
                }
            }

            if(Result.Result == eExecutionResult.Succeed)
            {
                Result = SetEmployeeName(BMDCode, EmployeeName);
            }

            SBXPCDLL.EnableDevice(MachineNo, 1); // 1 : true

            //--
            return Result;
        }

        #endregion
    }

    public class GLogInfo
    {
        public int tmno;
        public int smno, seno;
        public int vmode;
        public int yr, mon, day, hr, min, sec;

        public string photo { get { return (tmno == -1) ? "No Photo" : Convert.ToString(tmno); } }
        public int enroll { get { return seno; } }
        public int machine { get { return smno; } }

        public string verify_mode
        {
            get
            {
                string attend_status = "";
                switch ((vmode >> 8) & 0xFF)
                {
                    case 0: attend_status = "_DutyOn"; break;
                    case 1: attend_status = "_DutyOff"; break;
                    case 2: attend_status = "_OverOn"; break;
                    case 3: attend_status = "_OverOff"; break;
                    case 4: attend_status = "_GoIn"; break;
                    case 5: attend_status = "_GoOut"; break;
                }

                string antipass = "";
                switch ((vmode >> 16) & 0xFFFF)
                {
                    case 1: antipass = "(AP_In)"; break;
                    case 3: antipass = "(AP_Out)"; break;
                }


                int vm = vmode & 0xFF;
                string str = "--";
                switch (vm)
                {
                    case 1: str = "Fp"; break;
                    case 2: str = "Password"; break;
                    case 3: str = "Card"; break;
                    case 4: str = "FP+Card"; break;
                    case 5: str = "FP+Pwd"; break;
                    case 6: str = "Card+Pwd"; break;
                    case 7: str = "FP+Card+Pwd"; break;
                    case 10: str = "Hand Lock"; break;
                    case 11: str = "Prog Lock"; break;
                    case 12: str = "Prog Open"; break;
                    case 13: str = "Prog Close"; break;
                    case 14: str = "Auto Recover"; break;
                    case 20: str = "Lock Over"; break;
                    case 21: str = "Illegal Open"; break;
                    case 22: str = "Duress alarm"; break;
                    case 23: str = "Tamper detect"; break;
                    case 30: str = "FACE"; break;
                    case 31: str = "FACE+CARD"; break;
                    case 32: str = "FACE+PWD"; break;
                    case 33: str = "FACE+CARD+PWD"; break;
                    case 34: str = "FACE+FP"; break;
                    case 51: str = "Fp"; break;
                    case 52: str = "Password"; break;
                    case 53: str = "Card"; break;
                    case 101: str = "Fp"; break;
                    case 102: str = "Password"; break;
                    case 103: str = "Card"; break;
                    case 151: str = "Fp"; break;
                    case 152: str = "Password"; break;
                    case 153: str = "Card"; break;
                }

                if ((1 <= vm && vm <= 7) ||
                    (30 <= vm && vm <= 34) ||
                    (51 <= vm && vm <= 53) ||
                    (101 <= vm && vm <= 103) ||
                    (151 <= vm && vm <= 153))
                {
                    str = str + attend_status;
                }

                str += antipass;

                return str;
            }
        }

        public string logtime { get { return string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}", yr, mon, day, hr, min, sec); } }
    }
}
