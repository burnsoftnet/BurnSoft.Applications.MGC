using System;
using System.Collections.Generic;
using System.Data;

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class GunTypes. This class is to help manage the Gun_Type table.
    /// </summary>
    public class GunTypes
    {

        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.Firearms.GunTypes";
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
        /// Add the Gun Type to the datbaase table
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="value"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static bool Add(string databasePath, string value, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"INSERT INTO Gun_Type(Type,sync_lastupdate) VALUES('{value}',Now())";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }
            return bAns;
        }
        /// <summary>
        /// Check to see if the value already exists in the database
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="value"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static bool Exists(string databasePath, string value, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"select * from Gun_Type where Type='{value}'";
                bAns = Database.DataExists(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Exists", e);
            }
            return bAns;
        }
        /// <summary>
        /// Get the ID tied to the name fo the gun type based ont he name from the database
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="value"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static int GetId(string databasePath, string value, out string errOut)
        {
            int iAns = 0;
            errOut = @"";
            try
            {
                string sql = $"select id from Gun_Type where Type='{value}'";
                iAns = Database.GetIDFromTableBasedOnTSQL(databasePath, sql, "id", out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("getId", e);
            }
            return iAns;
        }
        /// <summary>
        /// Delete the gun type from the database based on the id
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="id"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static bool Delete(string databasePath, int id, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"Delete from Gun_Type where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }
            return bAns;
        }
        /// <summary>
        /// Delete the gun type from the database based on tie name
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="value"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static bool Delete(string databasePath, string value, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"Delete from Gun_Type where Type='{value}'";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }
            return bAns;
        }
        /// <summary>
        /// Update the gun type in the database
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static bool Update(string databasePath,int id, string value, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"Update Gun_Type set Type='{value}',sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }
            return bAns;
        }
        /// <summary>
        /// Check to see if the gun type exists int he database, if it does not then add it.
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="value"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static bool UpdateGunType(string databasePath, string value, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                if (!Exists(databasePath, value, out errOut))
                {
                    bAns = Add(databasePath, value, out errOut);
                }
                if (errOut.Length > 0) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }
            return bAns;
        }

        /// <summary>
        /// Get a list of all the Gun Types in the database
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static List<Types.GunTypes> GetList(string databasePath, out string errOut)
        {
            List<Types.GunTypes> lst = new List<Types.GunTypes>();
            errOut = @"";
            try
            {
                string sql = "select * from Gun_Type";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut, databasePath);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetList", e);
            }
            return lst;
        }
        /// <summary>
        /// Get a lit os the Gun Types by the ID, 
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="id"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static List<Types.GunTypes> GetList(string databasePath, long id, out string errOut)
        {
            List<Types.GunTypes> lst = new List<Types.GunTypes>();
            errOut = @"";
            try
            {
                string sql = $"select * from Gun_Type where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut, databasePath);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetList", e);
            }
            return lst;
        }


        /// <summary>
        /// Private class to sort the informatimon from a datatable into the Gun Collection List ype
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="dbPath"></param>
        /// <returns>List&lt;GunCollectionList&gt;.</returns>
        internal static List<Types.GunTypes> MyList(DataTable dt, out string errOut, string dbPath = "")
        {
            List<Types.GunTypes> lst = new List<Types.GunTypes>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new Types.GunTypes()
                    {
                        Id = Convert.ToInt32(d["id"] != DBNull.Value ? d["id"] : 0), 
                        Name = d["Type"] != DBNull.Value ? d["Type"].ToString().Trim() : "",
                        LastSync = d["sync_lastupdate"] != DBNull.Value ? d["sync_lastupdate"].ToString().Trim() : ""
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
