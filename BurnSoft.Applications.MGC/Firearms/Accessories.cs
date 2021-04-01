using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Types;

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class Accessories that handles firearm accessories database calls
    /// </summary>
    public class Accessories
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Firearms.Accessories";
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
        /// Adds the specified accessory to the database.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="use">The use.</param>
        /// <param name="purValue">The pur value.</param>
        /// <param name="appValue">The application value.</param>
        /// <param name="civ">if set to <c>true</c> [civ].</param>
        /// <param name="ic">if set to <c>true</c> [ic].</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Add(string databasePath,long gunId, string manufacturer,string model,string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ,bool ic, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iCiv = civ ? 1 : 0;
                int iIc = ic ? 1 : 0;

                string sql = $"INSERT INTO Gun_Collection_Accessories(GID,Manufacturer,Model,SerialNumber,Condition,Notes,Use,PurValue,AppValue,CIV,IC,sync_lastupdate) VALUES({gunId}," +
                             $"'{manufacturer}','{model}','{serialNumber}','{condition}','{notes}','{use}',{purValue},{appValue}, {iCiv},{iIc},Now())";
                bAns = Database.Execute(databasePath, sql, out errOut);
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
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="use">The use.</param>
        /// <param name="purValue">The pur value.</param>
        /// <param name="appValue">The application value.</param>
        /// <param name="civ">if set to <c>true</c> [civ].</param>
        /// <param name="ic">if set to <c>true</c> [ic].</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Update(string databasePath, long id, long gunId, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iCiv = civ ? 1 : 0;
                int iIc = ic ? 1 : 0;

                string sql = $"Update Gun_Collection_Accessories set GID={gunId},Manufacturer='{manufacturer}',Model='{model}'," +
                             $"SerialNumber='{serialNumber}',Condition='{condition}',Notes='{notes}',Use='{use}'," +
                             $"PurValue={purValue},AppValue={appValue},CIV={iCiv},IC={iIc},sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }

            return bAns;
        }

        /// <summary>
        /// checks to see if the accessory already exists in the database for a particular firearm
        /// </summary>
        /// <remarks>This is mostyl used for Unit Testing, the application allos copy of duplicate values for accessories</remarks>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="use">The use.</param>
        /// <param name="purValue">The pur value.</param>
        /// <param name="appValue">The application value.</param>
        /// <param name="civ">if set to <c>true</c> [civ].</param>
        /// <param name="ic">if set to <c>true</c> [ic].</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Exists(string databasePath, long gunId, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iCiv = civ ? 1 : 0;
                int iIc = ic ? 1 : 0;

                string sql = $"select * from  Gun_Collection_Accessories where GID={gunId} and Manufacturer='{manufacturer}' and Model='{model}' and SerialNumber='{serialNumber}' and Condition='{condition}' and Notes='{notes}' and Use='{use}' and PurValue='{purValue}' and AppValue={appValue} and CIV={iCiv} and IC={iIc}";
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
        /// Gets the identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="use">The use.</param>
        /// <param name="purValue">The pur value.</param>
        /// <param name="appValue">The application value.</param>
        /// <param name="civ">if set to <c>true</c> [civ].</param>
        /// <param name="ic">if set to <c>true</c> [ic].</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.Exception"></exception>
        public static long GetId(string databasePath, long gunId, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                int iCiv = civ ? 1 : 0;
                int iIc = ic ? 1 : 0;
                string sql = $"select * from  Gun_Collection_Accessories where GID={gunId} and Manufacturer='{manufacturer}' and Model='{model}' and SerialNumber='{serialNumber}' and Condition='{condition}' and Notes='{notes}' and Use='{use}' and PurValue='{purValue}' and AppValue={appValue} and CIV={iCiv} and IC={iIc}";

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
        /// Deletes the specified accessory from the database
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Delete(string databasePath, long id, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"Delete from  Gun_Collection_Accessories where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }

            return bAns;
        }
        /// <summary>
        /// Get the Fulle name, Manufacture and model name in one from the accessories table
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="id"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static string GetFullName(string databasePath, long id, out string errOut)
        {
            string sAns = @"";
            try
            {
                string sql = $"select * from Gun_Collection_Accessories where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                List<AccessoriesList> lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);

                foreach (AccessoriesList l in lst)
                {
                    sAns = $"{l.Manufacturer.Trim()} {l.Model.Trim()}";
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetFullName", e);
            }

            return sAns;
        }
        /// <summary>
        /// Get a list of all the accessories
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static List<AccessoriesList> List(string databasePath, out string errOut)
        {
            List<AccessoriesList> lst = new List<AccessoriesList>();
            errOut = @"";
            try
            {
                string sql = "select * from Gun_Collection_Accessories";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("List", e);
            }

            return lst;
        }

        /// <summary>
        /// Get all the accessories for a particular firearm
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="gunId"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static List<AccessoriesList> List(string databasePath, long gunId,out string errOut)
        {
            List<AccessoriesList> lst = new List<AccessoriesList>();
            try
            {
                string sql = $"select * from Gun_Collection_Accessories where gid={gunId}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("List", e);
            }

            return lst;
        }
        /// <summary>
        /// Return a List of the accessoriy based on it's id
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="id"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static List<AccessoriesList> List(string databasePath, int id, out string errOut)
        {
            List<AccessoriesList> lst = new List<AccessoriesList>();
            try
            {
                string sql = $"select * from Gun_Collection_Accessories where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("List", e);
            }

            return lst;
        }
        /// <summary>
        /// Send a datable to get that converted into an AcceeoriesList type
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        private static List<AccessoriesList> MyList(DataTable dt, out string errOut)
        {
            List<AccessoriesList> lst = new List<AccessoriesList>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    bool countinValue = false;
                    bool isChoke = false;

                    if (d["CIV"] != DBNull.Value)
                    {
                        countinValue = Convert.ToInt32(d["CIV"]) == 1;
                    }

                    if (d["IC"] != DBNull.Value)
                    {
                        isChoke = Convert.ToInt32(d["IC"]) == 1;
                    }

                    lst.Add(new AccessoriesList()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        GunId = Convert.ToInt32(d["gid"]),
                        Manufacturer = d["Manufacturer"] != DBNull.Value ? d["Manufacturer"].ToString() : "",
                        Model = d["Model"] != DBNull.Value ? d["Model"].ToString() : "",
                        LastSync = d["sync_lastupdate"] != DBNull.Value ? d["sync_lastupdate"].ToString() : "",
                        Notes = d["notes"] != DBNull.Value ? d["notes"].ToString() : "",
                        SerialNumber = d["SerialNumber"] != DBNull.Value ? d["SerialNumber"].ToString() : "",
                        Condition = d["Condition"] != DBNull.Value ? d["Condition"].ToString() : "",
                        Use = d["Use"] != DBNull.Value ? d["Use"].ToString() : "",
                        PurchaseValue = d["PurValue"] != DBNull.Value ? d["PurValue"].ToString() : "",
                        AppriasedValue = d["AppValue"] != DBNull.Value ? d["AppValue"].ToString() : "",
                        CountInValue = countinValue,
                        IsChoke = isChoke
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
