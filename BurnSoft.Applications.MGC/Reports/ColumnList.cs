using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Types;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Reports
{
    /// <summary>
    /// Class ColumnList to handle all the database functions relating to the cr_ColumnList table.
    /// </summary>
    public class ColumnList
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Reports.ColumnList";
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

        public static string GetColumnName(string databasePath, long tableId, string displayName, out string errOut)
        {
            string sAns = "";
            errOut = @"";
            try
            {
                string sql = $"SELECT col from CR_ColumnList where tid={tableId} and DN='{displayName}'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (DataRow d in dt.Rows)
                {
                    sAns = d["Col"].ToString();
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetColumnName", e);
            }

            return sAns;
        }

        public static List<ColumnLists> GetList(string databasePath, long tableId, out string errOut)
        {
            List<ColumnLists> lst = new List<ColumnLists>();
            errOut = @"";
            try
            {
                string sql = $"Select * from CR_ColumnList where tid={tableId}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return lst;
        }

        private static List<ColumnLists> MyList(DataTable dt, out string errOut)
        {
            List<ColumnLists> lst = new List<ColumnLists>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new ColumnLists()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        TableId = d["TID"] != DBNull.Value ? Convert.ToInt32(d["TID"]) : 0,
                        Column = d["Col"] != DBNull.Value ? d["Col"].ToString() : "",
                        DisplayName = d["DN"] != DBNull.Value ? d["DN"].ToString() : ""
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
