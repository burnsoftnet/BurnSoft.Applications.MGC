using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Types;
// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class MaintancePlans, Main class that handles the Maintance_Plans table data
    /// </summary>
    public class MaintancePlans
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Firearms.MaintancePlans";
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
        /// <summary>
        /// Adds the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="operationDetails">The operation details.</param>
        /// <param name="intervalsInDays">The intervals in days.</param>
        /// <param name="intervalInRoundsFired">The interval in rounds fired.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Add(string databasePath, string name, string operationDetails, string intervalsInDays, string intervalInRoundsFired, string notes,  out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = "INSERT INTO Maintance_Plans(name, od, iid, iirf,notes,sync_lastupdate) VALUES(" +
                             $"'{name}','{operationDetails}','{intervalInRoundsFired}','{intervalInRoundsFired}','{notes}',,Now())";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }
            return bAns;
        }
        /// <summary>
        /// Updates the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="operationDetails">The operation details.</param>
        /// <param name="intervalsInDays">The intervals in days.</param>
        /// <param name="intervalInRoundsFired">The interval in rounds fired.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Update(string databasePath,long id, string name, string operationDetails, string intervalsInDays, string intervalInRoundsFired, string notes, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"Update Maintance_Plans set name='{name}', od='{operationDetails}', iid='{intervalsInDays}', iirf='{intervalInRoundsFired}',notes='{notes}',sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }
            return bAns;
        }
        /// <summary>
        /// Existses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Exists(string databasePath, string name, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Maintance_Plans where Name='{name}'";
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
        /// <summary>
        /// Deletes the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Delete(string databasePath, long id, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"delete from Maintance_Plans where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }
            return bAns;
        }
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="maintenancePlanId">The maintenance plan identifier.</param>
        /// <param name="operationDate">The operation date.</param>
        /// <param name="operationDueDate">The operation due date.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.Exception"></exception>
        public static long GetId(string databasePath, string name, long gunId, long maintenancePlanId, string operationDate, string operationDueDate, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from  Maintance_Plans where Name='{name}'";
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
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static string GetName(string databasePath, long id, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Maintance_Plans where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                List<MaintancePlansList> lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (MaintancePlansList l in lst)
                {
                    sAns = l.Name;
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetName", e);
            }
            return sAns;
        }
        /// <summary>
        /// Listses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;MaintancePlansList&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static List<MaintancePlansList> Lists(string databasePath, long gunId, out string errOut)
        {
            List<MaintancePlansList> lst = new List<MaintancePlansList>();
            errOut = @"";
            try
            {
                string sql = $"SELECT * from  Maintance_Details where gid={gunId}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Lists", e);
            }

            return lst;
        }
        /// <summary>
        /// Listses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="barrelSystem">The barrel system.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;MaintancePlansList&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static List<MaintancePlansList> Lists(string databasePath, long gunId, long barrelSystem, out string errOut)
        {
            List<MaintancePlansList> lst = new List<MaintancePlansList>();
            errOut = @"";
            try
            {
                string sql = $"SELECT * from  Maintance_Details where gid={gunId} and bsid={barrelSystem}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Lists", e);
            }

            return lst;
        }

        /// <summary>
        /// Mies the list.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;MaintancePlansList&gt;.</returns>
        private static List<MaintancePlansList> MyList(DataTable dt, out string errOut)
        {
            List<MaintancePlansList> lst = new List<MaintancePlansList>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new MaintancePlansList()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        OperationDetails = d["od"].ToString(),
                        Name = d["name"].ToString(),
                        LastSync = d["sync_lastupdate"].ToString(),
                        Notes = d["notes"].ToString(),
                        IntervalsInDays = d["iid"].ToString(),
                        IntervalInRoundsFired = d["iirf"].ToString()
                    });
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("MyList", e);
            }

            return lst;
        }
    }
}
