using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class MaintanceDetails that will help manage the details of teh Maintance_Details table.
    /// </summary>
    public class MaintanceDetails
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Firearms.MaintanceDetails";
        /// <summary>
        /// Errors the message for regular Exceptions
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, Exception e) => $"{ClassLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for access violations
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, AccessViolationException e) => $"{ClassLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for invalid cast exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, InvalidCastException e) => $"{ClassLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message argument exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentException e) => $"{ClassLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for argument null exception.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentNullException e) => $"{ClassLocation}.{functionName} - {e.Message}";
        #endregion

        public static bool Add(string databasePath, string name,long gunId, long maintenancePlanId, string operationDate, string operationDueDate, long roundsFired, string Notes, string ammoUsed, long barrelSystemId, bool doesCount, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iCount = doesCount ? 1 : 0;
                string sql = $"INSERT INTO Maintance_Details(gid,mpid,Name,OpDate,OpDueDate,RndFired,Notes,au,BSID,DC,sync_lastupdate) VALUES(" +
                             $"{gunId},{maintenancePlanId},'{name}','{operationDate}','{operationDueDate}',{roundsFired},'{Notes}','{ammoUsed}'" +
                             $",{barrelSystemId},{iCount},Now())";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }
            return bAns;
        }

        public static bool Exist(string databasePath, string name, long gunId, long maintenancePlanId, string operationDate, string operationDueDate, long roundsFired, string Notes, string ammoUsed, long barrelSystemId, bool doesCount, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iCount = doesCount ? 1 : 0;
                string sql = $"SELECT * from  Maintance_Details where gid={gunId} and mpid={maintenancePlanId} and Name='{name}' and" +
                             $"OpDate='{operationDate}' and OpDueDate='{operationDueDate}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                bAns = dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Exist", e);
            }
            return bAns;
        }

        public static bool Delete(string databasePath, long id, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"delete from  Maintance_Details where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }
            return bAns;
        }

        public static long GetId(string databasePath, string name, long gunId, long maintenancePlanId, string operationDate, string operationDueDate, long roundsFired, string Notes, string ammoUsed, long barrelSystemId, bool doesCount, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                int iCount = doesCount ? 1 : 0;
                string sql = $"SELECT * from  Maintance_Details where gid={gunId} and mpid={maintenancePlanId} and Name='{name}' and" +
                             $"OpDate='{operationDate}' and OpDueDate='{operationDueDate}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (DataRow d in dt.Rows)
                {
                    lAns = Convert.ToInt32(d["id"]);
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetId", e);
            }
            return lAns;
        }
    }
}
