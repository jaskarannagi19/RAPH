using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Employee;
using Vision.Model.Reports.Employee;

namespace Vision.DAL.Reports.Employee
{
    public class EmployementStatusReportDAL
    {
        public List<EmployementStatusReportModel> GetReportData(DateTime? DateFrom, DateTime? DateTo, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID, int? EmployementStatus)
        {
            List<EmployementStatusReportModel> lstEmployeeStatus = new List<EmployementStatusReportModel>();

            using (dbVisionEntities db = new dbVisionEntities())
            {
                var data = (from sd in db.tblEmployeeServiceDetails 
                            join r in db.tblEmployees on sd.EmployeeID equals r.EmployeeID

                            join jdes in db.tblEmployeeDesignations on sd.EmployeeDesignationID equals jdes.EmployeeDesignationID into gdes
                            from des in gdes.DefaultIfEmpty()

                            join jdep in db.tblEmployeeDepartments on sd.EmployeeDepartmentID equals jdep.EmployeeDepartmentID into gdep
                            from dep in gdep.DefaultIfEmpty()

                            join jloc in db.tblLocations on sd.LocationID equals jloc.LocationID into gloc
                            from loc in gloc.DefaultIfEmpty()

                            join jp in db.tblEmployeeNoPrefixes on r.EmployeeNoPrefixID equals jp.EmployeeNoPrefixID into gp
                            from p in gp.DefaultIfEmpty()

                            where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID 
                            && (DesignationID == null || sd.EmployeeDesignationID == DesignationID.Value)
                            && (LocationID == null || sd.LocationID == LocationID.Value)
                            && (DepartmentID == null || sd.EmployeeDepartmentID == DepartmentID.Value)
                            && (EmployementTypeID == null ||
                                (sd != null &&
                                    (sd.EmploymentType == EmployementTypeID ||
                                        (EmployementTypeID == 3 && (sd.EmploymentType == 1 || sd.EmploymentType == 2)))))
                            && r.rstate != 2

                            orderby r.EmployeeNo

                            select new EmployementStatusReportModel()
                            {
                                EmployeeID = r.EmployeeID,
                                EmployeeNo = r.EmployeeNo,
                                EmployeeNoPrefix = (p != null ? p.EmployeeNoPrefixName : null),
                                FirstName = r.EmployeeFirstName,
                                LastName = r.EmployeeLastName,

                                Designation = des.EmployeeDesignationName,
                                Department = dep.EmployeeDepartmentName,
                                Location = loc.LocationName,

                                JoiningDate = sd.EmploymentEffectiveDate,
                                EmploymentTypeID = (eEmploymentType)sd.EmploymentType,

                                TerminationTypeID = ((eTerminationType)sd.TerminationTypeID == eTerminationType.NA && (eEmploymentType)sd.EmploymentType == eEmploymentType.Contract ? 
                                                        (sd.ContractExpiryDate <= DateTo ? eTerminationType.Expired : eTerminationType.NA) : (eTerminationType)sd.TerminationTypeID),
                                TerminationDate = sd.TerminationDate,
                                TerminationReason = sd.TerminationReason,

                                ContractExpiryDate = sd.ContractExpiryDate,

                                BasicSalary = sd.BasicSalary,
                                HousingAllowance = sd.HousingAllowance,
                            });

                if (eReportEmployementStatus.Active == (eReportEmployementStatus)EmployementStatus)
                {
                    lstEmployeeStatus = (from r in data
                                         where r.JoiningDate <= DateTo
                                         && ((r.EmploymentTypeID != eEmploymentType.Contract && (r.TerminationDate == null || r.TerminationDate > DateTo))
                                         || (r.EmploymentTypeID == eEmploymentType.Contract && (r.ContractExpiryDate == null || r.ContractExpiryDate > DateTo)))
                                         select r).ToList();
                }
                else if (eReportEmployementStatus.Terminated == (eReportEmployementStatus)EmployementStatus)
                {
                    lstEmployeeStatus = (from r in data
                                         where (r.TerminationDate >= DateFrom && r.TerminationDate <= DateTo) || (r.ContractExpiryDate >= DateFrom && r.ContractExpiryDate <= DateTo)
                                         select r).ToList();
                }
                else if (eReportEmployementStatus.NewEmployement == (eReportEmployementStatus)EmployementStatus)
                {
                    lstEmployeeStatus = (from r in data
                                         where (r.JoiningDate >= DateFrom && r.JoiningDate <= DateTo)
                                         select r).ToList();
                }

                ////--
                //foreach(var r in lstEmployeeStatus.Where(r=> r.TerminationDate == null && r.TerminationTypeID == eTerminationType.Expired))
                //{
                //    r.TerminationDate = r.ContractExpiryDate;
                //}

                return lstEmployeeStatus;
            }
        }
    }
}
