using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Employee;
using Vision.Model.Reports.Employee;
using Vision.Model.Settings;

namespace Vision.DAL.Reports.Employee
{
    public class EmployeeMinimumWagesReportDAL
    {
        public List<EmployeeMinimumWagesReport> GetReportData(DateTime? DateFrom, DateTime? DateTo, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var Res = (from r in db.tblEmployees

                           join pe in db.tblEmployeeServiceDetails on r.EmployeeLastServiceDetailID equals pe.EmployeeServiceDetailID into PE
                           from ep in PE.DefaultIfEmpty()

                           join np in db.tblEmployeeNoPrefixes on r.EmployeeNoPrefixID equals np.EmployeeNoPrefixID into NP
                           from pn in NP.DefaultIfEmpty()

                           join qe in db.tblEmployeeDesignations on ep.EmployeeDesignationID equals qe.EmployeeDesignationID into QE
                           from eq in QE.DefaultIfEmpty()

                           join lc in db.tblLocations on ep.LocationID equals lc.LocationID into LC
                           from L in LC.DefaultIfEmpty()

                           join mw in db.tblMinimumWageCategories on ep.MinimumWageCategoryID equals mw.MinimumWageCategoryID into MW
                           from M in MW.DefaultIfEmpty()

                           where ((DateFrom == null || ep.EmploymentEffectiveDate <= DateTo)
                           && (DateTo == null || ep.TerminationDate == null || ep.TerminationDate >= DateFrom))
                           && r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                           && (DesignationID == null || ep.EmployeeDesignationID == DesignationID.Value)
                           && (LocationID == null || ep.LocationID == LocationID.Value)
                           && (DepartmentID == null || ep.EmployeeDepartmentID == DepartmentID.Value)
                           && (EmployementTypeID == 3 ? (EmployementTypeID == null || ep.EmploymentType != 0) : (EmployementTypeID == null || ep.EmploymentType == EmployementTypeID.Value))
                           && r.rstate != (int)eRecordState.Deleted
                           select new EmployeeMinimumWagesReport()
                           {
                               EmployeeID = r.EmployeeID,
                               EmployeeNoPrefix = (pn != null ? pn.EmployeeNoPrefixName : null),
                               EmployeeNo = r.EmployeeNo,
                               EmployementTypeID = (eEmploymentType)ep.EmploymentType,
                               EmployeeName = r.EmployeeFirstName + " " + r.EmployeeLastName,
                               Designation = eq.EmployeeDesignationName,
                               Category = M.MinimumWageCategoryName,
                               Location = L.LocationName,
                               LocationTypeID = (eLocationType)L.LocationTypeID,
                               BasicSalary = ep.BasicSalary,

                               MinWagesSal = ((from d in db.tblMinimumWageRates
                                               where d.MinimumWageCategoryID == ep.MinimumWageCategoryID &&
                                              ((DateFrom == null || d.WEDateFrom >= DateFrom) && (d.WEDateTo == null))
                                               orderby d.MinimumWageRateID
                                               select new
                                               {
                                                   minsale = (eLocationType)L.LocationTypeID == eLocationType.Rural ? d.MinimumWageCategoryRuralRate : d.MinimumWageCategoryUrbanRate
                                               }).FirstOrDefault() == null ?
                                                          0
                                                          :
                                                          (from d in db.tblMinimumWageRates
                                                           where d.MinimumWageCategoryID == ep.MinimumWageCategoryID &&
                                                         ((DateFrom == null || d.WEDateFrom >= DateFrom) && (d.WEDateTo == null))
                                                           orderby d.MinimumWageRateID
                                                           select new
                                                           {
                                                               minsale = (eLocationType)L.LocationTypeID == eLocationType.Rural ? d.MinimumWageCategoryRuralRate : d.MinimumWageCategoryUrbanRate
                                                           }).FirstOrDefault().minsale),


                           }).ToList();

                return Res;
            }
        }
    }
}
