using System;
using System.ComponentModel;
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

        /// <summary>
        /// Databases the connection string.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="usePassword">if set to <c>true</c> [use password].</param>
        /// <returns>System.String.</returns>
        internal static string DatabaseConnectionString(string databasePath, bool usePassword = false)
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
            builder.ConnectionString = $"Data Source={databasePath}";
            builder.Add("Provider", "Microsoft.Jet.Oledb.4.0");
            if (usePassword) builder.Add("Jet OLEDB:Database Password", MGC.Database.DbPassword);
            builder.Add("Mode", 12);
            return builder.ToString();
        }
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
                OleDbConnection conn = new OleDbConnection(DatabaseConnectionString(databasePath, usePassword));
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                var w32ex = e as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = e.InnerException as Win32Exception;
                }

                int code = 0;
                if (w32ex != null)
                {
                    code = w32ex.ErrorCode;
                    // do stuff
                }

                switch (code)
                {
                    case -2147217887:
                        errOut = $"{ErrorMessage("ExecuteSql", e)}.  {Environment.NewLine} Field Already Exists in Table{Environment.NewLine}SQL - {sql}";
                        break;
                    case -2147217900:
                        errOut = $"{ErrorMessage("ExecuteSql", e)}.  {Environment.NewLine} Table Already Exists{Environment.NewLine}SQL - {sql}";
                        break;
                    case -2147467259:
                        errOut = $"{ErrorMessage("ExecuteSql", e)}.  {Environment.NewLine} Password invalid or doesn't exist.{Environment.NewLine}SQL - {sql}";
                        break;
                    default:
                        errOut = $"{ErrorMessage("ExecuteSql", e)}.  {Environment.NewLine} {Environment.NewLine}SQL - {sql}";
                        break;
                }
                //errOut = ErrorMessage("ExecuteSql", e);
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

        public class Management
        {
            public static bool AddColumn(string databasePath, string name, string table, string type,
                out string errOut)
            {
                bool bAns = false;
                errOut = "";
                try
                {
                    string sql = $"ALTER TABLE {table} ADD COLUMN {name} {type};";
                    if (ExecuteSql(databasePath, sql, out errOut)) throw new Exception(errOut);
                    bAns = true;
                }
                catch (Exception e)
                {
                    errOut = ErrorMessage("AddColumn", e);
                }
                return bAns;
            }

            public static bool AddColumn(string databasePath, string name, string table, string type, string defaultValue,
                out string errOut)
            {
                bool bAns = false;
                errOut = "";
                try
                {
                    string sql = $"ALTER TABLE {table} ADD COLUMN {name} {type} [\"{defaultValue}\"];";
                    if (ExecuteSql(databasePath, sql, out errOut)) throw new Exception(errOut);
                    bAns = true;
                }
                catch (Exception e)
                {
                    errOut = ErrorMessage("AddColumn", e);
                }
                return bAns;
            }

            public static bool DropView(string databasePath, string name, out string errOut)
            {
                bool bAns = false;
                errOut = "";
                try
                {
                    string sql = $"DROP VIEW  {name};";
                    if (ExecuteSql(databasePath, sql, out errOut)) throw new Exception(errOut);
                    bAns = true;
                }
                catch (Exception e)
                {
                    errOut = ErrorMessage("DropView", e);
                }
                return bAns;
            }
        }
    }
}
