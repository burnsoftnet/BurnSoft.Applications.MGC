using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Types;

// ReSharper disable RedundantAssignment

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Reports
{
    /// <summary>
    /// Class TableList.  Class to manage the CR_TableList table in the database
    /// </summary>
    public class TableList
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Reports.TableList";
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
        /// Gets the name of the table.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="tableId">The table identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="Exception"></exception>
        public static string GetTableName(string databasePath, long tableId, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                string sql = $"SELECT * from CR_TableList where id={tableId}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (DataRow d in dt.Rows)
                {
                    sAns = d["Tables"].ToString();
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetTableName", e);
            }
            return sAns;
        }

        public static List<TableLists> GetList(string databasePath, long tableId, out string errOut)
        {
            List<TableLists> lst = new List<TableLists>();
            errOut = @"";
            try
            {
                string sql = $"Select * from CR_TableList where id={tableId}";
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

        /// <summary>
        /// Private list to be used for any of the public list just by passing the Datatable, to have one section handle
        /// the datatable to list functions so you don't have to update every list function if you change, add or delete something in the database
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;TableLists&gt;.</returns>
        private static List<TableLists> MyList(DataTable dt, out string errOut)
        {
            List<TableLists> lst = new List<TableLists>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new TableLists()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        Tables = d["Tables"] != DBNull.Value ? d["Tables"].ToString() : "",
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
