using Vision.Model;
using Vision.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL.Users
{
    public class UserDAL
    {
        public SavingResult SaveNewRecord(tblUser SaveModel)
        {
            SavingResult res = new SavingResult();

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (SaveModel.UserName == "")
                {
                    res.ValidationError = "Can not accept blank value. The User Name is required.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.UserName, SaveModel.UserID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The user Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if(SaveModel.SuperAdmin)
                {
                    res.ValidationError = "Can not accept add/edit a super user.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.UserID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblUsers.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblUsers.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.UserID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblUser FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblUsers.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();

            using (dbVisionEntities db = new dbVisionEntities())
            {
                var DeleteRecord = db.tblUsers.Find(DeleteID);
                if(DeleteRecord != null)
                {
                    if(DeleteRecord.SuperAdmin)
                    {
                        Result.IsValidForDelete = false;
                        Result.ValidationMessage = "Can not delete super admin record.";
                        return Result;
                    }
                }
            }

            Result.IsValidForDelete = true;
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = new SavingResult();

            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (DeleteID != 0)
                {
                    tblUser RecordToDelete = db.tblUsers.FirstOrDefault(r => r.UserID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }

                    else
                    {
                        //db.tblUsers.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblUsers.Attach(RecordToDelete);
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
                var rec = db.tblUsers.FirstOrDefault(r => r.UserID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblUsers.Attach(rec);
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
                var rec = db.tblUsers.FirstOrDefault(r => r.UserID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblUsers.Attach(rec);
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

        public IEnumerable<UserEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblUsers

                        join jug in db.tblUserGroups on r.UserGroupID equals jug.UserGroupID into gug
                        from ug in gug.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where !r.SuperAdmin && r.rstate != RecordState_Deleted

                        orderby r.UserName
                        select new Model.Users.UserEditListModel()
                        {
                            UserID = r.UserID,
                            UserName = r.UserName,
                            UserGroupName = (ug != null ? ug.UserGroupName ?? "" : ""),

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

        public bool IsDuplicateRecord(string UserName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(UserName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string UserName, long ID, dbVisionEntities db)
        {
            if (db.tblUsers.FirstOrDefault(i => i.UserName == UserName && i.UserID != ID) != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Model.Users.UserLookupModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblUsers
                        where !(r.SuperAdmin) && r.rstate != RecordState_Deleted
                        orderby r.UserName
                        select new Model.Users.UserLookupModel()
                        {
                            UserID = r.UserID,
                            UserName = r.UserName
                        }).ToList();
            }
        }

        public UserDetailModel GetUserDetailModel(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblUser SaveModel = db.tblUsers.FirstOrDefault(r => r.UserID == ID);
                if(SaveModel == null) return null;
                    
                return new UserDetailModel()
                {
                    UserID = SaveModel.UserID,
                    UserName = SaveModel.UserName
                };
            }
        }

        public UserDetailModel GetUserDetailModel(string UserName, string Password)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                UserName = UserName.ToLower();
                return (from r in db.tblUsers

                        join jug in db.tblUserGroups on r.UserGroupID equals jug.UserGroupID into gug
                        from ug in gug.DefaultIfEmpty()
                        where r.UserName.ToLower() == UserName && r.Password == Password
                        select
                        new UserDetailModel()
                        {
                            UserID = r.UserID,
                            UserName = r.UserName,
                            UserGroupID = r.UserGroupID,
                            UserGroupName = (ug != null? ug.UserGroupName : ""),
                            SuperUser = r.SuperAdmin,
                            EMailID = r.EMailID
                        }).FirstOrDefault();
            }
        }

        public UserDetailModel GetUserDetailModelByEmailID(string UserName, string EmailID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                UserName = UserName.ToLower();
                EmailID = EmailID.ToLower();
                return (from r in db.tblUsers
                        join jug in db.tblUserGroups on r.UserGroupID equals jug.UserGroupID into gug
                        from ug in gug.DefaultIfEmpty()
                        where r.UserName.ToLower() == UserName && r.EMailID.ToLower() == EmailID
                        select
                        new UserDetailModel()
                        {
                            UserID = r.UserID,
                            UserName = r.UserName,
                            UserGroupID = r.UserGroupID,
                            UserGroupName = (ug != null ? ug.UserGroupName : ""),
                            SuperUser = r.SuperAdmin,
                            EMailID = r.EMailID
                        }).FirstOrDefault();
            }
        }

        public tblUser GetFirstUser()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblUsers.Where(r=> r.SuperAdmin).FirstOrDefault();
            }
        }
        public long MatchUser(string UserName, string Password)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                UserName = UserName.ToLower();
                tblUser User = db.tblUsers.FirstOrDefault(r => r.UserName.ToLower() == UserName && r.Password == Password);
                if (User == null) return 0;
                else return User.UserID;
            }
        }

        public SavingResult ChangePassworD(int UserID, string NewPassword)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var user = db.tblUsers.Find(UserID);
                if(user == null)
                {
                    return null;
                }

                user.Password = NewPassword;
                db.tblUsers.Attach(user);
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;

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
    }
}
