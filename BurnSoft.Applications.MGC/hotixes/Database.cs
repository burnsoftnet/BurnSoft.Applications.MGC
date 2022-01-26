using System;
using System.Data.OleDb;

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
        /// <summary>
        /// Executes the SQL.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="sql">The SQL.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="usePassword"></param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal static bool ExecuteSql(string databasePath,string sql, out string errOut, bool usePassword = false )
        {
            errOut = "";
            bool bAns = false;
            try
            {
                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
                builder.ConnectionString = $"Data Source={databasePath}";
                builder.Add("Provider", "Microsoft.Jet.Oledb.4.0");
                if (usePassword)  builder.Add("Jet OLEDB:Database Password", MGC.Database.DbPassword);
                builder.Add("Mode", 12);

                OleDbConnection conn = new OleDbConnection(builder.ToString());
                
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("ExecuteSql", e);
            }
            return bAns;
        }
        /// <summary>
        /// Class Security.
        /// </summary>
        public class Security
        {
            /// <summary>
            /// Adds the password.
            /// </summary>
            /// <param name="databasePath">The database path.</param>
            /// <param name="errOut">The error out.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            /// <exception cref="System.Exception"></exception>
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
            /// <summary>
            /// Removes the password.
            /// </summary>
            /// <param name="databasePath">The database path.</param>
            /// <param name="errOut">The error out.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            /// <exception cref="System.Exception"></exception>
            public static bool RemovePassword(string databasePath, out string errOut)
            {
                errOut = "";
                bool bAns = false;
                try
                {
                    string sql = $"ALTER DATABASE PASSWORD NULL {MGC.Database.DbPassword}";
                    if (!ExecuteSql(databasePath, sql, out errOut, true)) throw new Exception(errOut);
                    bAns = true;
                }
                catch (Exception e)
                {
                    errOut = ErrorMessage("RemovePassword", e);
                }
                return bAns;
            }
            /// <summary>
            /// Changes the password.
            /// </summary>
            /// <param name="databasePath">The database path.</param>
            /// <param name="errOut">The error out.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            /// <exception cref="System.Exception"></exception>
            /// <exception cref="System.Exception"></exception>
            public static bool ChangePassword(string databasePath, out string errOut)
            {
                bool bAns = false;
                try
                {
                    if (!RemovePassword(databasePath, out errOut)) throw new Exception(errOut);
                    if (!AddPassword(databasePath, out errOut)) throw new Exception(errOut);
                    bAns = true;
                }
                catch (Exception e)
                {
                    errOut = ErrorMessage("ChangePassword", e);
                }
                return bAns;
            }
        }
        
    }
}
