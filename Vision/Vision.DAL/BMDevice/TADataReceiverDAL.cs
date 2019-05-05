using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.BMDevice;

namespace Vision.DAL.BMDevice
{
    public class TADataReceiverDAL
    {
        public SavingResult SaveEmployeeAttendanceDetail(ReceivedMessageViewModel Message)
        {
            SavingResult res = new SavingResult();

            DateTime AttendanceDate = Message.LogTime.Date;
            if (AttendanceDate < SqlDateTime.MinValue.Value)
            {
                AttendanceDate = SqlDateTime.MinValue.Value;
            }

            using (dbVisionEntities db = new dbVisionEntities())
            {
                // Searching for employee
                tblEmployee EmployeeSaveModel = db.tblEmployees.FirstOrDefault(r => r.TACode == Message.EmployeeTACode);
                if (EmployeeSaveModel == null)
                {
                    res.MessageAfterSave = $"TA Code {Message.EmployeeTACode} not found.";
                }

                else if (EmployeeSaveModel.tblEmployeeServiceDetail == null)
                {
                    res.MessageAfterSave = $"Employe is not in service, Name : {EmployeeSaveModel.EmployeeFirstName} {EmployeeSaveModel.EmployeeLastName}, TA Code : {Message.EmployeeTACode}.";
                }

                if (EmployeeSaveModel == null || EmployeeSaveModel.tblEmployeeServiceDetail == null)
                {
                    var detailSaveModel = new tblEmployeeAttendanceDetail()
                    {
                        EmployeeTACode = Message.EmployeeTACode,

                        LogTime = (Message.LogTime < SqlDateTime.MinValue.Value ? SqlDateTime.MinValue.Value : Message.LogTime),
                        LogTimeType = 0,
                        TerminalType = Message.TerminalType,
                        TerminalID = Message.TerminaID,
                        DeviceSerialNo = Message.DeviceSerialNo,
                        TransactionID = Message.TransactionID,
                        EventType = Message.EventType,
                        PunchType = Message.PunchType,
                        VerificationMode = Message.VerificationMode,
                        rcdt = DateTime.Now,
                    };
                    db.tblEmployeeAttendanceDetails.Add(detailSaveModel);

                    try
                    {
                        db.SaveChanges();
                        res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    }
                    catch (Exception ex)
                    {
                        CommonFunctions.GetFinalError(res, ex);
                    }
                    return res;
                }

                // Searching for employee shift
                Model.Employee.eEmployeeShiftType EmployeeShiftType = (Model.Employee.eEmployeeShiftType)EmployeeSaveModel.tblEmployeeServiceDetail.EmployeeShiftType;

                tblEmployeeShift EmployeeShift = null;
                if (EmployeeShiftType == Model.Employee.eEmployeeShiftType.Fixed)
                {
                    if (EmployeeSaveModel.tblEmployeeServiceDetail.EmployeeShiftID == null)
                    {
                        //res.ExecutionResult = eExecutionResult.ValidationError;
                        res.MessageAfterSave = $"Shift not allocated, Name : {EmployeeSaveModel.EmployeeFirstName} {EmployeeSaveModel.EmployeeLastName}, TA Code : {Message.EmployeeTACode}.";
                    }
                    else
                    {
                        EmployeeShift = db.tblEmployeeShifts.FirstOrDefault(r => r.EmployeeShiftID == EmployeeSaveModel.tblEmployeeServiceDetail.EmployeeShiftID.Value);
                    }
                }
                else
                {
                    var RotationShift = db.tblEmployeeShiftAllocations.Where(rs => rs.EmployeeID == EmployeeSaveModel.EmployeeID &&
                                (rs.WEDateFrom == null || rs.WEDateFrom <= Message.LogTime)).OrderByDescending(rs => rs.WEDateFrom).FirstOrDefault();
                    if (RotationShift == null)
                    {
                        //res.ExecutionResult = eExecutionResult.ValidationError;
                        res.MessageAfterSave = $"Shift not allocated, Name : {EmployeeSaveModel.EmployeeFirstName} {EmployeeSaveModel.EmployeeLastName}, TA Code : {Message.EmployeeTACode}.";
                    }
                    else
                    {
                        EmployeeShift = db.tblEmployeeShifts.FirstOrDefault(r => r.EmployeeShiftID == RotationShift.EmployeeShiftID);
                    }
                }

                if (EmployeeShift == null)
                {
                    res.MessageAfterSave = $"Employee Shift not found, Name : {EmployeeSaveModel.EmployeeFirstName} {EmployeeSaveModel.EmployeeLastName}, TA Code : {Message.EmployeeTACode}.";

                    var detailSaveModel = new tblEmployeeAttendanceDetail()
                    {
                        EmployeeTACode = Message.EmployeeTACode,

                        LogTime = (Message.LogTime < SqlDateTime.MinValue.Value ? SqlDateTime.MinValue.Value : Message.LogTime),
                        LogTimeType = (byte)eLogTimeType.Unknown,
                        TerminalType = Message.TerminalType,
                        TerminalID = Message.TerminaID,
                        DeviceSerialNo = Message.DeviceSerialNo,
                        TransactionID = Message.TransactionID,
                        EventType = Message.EventType,
                        PunchType = Message.PunchType,
                        VerificationMode = Message.VerificationMode,
                        rcdt = DateTime.Now,
                    };
                    db.tblEmployeeAttendanceDetails.Add(detailSaveModel);

                    try
                    {
                        db.SaveChanges();
                        res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    }
                    catch (Exception ex)
                    {
                        CommonFunctions.GetFinalError(res, ex);
                    }

                    return res;
                }
                //--

                // Searching for last logged time.
                var LastLog = db.tblEmployeeAttendanceDetails.Where(r => r.EmployeeID == EmployeeSaveModel.EmployeeID).OrderByDescending(r => r.LogTime).FirstOrDefault();

                TimeSpan ShiftStartRangeFrom = EmployeeShift.ShiftStartTime.Add(new TimeSpan(-2, 0, 0));
                TimeSpan ShiftStartRangeTo = EmployeeShift.ShiftStartTime.Add(new TimeSpan(3, 0, 0));

                TimeSpan ShiftEndRangeFrom = EmployeeShift.ShiftEndTime.Add(new TimeSpan(-2, 0, 0));
                TimeSpan ShiftEndRangeTo = EmployeeShift.ShiftEndTime.Add(new TimeSpan(10, 0, 0));

                tblEmployeeAttendanceDetail DetailSaveModel = null;
                // if the log time is not in valid shift range, before shift start -2 hours and after shift end +10 hours, then it is invalid time, log it but dont consider it as attendance
                // If Shift Start Range from and Shift End Range to does not eqal, it happens if we have 12 hours shifts.
                if (ShiftStartRangeFrom != ShiftEndRangeTo && !CheckTimeInRange(Message.LogTime.TimeOfDay, ShiftStartRangeFrom, ShiftEndRangeTo))
                {
                    if (LastLog != null)
                    {
                        DetailSaveModel = new tblEmployeeAttendanceDetail()
                        {
                            tblEmployeeAttendance = LastLog.tblEmployeeAttendance,
                            tblEmployee = EmployeeSaveModel,
                            CompanyID = (EmployeeSaveModel != null ? (int?)EmployeeSaveModel.CompanyID : null),

                            LogTime = (Message.LogTime < SqlDateTime.MinValue.Value ? SqlDateTime.MinValue.Value : Message.LogTime),
                            LogTimeType = (byte)eLogTimeType.Unknown,
                            TerminalType = Message.TerminalType,
                            TerminalID = Message.TerminaID,
                            DeviceSerialNo = Message.DeviceSerialNo,
                            TransactionID = Message.TransactionID,
                            EventType = Message.EventType,
                            PunchType = "Invalid Punch Time", //Message.AttendanceStatus,
                            VerificationMode = Message.VerificationMode,
                            rcdt = DateTime.Now
                        };
                        db.tblEmployeeAttendanceDetails.Add(DetailSaveModel);
                        res.MessageAfterSave = $"Invalid Punch Time, Name : {EmployeeSaveModel.EmployeeFirstName} {EmployeeSaveModel.EmployeeLastName}, TA Code : {Message.EmployeeTACode}, Time : {Message.LogTime.ToString("g")}";
                    }
                }
                else
                {
                    bool IsLastLogInTime = (LastLog != null && (eLogTimeType)LastLog.LogTimeType == eLogTimeType.In);

                    //bool IsLastLogInTime = (LastLog != null && (LastLog.AttendanceStatus.ToUpper() == Model.BMDevice.DataReceiverViewModel.PunchType_DutyOn.ToUpper() ||
                    //        LastLog.AttendanceStatus.ToUpper() == Model.BMDevice.DataReceiverViewModel.PunchType_In.ToUpper() ||
                    //        LastLog.AttendanceStatus.ToUpper() == Model.BMDevice.DataReceiverViewModel.PunchType_OverTimeOn.ToUpper()));


                    // Checking to consider this punch as a new attendance or not.
                    bool IsNewAttendance = false;
                    // if last log not found or last log doesn't have a header attendance record then treat it as new attendance record
                    if (LastLog == null || LastLog.tblEmployeeAttendance == null)
                    {
                        IsNewAttendance = true;
                    }
                    else
                    {
                        // ** we are testing time range by subtracting values, becasue we have date values also, otherwise we use CheckTimeInRange Function **

                        // If Last log In time was recorded then, if diff. of Last Shift Start Time and Current Punched time > 18 hours then new shift, A shift can not be greater than 18 hours
                        if (LastLog.tblEmployeeAttendance.InTime != null)
                        {
                            if ((Message.LogTime - LastLog.tblEmployeeAttendance.AttendanceDate.Add(LastLog.tblEmployeeAttendance.InTime.Value)).TotalHours > 18)
                            {
                                IsNewAttendance = true;
                            }
                        }
                        else if (Message.LogTime.Subtract(LastLog.LogTime).TotalHours > 10) // If In time was not found then diff of Last log time and Punched time > 10 hours then new shift
                        {
                            IsNewAttendance = true;
                        }
                    }


                    // Checking to consider this punch as In time or out time.
                    bool IsInTime = false;

                    // if it is new attendance and punched time is not the range of shift end time, then treat it as in time.
                    // If not a new attendance then all punch after first punch will be considered as out time.
                    if (IsNewAttendance && !CheckTimeInRange(Message.LogTime.TimeOfDay, ShiftEndRangeFrom, ShiftEndRangeTo))
                    {
                        IsInTime = true;
                    }

                    // If it is night shift and ends at next day, current punched time is punched after midnight then, it means attendance date must be prev date.

                    // 1. Shift ends next Day == Shift End time is less than Shift Start time
                    // 3. Log Time Less then Shift Start time, this logic confirms the time punched after mid night. see notes:
                    // Possible Shifts for cross day timings
                    /// 15 - 00
                    /// 16 - 01
                    /// 17 - 02
                    /// 18 - 03
                    /// 19 - 04
                    /// 20 - 05, if the time is punched upto 23:59, it will qualify [LogTime is less than Shift Start Time], if time punched after 00:00, only then it will qualify.
                    /// 21 - 06
                    /// 22 - 07
                    /// 23 - 08
                    /// If the punched time < Shift Start Range From, because if the punched time is less than shift start range from time, it means it is invalid punch
                    /// we are already dealing with invalid punch time in above codes, it means invalid punch time can not process to this code, so, 
                    /// if the punch time is still less than shift start range from, it means it is punched after midnight 
                    if (EmployeeShift.ShiftEndTime < ShiftStartRangeFrom && Message.LogTime.TimeOfDay < ShiftStartRangeFrom)
                    {
                        // There must be no attendance for the previous date 
                        AttendanceDate = AttendanceDate.AddDays(-1);
                    }
                    //--

                    tblEmployeeAttendance AttendanceSaveModel = null;
                    if (!IsNewAttendance && LastLog != null && LastLog.tblEmployeeAttendance != null && LastLog.tblEmployeeAttendance.AttendanceDate == AttendanceDate)
                    {
                        AttendanceSaveModel = LastLog.tblEmployeeAttendance;
                    }
                    if (AttendanceSaveModel != null)
                    {
                        DateTime? LastOutTime = (!IsLastLogInTime ? (DateTime?)LastLog.LogTime : null);

                        if (IsInTime)
                        {
                            AttendanceSaveModel.InTime = Message.LogTime.TimeOfDay;
                        }
                        else if (LastOutTime == null || Message.LogTime > LastOutTime)
                        {
                            AttendanceSaveModel.OutTime = Message.LogTime.TimeOfDay;
                        }

                        AttendanceSaveModel.redt = DateTime.Now;
                        db.tblEmployeeAttendances.Attach(AttendanceSaveModel);
                        db.Entry(AttendanceSaveModel).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        AttendanceSaveModel = new tblEmployeeAttendance();
                        AttendanceSaveModel.AttendanceDate = AttendanceDate;

                        if (IsInTime)
                        {
                            AttendanceSaveModel.InTime = Message.LogTime.TimeOfDay;
                        }
                        else
                        {
                            AttendanceSaveModel.OutTime = Message.LogTime.TimeOfDay;
                        }

                        AttendanceSaveModel.EmployeeID = EmployeeSaveModel.EmployeeID;
                        AttendanceSaveModel.CompanyID = EmployeeSaveModel.CompanyID;
                        AttendanceSaveModel.EmployeeShiftID = EmployeeShift.EmployeeShiftID;
                        AttendanceSaveModel.ShiftStartTime = EmployeeShift.ShiftStartTime;
                        AttendanceSaveModel.ShiftEndTime = EmployeeShift.ShiftEndTime;

                        AttendanceSaveModel.rcdt = DateTime.Now;
                        db.tblEmployeeAttendances.Add(AttendanceSaveModel);
                    }

                    DetailSaveModel = new tblEmployeeAttendanceDetail()
                    {
                        tblEmployeeAttendance = AttendanceSaveModel,
                        tblEmployee = EmployeeSaveModel,
                        CompanyID = (EmployeeSaveModel != null ? (int?)EmployeeSaveModel.CompanyID : null),
                        EmployeeTACode = Message.EmployeeTACode,

                        LogTime = (Message.LogTime < SqlDateTime.MinValue.Value ? SqlDateTime.MinValue.Value : Message.LogTime),
                        LogTimeType = (byte)(IsInTime ? eLogTimeType.In : eLogTimeType.Out),
                        TerminalType = Message.TerminalType,
                        TerminalID = Message.TerminaID,
                        DeviceSerialNo = Message.DeviceSerialNo,
                        TransactionID = Message.TransactionID,
                        EventType = Message.EventType,
                        PunchType = Message.PunchType,
                        VerificationMode = Message.VerificationMode,
                        rcdt = DateTime.Now
                    };
                    db.tblEmployeeAttendanceDetails.Add(DetailSaveModel);
                }
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = DetailSaveModel.EmployeeAttendanceDetailID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult SaveDataReceiverErrorLog(string Message, string Error)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                db.tblDataReceiverErrorLogs.Add(new tblDataReceiverErrorLog()
                {
                    Message = Message,
                    Error = Error,
                    rcdt = DateTime.Now
                });

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public bool CheckTimeInRange(TimeSpan CheckValue, TimeSpan RangeStart, TimeSpan RangeEnd)
        {
            // Cross Midnight time
            if (RangeStart > RangeEnd)
            {
                return CheckValue > RangeStart || CheckValue < RangeEnd;
            }
            else // if same day time range
            {
                return CheckValue > RangeStart && CheckValue < RangeEnd;
            }
        }
    }
}
