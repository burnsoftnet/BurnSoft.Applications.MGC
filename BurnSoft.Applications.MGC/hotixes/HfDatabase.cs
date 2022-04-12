using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Universal;

// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertIfStatementToNullCoalescingExpression
// ReSharper disable UseObjectOrCollectionInitializer
// ReSharper disable ConditionIsAlwaysTrueOrFalse

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.hotixes
{
    /// <summary>
    /// This HfDatabase class uses ADODB for database connection, unlike the HfDatabase class in the root
    ///  which uses odbc for it's connection methods.  This code was converted from the hotfix application.
    /// </summary>
    public class HfDatabase
    {

        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.hotixes.HfDatabase";
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
            if (usePassword) builder.Add("Jet OLEDB:HfDatabase Password", Database.DbPassword);
            builder.Add("Mode", 12);
            return builder.ToString();
        }
        /// <summary>
        /// Determines whether the specified database path has data.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="sql">The SQL.</param>
        /// <param name="fromFunction">From function.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="usePassword">if set to <c>true</c> [use password].</param>
        /// <returns><c>true</c> if the specified database path has data; otherwise, <c>false</c>.</returns>
        internal static bool HasData(string databasePath, string sql, string fromFunction, out string errOut, bool usePassword = true)
        {
            errOut = "";
            bool bAns = false;
            try
            {
                OleDbConnection conn = new OleDbConnection(DatabaseConnectionString(databasePath, usePassword));
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);

                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    bAns = dr.HasRows;
                }

                conn.Close();
            }
            catch (Exception e)
            {
                errOut = $"{ErrorMessage($"HasData-->{fromFunction}", e)}.  {Environment.NewLine} {Environment.NewLine}SQL - {sql}";
            }
            return bAns;
        }
        /// <summary>
        /// Values the does exist.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="table">The table.</param>
        /// <param name="column">The column.</param>
        /// <param name="value">The value.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="usePassword">if set to <c>true</c> [use password].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ValueDoesExist(string databasePath, string table, string column, string value, out string errOut, bool usePassword = true)
        {
            string sql = $"SELECT * from {table} where {column}='{value}'";
            return HasData(databasePath, sql, "ValueDoesExist", out errOut, usePassword);
        }
        /// <summary>
        /// Adds the new data by simplifying the see if value exists, and if it doesn't an there are no errors
        /// then it will do the RunSQL command on the value, and column agstin the table
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="table">The table.</param>
        /// <param name="column">The column.</param>
        /// <param name="value">The value.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="usePassword">if set to <c>true</c> [use password].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static bool AddNewData(string databasePath, string table, string column, string value, out string errOut, bool usePassword = true)
        {
            errOut = "";
            bool bAns = false;
            try
            {
                if (!ValueDoesExist(databasePath, table, column, value, out errOut, usePassword))
                {
                    if (errOut.Length > 0) throw new Exception(errOut);
                    string sql = $"INSERT INTO {table} ({column}) VALUES ('{value}');";
                    if (!RunSql(databasePath, sql, out errOut, usePassword)) throw new Exception(errOut);
                }

                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("AddNewData", e);
            }
            return bAns;
        }
        /// <summary>
        /// Values the does exist.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="table">The table.</param>
        /// <param name="column">The column.</param>
        /// <param name="value">The value.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="usePassword">if set to <c>true</c> [use password].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ValueDoesExist(string databasePath, string table, string column, int value, out string errOut, bool usePassword = true)
        {
            string sql = $"SELECT * from {table} where {column}={value}";
            return HasData(databasePath, sql, "ValueDoesExist", out errOut, usePassword);
        }
        /// <summary>
        /// Values the does exist.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="table">The table.</param>
        /// <param name="column">The column.</param>
        /// <param name="value">The value.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="usePassword">if set to <c>true</c> [use password].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ValueDoesExist(string databasePath, string table, string column, double value, out string errOut, bool usePassword = true)
        {
            string sql = $"SELECT * from {table} where {column}={value}";
            return HasData(databasePath, sql, "ValueDoesExist", out errOut, usePassword);
        }
        /// <summary>
        /// Executes the SQL.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="sql">The SQL.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="usePassword"></param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal static bool RunSql(string databasePath,string sql, out string errOut, bool usePassword = false )
        {
            errOut = "";
            bool bAns = false;
            OleDbConnection conn = new OleDbConnection(DatabaseConnectionString(databasePath, usePassword));
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
                bAns = true;
            }
            catch (Exception e)
            {
                var w32Ex = e as Win32Exception;
                if (w32Ex == null)
                {
                    w32Ex = e.InnerException as Win32Exception;
                }

                int code = 0;
                if (w32Ex != null)
                {
                    code = w32Ex.ErrorCode;
                    // do stuff
                }

                switch (code)
                {
                    case -2147217887:
                        errOut = $"{ErrorMessage("RunSql", e)}.  {Environment.NewLine} Field Already Exists in Table{Environment.NewLine}SQL - {sql}";
                        break;
                    case -2147217900:
                        errOut = $"{ErrorMessage("RunSql", e)}.  {Environment.NewLine} Table Already Exists{Environment.NewLine}SQL - {sql}";
                        break;
                    case -2147467259:
                        errOut = $"{ErrorMessage("RunSql", e)}.  {Environment.NewLine} Password invalid or doesn't exist.{Environment.NewLine}SQL - {sql}";
                        break;
                    default:
                        errOut = $"{ErrorMessage("RunSql", e)}.  {Environment.NewLine} {Environment.NewLine}SQL - {sql}";
                        break;
                }
                //errOut = ErrorMessage("RunSql", e);
            }

            conn.Close();
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
                    string sql = $"ALTER DATABASE PASSWORD {Database.DbPassword} NULL";
                    if (!RunSql(databasePath, sql, out errOut)) throw new Exception(errOut);
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
                    string sql = $"ALTER DATABASE PASSWORD NULL {Database.DbPassword}";
                    if (!RunSql(databasePath, sql, out errOut, true)) throw new Exception(errOut);
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
        /// <summary>
        /// Class Management.
        /// </summary>
        public class Management
        {
            /// <summary>
            /// Class Tables.
            /// </summary>
            public class Tables
            {
                /// <summary>
                /// Drops the specified table from the database.
                /// </summary>
                /// <param name="databasePath">The database path.</param>
                /// <param name="table">The table.</param>
                /// <param name="errOut">The error out.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                /// <exception cref="System.Exception"></exception>
                public static bool Drop(string databasePath, string table,out string errOut)
                {
                    bool bAns = false;
                    errOut = "";
                    try
                    {
                        string sql = $"DROP TABLE {table};";
                        if (RunSql(databasePath, sql, out errOut)) throw new Exception(errOut);
                        bAns = true;
                    }
                    catch (Exception e)
                    {
                        errOut = ErrorMessage("Management.Tables.Drop", e);
                    }
                    return bAns;
                }
                /// <summary>
                /// Class Columns.
                /// </summary>
                public class Columns
                {
                    /// <summary>
                    /// Adds the specified column to the table
                    /// </summary>
                    /// <param name="databasePath">The database path.</param>
                    /// <param name="name">The name.</param>
                    /// <param name="table">The table.</param>
                    /// <param name="type">The type.</param>
                    /// <param name="errOut">The error out.</param>
                    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                    /// <exception cref="System.Exception"></exception>
                    public static bool Add(string databasePath, string name, string table, string type,
                        out string errOut)
                    {
                        bool bAns = false;
                        errOut = "";
                        try
                        {
                            string sql = $"ALTER TABLE {table} ADD COLUMN {name} {type};";
                            if (RunSql(databasePath, sql, out errOut)) throw new Exception(errOut);
                            bAns = true;
                        }
                        catch (Exception e)
                        {
                            if (!e.Message.Contains("already exists"))
                            {
                                errOut = ErrorMessage("Management.Tables.Columns.Add", e);
                            }
                            else
                            {
                                bAns = true;
                            }
                        }
                        return bAns;
                    }
                    /// <summary>
                    /// Adds the specified column to the table
                    /// </summary>
                    /// <param name="databasePath">The database path.</param>
                    /// <param name="name">The name.</param>
                    /// <param name="table">The table.</param>
                    /// <param name="type">The type.</param>
                    /// <param name="defaultValue">The default value.</param>
                    /// <param name="errOut">The error out.</param>
                    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                    /// <exception cref="System.Exception"></exception>
                    public static bool Add(string databasePath, string name, string table, string type, string defaultValue,
                        out string errOut)
                    {
                        bool bAns = false;
                        errOut = "";
                        string sql = "";
                        try
                        {
                            //sql = $"ALTER TABLE {table} ADD COLUMN {name} {type} [\"{defaultValue}\"];";
                            if (type.ToLower().Equals("number"))
                            {
                                sql = $"ALTER TABLE {table} ADD COLUMN {name} {type} [{defaultValue}];";
                            }
                            else
                            {
                                sql = $"ALTER TABLE {table} ADD COLUMN {name} {type} \"{defaultValue}\";";
                            }
                            
                            if (!RunSql(databasePath, sql, out errOut, true)) throw new Exception(errOut);
                            bAns = true;
                        }
                        catch (Exception e)
                        {
                            if (!e.Message.Contains("already exists"))
                            {
                                errOut = $"{ErrorMessage("Management.Tables.Columns.Add", e)} {Environment.NewLine}SQL - {sql}";
                            }
                            else
                            {
                                bAns = true;
                            }
                            
                        }
                        return bAns;
                    }
                    /// <summary>
                    /// Alters the specified column to the table
                    /// </summary>
                    /// <param name="databasePath">The database path.</param>
                    /// <param name="name">The name.</param>
                    /// <param name="table">The table.</param>
                    /// <param name="type">The type.</param>
                    /// <param name="errOut">The error out.</param>
                    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                    /// <exception cref="System.Exception"></exception>
                    public static bool Alter(string databasePath, string name, string table, string type,
                        out string errOut)
                    {
                        bool bAns = false;
                        errOut = "";
                        try
                        {
                            string sql = $"ALTER TABLE {table} ALTER COLUMN {name} {type};";
                            if (RunSql(databasePath, sql, out errOut)) throw new Exception(errOut);
                            bAns = true;
                        }
                        catch (Exception e)
                        {
                            errOut = ErrorMessage("Management.Tables.Columns.Alter", e);
                        }
                        return bAns;
                    }

                }
            }
            /// <summary>
            /// Class Views.
            /// </summary>
            public class Views
            {
                /// <summary>
                /// Drops the specified view from the database
                /// </summary>
                /// <param name="databasePath">The database path.</param>
                /// <param name="name">The name.</param>
                /// <param name="errOut">The error out.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                /// <exception cref="System.Exception"></exception>
                public static bool Drop(string databasePath, string name, out string errOut)
                {
                    bool bAns = false;
                    errOut = "";
                    try
                    {
                        string sql = $"DROP VIEW {name};";
                        if (RunSql(databasePath, sql, out errOut)) throw new Exception(errOut);
                        bAns = true;
                    }
                    catch (Exception e)
                    {
                        errOut = ErrorMessage("Management.Views.Drop", e);
                    }
                    return bAns;
                }
                /// <summary>
                /// Creates  the specified view from the database
                /// </summary>
                /// <param name="databasePath">The database path.</param>
                /// <param name="name">The name.</param>
                /// <param name="sql">The SQL.</param>
                /// <param name="errOut">The error out.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                /// <exception cref="System.Exception"></exception>
                public static bool Create(string databasePath, string name, string sql, out string errOut)
                {
                    bool bAns = false;
                    errOut = "";
                    try
                    {
                        string mysql = $"CREATE VIEW {name} AS {sql};";
                        if (RunSql(databasePath, mysql, out errOut)) throw new Exception(errOut);
                        bAns = true;
                    }
                    catch (Exception e)
                    {
                        if (!e.Message.Contains("already exists"))
                        {
                            errOut = ErrorMessage("Management.Views.Create", e);
                        }
                        else
                        {
                            bAns = true;
                        }
                    }
                    return bAns;
                }
                /// <summary>
                /// Alters the specified view from the database
                /// </summary>
                /// <param name="databasePath">The database path.</param>
                /// <param name="name">The name.</param>
                /// <param name="sql">The SQL.</param>
                /// <param name="errOut">The error out.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                /// <exception cref="System.Exception"></exception>
                public static bool Alter(string databasePath, string name, string sql, out string errOut)
                {
                    bool bAns = false;
                    errOut = "";
                    try
                    {
                        string mysql = $"ALTER VIEW {name} AS ( {sql} );";
                        if (RunSql(databasePath, mysql, out errOut)) throw new Exception(errOut);
                        bAns = true;
                    }
                    catch (Exception e)
                    {
                        errOut = ErrorMessage("Management.Views.Alter", e);
                    }
                    return bAns;
                }
            }


        }
        /// <summary>
        /// Class ApplicationSpecific relates to non global functions that relate to the Application Speficly
        /// </summary>
        public class ApplicationSpecific
        {
            /// <summary>
            /// Swaps the values.
            /// </summary>
            /// <param name="databasePath">The database path.</param>
            /// <param name="table">The table.</param>
            /// <param name="column1">The column1.</param>
            /// <param name="column2">The column2.</param>
            /// <param name="errOut">The error out.</param>
            /// <param name="usePassword">if set to <c>true</c> [use password].</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            /// <exception cref="System.Exception"></exception>
            internal static bool SwapValues(string databasePath, string table, string column1, string column2, out string errOut, bool usePassword = true)
            {
                errOut = "";
                bool bAns = false;
                string sql = "";
                try
                {
                    OleDbConnection conn = new OleDbConnection(DatabaseConnectionString(databasePath, usePassword));
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand($"Select id,{column1},{column2} from {table}", conn);

                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var id = dr.GetValue(dr.GetOrdinal("id"));
                            string col1Value = dr.GetValue(dr.GetOrdinal(column1)).ToString();
                            string col2Value = dr.GetValue(dr.GetOrdinal(column2)).ToString();
                            if (col2Value != null)
                            {
                                sql = $"UPDATE {table} set {column2}={col1Value} where id = {id}";
                                if (!RunSql(databasePath, sql, out errOut)) throw new Exception(errOut);
                            }
                        }
                    }

                    conn.Close();
                    bAns = true;
                }
                catch (Exception e)
                {
                    errOut = $"{ErrorMessage("SwapValues", e)}.  {Environment.NewLine} {Environment.NewLine}SQL - {sql}";
                }
                return bAns;
            }
            /// <summary>
            /// Moves the appraisers.
            /// </summary>
            /// <param name="databasePath">The database path.</param>
            /// <param name="errOut">The error out.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            /// <exception cref="System.Exception"></exception>
            /// <exception cref="System.Exception"></exception>
            internal static bool MoveAppraisers(string databasePath,  out string errOut)
            {
                errOut = "";
                bool bAns = false;
                string sql = "";
                try
                {
                    List<GunCollectionList> lst = MyCollection.GetList(databasePath, out errOut);
                    if (errOut.Length > 0) throw new Exception(errOut);
                    BSOtherObjects obj = new BSOtherObjects();
                    foreach (GunCollectionList l in lst)
                    {
                        string name = obj.FC(l.AppriasedBy);
                        if (name?.Length == 0 || name == null) name = "  ";
                        if (!ValueDoesExist(databasePath, "Appriaser_Contact_Details", "aName", name, out errOut))
                        {
                            if (!PeopleAndPlaces.Appraisers.Add(databasePath, name, out errOut))
                                throw new Exception(errOut);
                        }
                    }
                    bAns = true;
                }
                catch (Exception e)
                {
                    errOut = $"{ErrorMessage("MoveAppraisers", e)}.  {Environment.NewLine} {Environment.NewLine}SQL - {sql}";
                }
                return bAns;
            }
            /// <summary>
            /// Moves the gun smiths.
            /// </summary>
            /// <param name="databasePath">The database path.</param>
            /// <param name="errOut">The error out.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            /// <exception cref="System.Exception"></exception>
            /// <exception cref="System.Exception"></exception>
            internal static bool MoveGunSmiths(string databasePath, out string errOut)
            {
                errOut = "";
                bool bAns = false;
                string sql = "";
                try
                {
                    List<GunSmithWorkDone> lst = GunSmithDetails.Lists(databasePath, out errOut, true);
                    if (errOut.Length > 0) throw new Exception(errOut);
                    BSOtherObjects obj = new BSOtherObjects();
                    foreach (GunSmithWorkDone l in lst)
                    {
                        string name = obj.FC(l.GunSmithName);
                        if (!ValueDoesExist(databasePath, "GunSmith_Contact_Details", "gName", name, out errOut))
                        {
                            if (!PeopleAndPlaces.GunSmiths.Add(databasePath, name, out errOut))
                                throw new Exception(errOut);
                        }
                    }
                    bAns = true;
                }
                catch (Exception e)
                {
                    errOut = $"{ErrorMessage("MoveGunSmiths", e)}.  {Environment.NewLine} {Environment.NewLine}SQL - {sql}";
                }
                return bAns;
            }
        }
        /// <summary>
        /// Adds the synchronize to table.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="table">The table.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="updateField">if set to <c>true</c> [update field].</param>
        /// <param name="syncTableName">Name of the synchronize table.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        internal static bool AddSyncToTable(string databasePath, string table, out string errOut, bool updateField = false, string syncTableName = "sync_tables")
        {
            errOut = "";
            bool bAns = false;
            string sql = "";
            try
            {
               
                if (!AddNewData(databasePath, syncTableName, "tblname", table, out errOut)) throw new Exception(errOut);
                if (!Management.Tables.Columns.Add(databasePath, "sync_lastupdate", table, "DATETIME", "Now()", out errOut))
                    throw new Exception(errOut);
                if (updateField)
                    if (!RunSql(databasePath, $"UPDATE {table} set sync_lastupdate=Now()", out errOut,true))
                        throw new Exception(errOut);
                if (!RunSql(databasePath,
                    $"ALTER TABLE {table} ALTER sync_lastupdate DATETIME DEFAULT NOW() NOT NULL;",
                    out errOut, true)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = $"{ErrorMessage("AddSyncToTable", e)}.  {Environment.NewLine} {Environment.NewLine}SQL - {sql}";
            }
            return bAns;
        }
    }
}
