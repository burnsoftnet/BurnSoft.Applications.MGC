using System;
using System.Data;

// ReSharper disable UnusedMember.Local
namespace BurnSoft.Applications.MGC
{
    /// <summary>
    /// Class DatabaseCleanUp. General class to handle clean up data from teh database.
    /// </summary>
    public class DatabaseCleanUp
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.DatabaseCleanUp";
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
        /// Deletes the record.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="table">The table.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeleteRecord(string databasePath, string table, long id, out string errOut)
        {
            return Database.Execute(databasePath, $"DELETE from {table} where id={id}", out errOut);
        }
        /// <summary>
        /// Existses the in collection.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="column">The column.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal static bool ExistsInCollection(string databasePath, long id, string column, out string errOut)
        {
            return Database.DataExists(databasePath, $"select * from gun_collection where {column}={id}", out errOut);
        }
        /// <summary>
        /// Kills the data.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="table">The table.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool KillData(string databasePath, string table, out string errOut)
        {
            return Database.Execute(databasePath, $"DELETE from {table}", out errOut);
        }
        /// <summary>
        /// Selectivelies the clear values.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="table">The table.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        internal static bool SelectivelyClearValues(string databasePath, string table, string collectionId,
            out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT {table}.* from {table} inner join Gun_Collection on Gun_Collection.{collectionId} = {table}.ID";

                if (Database.DataExists(databasePath, sql, out errOut))
                {
                    sql = $"select id from {table}";
                    DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                    if (errOut.Length > 0) throw new Exception(errOut);
                    foreach (DataRow d in dt.Rows)
                    {
                        int id = Convert.ToInt32(d["id"]);
                        if (!ExistsInCollection(databasePath, id, collectionId, out errOut))
                            DeleteRecord(databasePath, table, id, out errOut);
                    }
                }
                else
                {
                    if (!KillData(databasePath, table, out errOut)) throw new Exception(errOut);
                }

                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SelectivelyClearValues", e);
            }
            return bAns;
        }
    
        /// <summary>
        /// Clears the grip types.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static bool ClearGripTypes(string databasePath, out string errOut)
        {
            return SelectivelyClearValues(databasePath, "Gun_GripType", "GripId", out errOut);
        }
        /// <summary>
        /// Clears the buyer list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ClearBuyerList(string databasePath, out string errOut)
        {
            return SelectivelyClearValues(databasePath, "Gun_Collection_SoldTo", "BID", out errOut);
        }
        /// <summary>
        /// Clears the gun shop list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ClearGunShopList(string databasePath, out string errOut)
        {
            return SelectivelyClearValues(databasePath, "Gun_Shop_Details", "SID", out errOut);
        }
        /// <summary>
        /// Clears the nationality.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ClearNationality(string databasePath, out string errOut)
        {
            return SelectivelyClearValues(databasePath, "Gun_Nationality", "NatID", out errOut);
        }
        /// <summary>
        /// Clears the models.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ClearModels(string databasePath, out string errOut)
        {
            return SelectivelyClearValues(databasePath, "Gun_Model", "ModelID", out errOut);
        }
        /// <summary>
        /// Clears the manufacturers.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ClearManufacturers(string databasePath, out string errOut)
        {
            return SelectivelyClearValues(databasePath, "Gun_Manufacturer", "MID", out errOut);
        }
        /// <summary>
        /// Clears the collection.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static bool ClearCollection(string databasePath, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                if (!KillData(databasePath, "Gun_Collection_Accessories", out errOut)) throw new Exception(errOut);
                if (!KillData(databasePath, "Gun_Collection_Pictures", out errOut)) throw new Exception(errOut);
                if (!KillData(databasePath, "Maintance_Details", out errOut)) throw new Exception(errOut);
                if (!KillData(databasePath, "GunSmith_Details", out errOut)) throw new Exception(errOut);
                if (!KillData(databasePath, "Gun_Collection_Ext", out errOut)) throw new Exception(errOut);
                if (!KillData(databasePath, "Gun_Collection", out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("ClearCollection", e);
            }
            return bAns;
        }
    }
}
