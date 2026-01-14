using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Types;
// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class Nationality will help manage the Gun_Nationality table data
    /// </summary>
    public class Nationality
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Firearms.Nationality";
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
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Add(string databasePath, string name, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = "INSERT INTO Gun_Nationality(Country,sync_lastupdate) VALUES(" +
                             $"'{name}',Now())";
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
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Update(string databasePath, long id, string name,  out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"UPDATE Gun_Nationality set Country='{name}',sync_lastupdate=Now() where id={id}";
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
        /// <exception cref="Exception"></exception>
        public static bool Exists(string databasePath, string name, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Nationality where Country='{name}'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                bAns = dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Exists", e);
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
        /// <exception cref="Exception"></exception>
        public static bool Delete(string databasePath, long id, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"delete from Gun_Nationality where id={id}";
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
        /// <param name="errOut">The error out.</param>
        /// <param name="AddIfNotExists">Add if Nationality does not exist</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="Exception"></exception>
        public static long GetId(string databasePath, string name,out string errOut, bool AddIfNotExists = false)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                if (AddIfNotExists)
                {
                    if (!Exists(databasePath, name, out errOut))
                    {
                        if (!Add(databasePath, name, out errOut)) throw new Exception(errOut);
                    }
                    if (errOut?.Length > 0) throw new Exception(errOut);
                }
                string sql = $"SELECT * from  Gun_Nationality where Country='{name}'";
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
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static string GetName(string databasePath, long id, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Nationality where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                List<NationalityList> lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (NationalityList l in lst)
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
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;ModelList&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static List<NationalityList> Lists(string databasePath, long id, out string errOut)
        {
            List<NationalityList> lst = new List<NationalityList>();
            errOut = @"";
            try
            {
                string sql = $"SELECT * from  Gun_Nationality where id={id}";
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
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;ModelList&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static List<NationalityList> Lists(string databasePath, out string errOut)
        {
            List<NationalityList> lst = new List<NationalityList>();
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Nationality";
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
        /// <returns>List&lt;ModelList&gt;.</returns>
        private static List<NationalityList> MyList(DataTable dt, out string errOut)
        {
            List<NationalityList> lst = new List<NationalityList>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new NationalityList()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        Name = d["Country"] != DBNull.Value ? d["Country"].ToString() : "",
                        LastSync = d["sync_lastupdate"] != DBNull.Value ? d["sync_lastupdate"].ToString() : ""
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
