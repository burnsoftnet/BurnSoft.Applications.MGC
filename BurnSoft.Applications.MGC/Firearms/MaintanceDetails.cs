using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Global;
using BurnSoft.Applications.MGC.Types;

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
        /// <summary>
        /// Adds the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="maintenancePlanId">The maintenance plan identifier.</param>
        /// <param name="operationDate">The operation date.</param>
        /// <param name="operationDueDate">The operation due date.</param>
        /// <param name="roundsFired">The rounds fired.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="ammoUsed">The ammo used.</param>
        /// <param name="barrelSystemId">The barrel system identifier.</param>
        /// <param name="doesCount">if set to <c>true</c> [does count].</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Add(string databasePath, string name,long gunId, long maintenancePlanId, string operationDate, string operationDueDate, long roundsFired, string notes, string ammoUsed, long barrelSystemId, bool doesCount, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iCount = doesCount ? 1 : 0;
                string sql = $"INSERT INTO Maintance_Details(gid,mpid,Name,OpDate,OpDueDate,RndFired,Notes,au,BSID,DC,sync_lastupdate) VALUES(" +
                             $"{gunId},{maintenancePlanId},'{name}','{operationDate}','{operationDueDate}',{roundsFired},'{notes}','{ammoUsed}'" +
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
        /// <summary>
        /// Totals the rounds fired bs.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="barrelSystemId">The barrel system identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.Exception"></exception>
        public static long TotalRoundsFiredBs(string databasePath, int barrelSystemId, out string errOut)
        {
            return DatabaseRelated.GetTotal(databasePath,
                $"SELECT SUM(cInt(RndFired)) as T from Maintance_Details where BSID={barrelSystemId} and DC=1",
                "TotalRoundsFiredBS",out errOut);
        }
        /// <summary>
        /// Totals the rounds fired.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.Exception"></exception>
        public static long TotalRoundsFired(string databasePath, int gunId, out string errOut)
        {
            return DatabaseRelated.GetTotal(databasePath,
                $"SELECT SUM(cInt(RndFired)) as T from Maintance_Details where GID={gunId} and DC=1",
                "TotalRoundsFired", out errOut);
        }
        /// <summary>
        /// Averages the rounds fired.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.Exception"></exception>
        public static long AverageRoundsFired(string databasePath,int gunId, out string errOut)
        {
            return DatabaseRelated.GetTotal(databasePath,
                $"SELECT AVG(cInt(RndFired)) as T from Maintance_Details where GID={gunId} and DC=1",
                "AverageRoundsFired", out errOut);
        }

        /// <summary>
        /// Averages the rounds fired bs.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="barrelSystemId">barrel system id</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.Exception"></exception>
        public static long AverageRoundsFiredBs(string databasePath, int barrelSystemId, out string errOut)
        {
            return DatabaseRelated.GetTotal(databasePath,
                $"SELECT AVG(cInt(RndFired)) as T from Maintance_Details where BSID={barrelSystemId} and DC=1",
                "AverageRoundsFiredBS", out errOut);
        }

        /// <summary>
        /// Updates the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="maintenancePlanId">The maintenance plan identifier.</param>
        /// <param name="operationDate">The operation date.</param>
        /// <param name="operationDueDate">The operation due date.</param>
        /// <param name="roundsFired">The rounds fired.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="ammoUsed">The ammo used.</param>
        /// <param name="barrelSystemId">The barrel system identifier.</param>
        /// <param name="doesCount">if set to <c>true</c> [does count].</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Update(string databasePath, long id, string name, long gunId, long maintenancePlanId, string operationDate, string operationDueDate, long roundsFired, string notes, string ammoUsed, long barrelSystemId, bool doesCount, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iCount = doesCount ? 1 : 0;
                string sql = $"UPDATE Maintance_Details set gid={gunId},mpid={maintenancePlanId},Name='{name}',OpDate='{operationDate}'," +
                             $"OpDueDate='{operationDueDate}',RndFired={roundsFired},Notes='{notes}',au='{ammoUsed}',BSID={barrelSystemId},DC={iCount},sync_lastupdate=Now() where id={id}";

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
        /// Exists the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="maintenancePlanId">The maintenance plan identifier.</param>
        /// <param name="operationDate">The operation date.</param>
        /// <param name="operationDueDate">The operation due date.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Exists(string databasePath, string name, long gunId, long maintenancePlanId, string operationDate, string operationDueDate,  out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from  Maintance_Details where gid={gunId} and mpid={maintenancePlanId} and Name='{name}' and " +
                             $"OpDate='{operationDate}' and OpDueDate='{operationDueDate}'";
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
        public static long GetId(string databasePath, string name, long gunId, long maintenancePlanId, string operationDate, string operationDueDate,  out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from  Maintance_Details where gid={gunId} and mpid={maintenancePlanId} and Name='{name}' and " +
                             $"OpDate='{operationDate}' and OpDueDate='{operationDueDate}'";
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
                string sql = $"SELECT * from  Maintance_Details where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                List<MaintanceDetailsList> lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (MaintanceDetailsList l in lst)
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
        /// <returns>List&lt;MaintanceDetailsList&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static List<MaintanceDetailsList> Lists(string databasePath, long gunId, out string errOut)
        {
            List<MaintanceDetailsList> lst = new List<MaintanceDetailsList>();
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
        /// <param name="maintenanceId">The maintenance identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;MaintanceDetailsList&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static List<MaintanceDetailsList> Lists(string databasePath, int maintenanceId, out string errOut)
        {
            List<MaintanceDetailsList> lst = new List<MaintanceDetailsList>();
            errOut = @"";
            try
            {
                string sql = $"SELECT * from  Maintance_Details where id={maintenanceId}";
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
        /// <returns>List&lt;MaintanceDetailsList&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static List<MaintanceDetailsList> Lists(string databasePath, long gunId, long barrelSystem, out string errOut)
        {
            List<MaintanceDetailsList> lst = new List<MaintanceDetailsList>();
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
        /// General List Generator where all you have to do is pass the datatable of informatmion and it will convert it
        /// into the MaintancenDetails List 
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;MaintanceDetailsList&gt;.</returns>
        private static List<MaintanceDetailsList> MyList(DataTable dt, out string errOut)
        {
            List<MaintanceDetailsList> lst = new List<MaintanceDetailsList>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new MaintanceDetailsList()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        AmmoUsed = d["au"] != null ? d["au"].ToString() : "",
                        Name = d["name"] != null ? d["name"].ToString() : "",
                        BarrelSystemId = Convert.ToInt32(d["bsid"]),
                        LastSync = d["sync_lastupdate"].ToString(),
                        Notes = d["notes"] != null ? d["notes"].ToString() : "",
                        DoesCount = Convert.ToInt32(d["dc"]) > 0,
                        GunId = Convert.ToInt32(d["gid"]),
                        OperationDueDate = d["opduedate"] != null ? d["opduedate"].ToString() : "",
                        OperationStartDate = d["opdate"] != null ? d["opdate"].ToString() : "",
                        RoundsFired = Convert.ToInt32(d["rndfired"].ToString()),
                        PlanId = Convert.ToInt32(d["mpid"].ToString())
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
