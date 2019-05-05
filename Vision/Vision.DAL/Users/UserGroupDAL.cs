using Vision.Model;
using Vision.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL.Users
{
    public class UserGroupDAL
    {
        public SavingResult SaveNewRecord(tblUserGroup SaveModel, List<MenuOptionPermissionViewModel> Permissions, List<Model.Settings.CompanyMultiSelectLookupModel> Companies, List<LocationUserGroupAccessMultiSelectListModel> Location)
        {
            SavingResult res = new SavingResult();

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (SaveModel.UserGroupName == "")
                {
                    res.ValidationError = "Can not accept blank value. The User Group Name is required.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.UserGroupName, SaveModel.UserGroupID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The User Group Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if(SaveModel.SuperAdminGroup)
                {
                    res.ValidationError = "Can not add/edit super admin group.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.UserGroupID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblUserGroups.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblUserGroups.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    db.tblUserGroupPerimissions.RemoveRange(db.tblUserGroupPerimissions.Where(r => r.UserGroupID == SaveModel.UserGroupID));
                    db.tblUserGroupPermissionOnCompanies.RemoveRange(db.tblUserGroupPermissionOnCompanies.Where(r => r.UserGroupID == SaveModel.UserGroupID));
                    db.tblUserGroupPermissionOnLocations.RemoveRange(db.tblUserGroupPermissionOnLocations.Where(r => r.UserGroupID == SaveModel.UserGroupID));
                }

                db.tblUserGroupPerimissions.AddRange(Permissions.Select(r => new tblUserGroupPerimission()
                {
                    tblUserGroup = SaveModel,
                    MenuOptionID = r.MenuOptionID,
                    CanRead = r.CanView,
                    CanAdd = (r.MenuOptionType == Model.Settings.eMenuOptionType.CRUD && r.CanAdd),
                    CanEdit = (r.MenuOptionType == Model.Settings.eMenuOptionType.CRUD && r.CanEdit),
                    CanDelete = (r.MenuOptionType == Model.Settings.eMenuOptionType.CRUD && r.CanDelete),
                    CanAuthorize = (r.MenuOptionType == Model.Settings.eMenuOptionType.CRUD && r.CanAuthorize),
                    CanUnAuthorize = (r.MenuOptionType == Model.Settings.eMenuOptionType.CRUD && r.CanUnAuthorize),
                    rcdt = SaveModel.rcdt,
                    redt = SaveModel.redt,
                    rcuid = SaveModel.rcuid,
                    reuid = SaveModel.reuid,
                }));

                db.tblUserGroupPermissionOnCompanies.AddRange(Companies.Where(r=> r.Selected).Select(r => new tblUserGroupPermissionOnCompany()
                {
                    tblUserGroup = SaveModel,
                    CompanyID = r.CompanyID,
                }));

                db.tblUserGroupPermissionOnLocations.AddRange(Location.Where(r => r.Selected).Select(r => new tblUserGroupPermissionOnLocation()
                {
                    tblUserGroup = SaveModel,
                    LocationID = r.LocationID,
                }));
                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.UserGroupID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblUserGroup FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var obj = db.tblUserGroups.Find(ID);
                if(obj != null)
                {
                    obj.tblUserGroupPerimissions = obj.tblUserGroupPerimissions;
                }
                return obj;
            }
        }

        public List<Model.Users.MenuOptionPermissionViewModel> GetPermission(long UserGroupID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var perms = (from r in db.tblUserGroupPerimissions
                             where r.UserGroupID == UserGroupID
                             select r).ToList();

                DAL.Settings.MenuOptionsDAL MenuOptionDALObj = new Settings.MenuOptionsDAL();

                var res = from m in MenuOptionDALObj.GetMenus()
                          join joinp in perms on m.MenuOptionID equals joinp.MenuOptionID into gp
                          from p in gp.DefaultIfEmpty()
                          select new Model.Users.MenuOptionPermissionViewModel()
                          {
                              MenuOptionID = m.MenuOptionID,
                              MenuOptionName = m.MenuOptionName,
                              MenuOptionGroupName = m.MenuOptionGroupName,
                              MenuOptionType = m.MenuType,
                              CanView = (p != null ? p.CanRead : true),
                              CanAdd = (p != null ? p.CanAdd : true),
                              CanEdit = (p != null ? p.CanEdit : true),
                              CanDelete = (p != null ? p.CanDelete : true),
                              CanAuthorize = (p != null ? p.CanAuthorize : true),
                              CanUnAuthorize = (p != null ? p.CanUnAuthorize : true),
                          };
                return res.ToList();
            }
        }

        public List<Model.Settings.CompanyMultiSelectLookupModel> GetUserGroupPermissionOnCompanies(int UserGroupID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                var x = from c in db.tblCompanies
                        join jp in db.tblUserGroupPermissionOnCompanies on new { c.CompanyID, UserGroupID } equals new { jp.CompanyID, jp.UserGroupID } into gp
                        from p in gp.DefaultIfEmpty()
                        where c.rstate != RecordState_Deleted
                        select new Model.Settings.CompanyMultiSelectLookupModel()
                        {
                            CompanyID = c.CompanyID,
                            CompanyName = c.CompanyName,
                            Selected = (p != null),
                        };
                return x.ToList();
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();

            using (dbVisionEntities db = new dbVisionEntities())
            {
                var DeleteRecord = db.tblUserGroups.Find(DeleteID);
                if(DeleteRecord != null && (DeleteRecord.SuperAdminGroup))
                {
                    Result.ValidationMessage = "Can not delete super admin group";
                    Result.IsValidForDelete = false;
                    return Result;
                }
                else if(db.tblUserGroups.Any(r=> r.UserGroupID == DeleteID ))
                {
                    Result.ValidationMessage = "Selected group already selected in some users.";
                    Result.IsValidForDelete = false;
                    return Result;
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
                    tblUserGroup RecordToDelete = db.tblUserGroups.FirstOrDefault(r => r.UserGroupID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another User over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }

                    else
                    {
                        //db.tblUserGroupPerimissions.RemoveRange(db.tblUserGroupPerimissions.Where(r => r.UserGroupID == RecordToDelete.UserGroupID));
                        //db.tblUserGroups.Remove(RecordToDelete);

                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblUserGroups.Attach(RecordToDelete);
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
                var rec = db.tblUserGroups.FirstOrDefault(r => r.UserGroupID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblUserGroups.Attach(rec);
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
                var rec = db.tblUserGroups.FirstOrDefault(r => r.UserGroupID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblUserGroups.Attach(rec);
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

        public IEnumerable<UserGroupEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblUserGroups

                        join joinrcu in db.tblUserGroups on r.rcuid equals joinrcu.UserGroupID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUserGroups on r.reuid equals joinreu.UserGroupID into greu
                        from reu in greu.DefaultIfEmpty()

                        where !(r.SuperAdminGroup) && r.rstate != RecordState_Deleted

                        orderby r.UserGroupName
                        select new Model.Users.UserGroupEditListModel()
                        {
                            UserGroupID = r.UserGroupID,
                            UserGroupName = r.UserGroupName,

                            RecordState = (eRecordState)r.rstate,
                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserGroupName : ""),
                            EditedUserName = (reu != null ? reu.UserGroupName : ""),

                        }).ToList();
            }
        }

        public IEnumerable<Model.Users.UserGroupLookupModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblUserGroups
                        where !(r.SuperAdminGroup) && r.rstate != RecordState_Deleted
                        orderby r.UserGroupName
                        select new Model.Users.UserGroupLookupModel()
                        {
                            UserGroupID = r.UserGroupID,
                            UserGroupName = r.UserGroupName
                        }).ToList();
            }
        }

        public List<LocationUserGroupAccessMultiSelectListModel> GetLocationList(int UserGroupID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from l in db.tblLocations
                        join c in db.tblCompanies on l.CompanyID equals c.CompanyID
                        join juga in db.tblUserGroupPermissionOnLocations on new { l.LocationID, UserGroupID } equals new { juga.LocationID, juga.UserGroupID } into guga
                        from uga in guga.DefaultIfEmpty()
                        select new LocationUserGroupAccessMultiSelectListModel()
                        {
                            LocationID =l.LocationID,
                            LocationName = l.LocationName,
                            CompanyID = c.CompanyID,
                            CompanyName = c.CompanyName,
                            Selected = (uga != null ? true : false),
                        }
                        ).ToList();
            }
        }

        public bool IsDuplicateRecord(string UserGroupName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(UserGroupName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string UserGroupName, long ID, dbVisionEntities db)
        {
            if (db.tblUserGroups.FirstOrDefault(i => i.UserGroupName == UserGroupName && i.UserGroupID != ID) != null)
            {
                return true;
            }
            return false;
        }

    }
}
