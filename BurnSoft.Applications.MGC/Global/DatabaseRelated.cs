﻿using System;
using System.Data;
// ReSharper disable ConditionIsAlwaysTrueOrFalse

// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global

namespace BurnSoft.Applications.MGC.Global
{
    /// <summary>
    /// Class DatabaseRelated.
    /// </summary>
    public class DatabaseRelated
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Global.DatabaseRelated";
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
        /// Gets the identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="sql">The SQL.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="Exception"></exception>
        public static long GetId(string databasePath, string sql, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
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
        /// Objects the exists in database.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="table">The table.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool ObjectExistsInDb(string databasePath, string table, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"select * from {table}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length >0) throw new Exception(errOut);
                bAns = dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("ObjectExistsInDb", e);
            }

            return bAns;
        }
        /// <summary>
        /// Gets the database version.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public static string GetDatabaseVersion(string databasePath, out string errOut)
        {
            string sAns = "0";
            errOut = "";
            try
            {
                string sql = "SELECT top 1 dbver from DB_Version order by dbver desc";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);

                foreach (DataRow d in dt.Rows)
                {
                    sAns = d["dbver"].ToString();
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetDatabaseVersion", e);
            }
            return sAns;
        }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="sql">The SQL.</param>
        /// <param name="column">The column.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="Exception"></exception>
        public static string GetName(string databasePath, string sql, string column, out string errOut)
        {
            string sAns = @"N/A";
            errOut = @"";
            try
            {
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (DataRow d in dt.Rows)
                {
                    if (d[column] != null)
                    {
                        if (d[column].ToString() != null)
                        {
                            sAns = d[column].ToString();
                        }
                    }
                }

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetName", e);
            }
            return sAns;
        }
        /// <summary>
        /// Gets the total from a sql queretm have your sum or total defined as T
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="sql">The SQL.</param>
        /// <param name="fromFunction">From function.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.Exception"></exception>
        public static long GetTotal(string databasePath, string sql, string fromFunction, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (DataRow d in dt.Rows)
                {
                    lAns = d["T"] != DBNull.Value ? Convert.ToInt32(d["T"]) : 0;
                }

            }
            catch (Exception e)
            {
                errOut = $"{fromFunction}::{ErrorMessage("GetTotal", e)}";
            }
            return lAns;
        }
    }
}
