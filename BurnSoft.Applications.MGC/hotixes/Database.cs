using System;
using ADODB;

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.hotixes
{
    /// <summary>
    /// This Database class uses ADODB for database connection, unlike the Database class in the root
    ///  which uses odbc for it's connection methods.  This code was converted from the hotfix application.
    /// </summary>
    public class Database
    {

        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.hotixes.Database";
        /// <summary>
        /// Errors the message for regular Exceptions
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, Exception e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for access violations
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, AccessViolationException e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for invalid cast exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, InvalidCastException e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message argument exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentException e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for argument null exception.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentNullException e) => $"{_classLocation}.{functionName} - {e.Message}";
        #endregion
        //End Snippet

        internal static bool ExecuteSql(string databasePath,string sql, out string errOut)
        {
            errOut = "";
            bool bAns = false;
            try
            {
                Connection conn = new Connection();
                conn.Provider = "Microsoft.Jet.OLEDB.4.0";
                conn.ConnectionString = $"Data Source={databasePath}";
                conn.Mode = ConnectModeEnum.adModeShareExclusive;
                conn.Open();
                conn.Execute(sql, out var rs);
                conn.Close();
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("ExecuteSql", e);
            }
            return bAns;
        }

        public static bool AddPassword(string databasePath, out string errOut)
        {
            errOut = "";
            bool bAns = false;
            try
            {
                string sql = $"ALTER DATABASE PASSWORD {MGC.Database.DbPassword} NULL";
                if (!ExecuteSql(databasePath, sql, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("AddPassword", e);
            }
            return bAns;
        }
    }
}
