using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurnSoft.Applications.MGC.Types;

namespace BurnSoft.Applications.MGC.Firearms
{
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

        public static bool Add(string databasePath, string name, string operationDetails, string intervalsInDays, string intervalInRoundsFired, string notes,  out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"INSERT INTO Maintance_Plans(name, od, iid, iirf,notes,sync_lastupdate) VALUES(" +
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
