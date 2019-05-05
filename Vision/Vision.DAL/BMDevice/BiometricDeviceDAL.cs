using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;

namespace Vision.DAL.BMDevice
{
    public class BiometricDeviceDAL
    {
        public SavingResult SaveNewRecord(tblBiometricDevice SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblBiometricDevice SaveModel;
                if (SaveModel.BMDTitle == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Biometric Device Title.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                //else if (IsDuplicateTitle(SaveModel.BMDTitle, SaveModel.BMDID, db))
                //{
                //    res.ValidationError = "Can not accept duplicate value. The Biometric Device Title is already exists.";
                //    res.ExecutionResult = eExecutionResult.ValidationError;
                //    return res;
                //}

                if(String.IsNullOrWhiteSpace(SaveModel.IPAddress))
                {
                    res.ValidationError = "Can not accept blank value. Please enter IP Address.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;

                }
                else if (IsDuplicateIPAddress(SaveModel.IPAddress, SaveModel.BMDID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The IP Address is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.BMDID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblBiometricDevices.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblBiometricDevices.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.BMDID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblBiometricDevice FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblBiometricDevices.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //bool InState = db.tblCompanies.FirstOrDefault(r => r.BMDID == DeleteID) != null;

                //if (InState)
                //{
                //    Result.ValidationMessage = "Country is selected in company";
                //}
            }
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = new SavingResult();

            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (DeleteID != 0)
                {
                    tblBiometricDevice RecordToDelete = db.tblBiometricDevices.FirstOrDefault(r => r.BMDID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }

                    else
                    {
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;

                        //db.tblBiometricDevice.Remove(RecordToDelete);
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblBiometricDevices.Attach(RecordToDelete);
                        db.Entry(RecordToDelete).State = System.Data.Entity.EntityState.Modified;
                    }

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
            }
            return res;
        }

        public SavingResult Authorize(long ID)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var rec = db.tblBiometricDevices.FirstOrDefault(r => r.BMDID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblBiometricDevices.Attach(rec);
                db.Entry(rec).State = System.Data.Entity.EntityState.Modified;

                //--
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

        public SavingResult UnAuthorize(long ID)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var rec = db.tblBiometricDevices.FirstOrDefault(r => r.BMDID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblBiometricDevices.Attach(rec);
                db.Entry(rec).State = System.Data.Entity.EntityState.Modified;

                //--
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

        public List<Model.BMDevice.BiometricDeviceEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from r in db.tblBiometricDevices

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.BMDTitle

                        select new Model.BMDevice.BiometricDeviceEditListModel()
                        {
                            BMDID = r.BMDID,
                            BMDTitle = r.BMDTitle,
                            IPAddress = r.IPAddress,
                            MachineNo = r.MachineNo,
                            Password = r.Password,
                            PortNo = r.PortNo,

                            RecordState = (eRecordState)r.rstate,
                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }

        public List<Model.BMDevice.BiometricDeviceLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from r in db.tblBiometricDevices
                        where r.rstate != RecordState_Deleted && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby r.BMDTitle
                        select new Model.BMDevice.BiometricDeviceLookupListModel()
                        {
                            BMDID = r.BMDID,
                            BMDTitle = r.BMDTitle,
                            IPAddress = r.IPAddress,
                            MachineNo = r.MachineNo,
                            Password = r.Password,
                            PortNo = r.PortNo,
                        }).ToList();
            }
        }

        public bool IsDuplicateTitle(string BMDTitle, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateTitle(BMDTitle, ID, db);
            }
        }
        public bool IsDuplicateTitle(string BMDTitle, long ID, dbVisionEntities db)
        {
            if (db.tblBiometricDevices.FirstOrDefault(i => i.BMDTitle == BMDTitle && i.BMDID != ID 
                    && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID) != null)
            {
                return true;
            }
            return false;
        }

        public bool IsDuplicateIPAddress(string BMDIPAddress, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateIPAddress(BMDIPAddress, ID, db);
            }
        }
        public bool IsDuplicateIPAddress(string BMDIPAddress, long ID, dbVisionEntities db)
        {
            if (db.tblBiometricDevices.FirstOrDefault(i => i.IPAddress == BMDIPAddress && i.BMDID != ID
                    && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID) != null)
            {
                return true;
            }
            return false;
        }
    }
}
