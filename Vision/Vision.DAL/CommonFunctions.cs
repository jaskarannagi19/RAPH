using Vision.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL
{
    public static class CommonFunctions
    {
        public static Exception GetFinalError(Exception ex)
        {
            if (ex.GetType() == typeof(DbEntityValidationException))
            {
                string err = "";
                DbEntityValidationException dbVErr = (DbEntityValidationException)ex;
                foreach (var x in dbVErr.EntityValidationErrors)
                {
                    foreach (var e in x.ValidationErrors)
                    {
                        err = err + "\r\n" + e.PropertyName + " = " + e.ErrorMessage + ".";
                    }
                }
                ex = new Exception(err);
            }
            else
            {
                while (ex.Message == "An error occurred while updating the entries. See the inner exception for details.")
                {
                    ex = ex.InnerException;
                }
                while(ex.Message.Contains("See the inner exception for details"))
                {
                    ex = ex.InnerException;
                }
            }
            return ex;
        }

        public static void GetFinalError(SavingResult res, Exception ex)
        {
            res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
            res.Exception = ex;
            while (res.Exception != null && res.Exception.Message == "An error occurred while updating the entries. See the inner exception for details.")
            {
                res.Exception = res.Exception.InnerException;
            }

            if (ex.GetType() == typeof(System.Data.Entity.Validation.DbEntityValidationException))
            {
                res.ValidationError = "dbEntity Validation Errors : \r\n\r\n";

                System.Data.Entity.Validation.DbEntityValidationException ValidationException = (System.Data.Entity.Validation.DbEntityValidationException)ex;

                foreach (System.Data.Entity.Validation.DbEntityValidationResult ValidRes in ValidationException.EntityValidationErrors)
                {
                    foreach (System.Data.Entity.Validation.DbValidationError ValidError in ValidRes.ValidationErrors)
                    {
                        res.ValidationError += ValidError.PropertyName + " = " + ValidError.ErrorMessage + "\r\n";
                    }
                    res.ValidationError += "\r\n";
                }

                res.Exception = new Exception(res.ValidationError);
            }
        }
    }
}
