using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Employee;
using Vision.Model.Reports.Employee;

namespace Vision.DAL.Reports.Employee
{
    public class EmployeeSalaryIncrementReportDAL
    {
        public List<EmployeeSalaryIncrementReportModel> GetReportData(DateTime? DateFrom, DateTime? DateTo, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var ReportData = (from sl in db.tblEmployeeSalaryIncrements
                                  join r in db.tblEmployees on sl.EmployeeID equals r.EmployeeID

                                  join pe in db.tblEmployeeServiceDetails on r.EmployeeLastServiceDetailID equals pe.EmployeeServiceDetailID into PE
                                  from ep in PE.DefaultIfEmpty()

                                  join np in db.tblEmployeeNoPrefixes on r.EmployeeNoPrefixID equals np.EmployeeNoPrefixID into NP
                                  from pn in NP.DefaultIfEmpty()

                                  join qe in db.tblEmployeeDesignations on ep.EmployeeDesignationID equals qe.EmployeeDesignationID into QE
                                  from eq in QE.DefaultIfEmpty()

                                  join lc in db.tblLocations on ep.LocationID equals lc.LocationID into LC
                                  from L in LC.DefaultIfEmpty()

                                  join jdep in db.tblEmployeeDepartments on ep.EmployeeDepartmentID equals jdep.EmployeeDepartmentID into gdep
                                  from dep in gdep.DefaultIfEmpty()

                                  where ((DateFrom == null || sl.EmployeeSalaryIncrementDate <= DateTo)
                                  && (DateTo == null || sl.EmployeeSalaryIncrementDate == null || sl.EmployeeSalaryIncrementDate >= DateFrom))
                                  && r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                  && (DesignationID == null || ep.EmployeeDesignationID == DesignationID.Value)
                                  && (LocationID == null || ep.LocationID == LocationID.Value)
                                  && (DepartmentID == null || ep.EmployeeDepartmentID == DepartmentID.Value)
                                  && (EmployementTypeID == null || (ep != null && (ep.EmploymentType == EmployementTypeID || (EmployementTypeID == 3 && (ep.EmploymentType == 1 || ep.EmploymentType == 2)))))
                                  && r.rstate != 2

                                  select new EmployeeSalaryIncrementReportModel()
                                  {
                                      EmployeeSalaryIncrementID = (sl != null ? sl.EmployeeSalaryIncrementID : 0),
                                      EmployeeSalaryIncrementNo = (sl != null ? sl.EmployeeSalaryIncrementNo : 0),

                                      EmployeeNoPrefix = (pn != null ? pn.EmployeeNoPrefixName : null),
                                      PriviousBasicSalary = sl.LastIncAmount,
                                      EmployeeNo = r.EmployeeNo,
                                      EmployeeName = (r != null ? r.EmployeeFirstName + " " + r.EmployeeLastName : ""),
                                      LastIncDate = sl.LastIncDate,
                                      CurrentBasicSalary = (sl != null ? sl.CurrentBasicSalary : 0),
                                      CurrentIncDate = sl.EmployeeSalaryIncrementDate,
                                      NewBasicSalary = sl.NewBasicSalary,
                                      IncrementAmount = (sl != null ? sl.IncrementAmount : 0),
                                      IncrementPercentage = (sl != null ? sl.IncrementPercentage : 0),
                                      Remarks = sl.Remarks,
                                      Designation = eq.EmployeeDesignationName,
                                      Department = dep.EmployeeDepartmentName,
                                      Location = L.LocationName,
                                      EmployementTypeID = (eEmploymentType)ep.EmploymentType,
                                  }).ToList();

                return ReportData;
            }
        }
    }
}
