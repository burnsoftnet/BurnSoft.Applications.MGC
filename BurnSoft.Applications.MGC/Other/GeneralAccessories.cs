using BurnSoft.Applications.MGC.AutoFill;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Universal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BurnSoft.Applications.MGC.Other
{
    /// <summary>
    /// Main Class to handle the General_Accessories table.
    /// </summary>
    public class GeneralAccessories
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Other.GeneralAccessories";
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
        /// <param name="IsLinked">Mark if the Accessory is Linked</param>
        /// <param name="FAID">Firearm Accessory ID for reverse linking</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Add(string databasePath, string manufacturer, string model, string serialNumber, string condition, 
            string notes, string use, double purValue, double appValue, bool civ, bool ic, out string errOut, bool IsLinked = false, long FAID = 0)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iCiv = civ ? 1 : 0;
                int iIc = ic ? 1 : 0;

                string sql = $"INSERT INTO General_Accessories(Manufacturer,Model,SerialNumber,Condition,Notes,Use,PurValue," +
                    $"AppValue,CIV,IC,sync_lastupdate, IsLinked, FAID) VALUES(" +
                             $"'{manufacturer}','{model}','{serialNumber}','{condition}','{notes}','{use}',{purValue}," +
                             $"{appValue}, {iCiv},{iIc},Now(), {IsLinked}, {FAID})";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }

            return bAns;
        }

        /// <summary>
        /// Uplicates the specified accessory in the General Accessories
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static bool Duplicate(string databasePath, long itemId,out string errOut)
        {
            bool bAns = false;
            try
            {
                BSOtherObjects obj = new BSOtherObjects();
                List<GeneralAccessoriesList> details = Lists(databasePath, (int)itemId, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (GeneralAccessoriesList d in details)
                {
                    bAns = Add(databasePath, manufacturer: obj.FC(d.Manufacturer), model: obj.FC(d.Model), serialNumber: obj.FC(d.SerialNumber), 
                        condition: obj.FC(d.Condition), notes: obj.FC(d.Notes), use: obj.FC(d.Use), purValue: Convert.ToDouble(d.PurchaseValue), 
                        appValue: Convert.ToDouble(d.AppriasedValue), civ: d.CountInValue, ic: d.IsChoke, out errOut);
                    if (errOut?.Length > 0) throw new Exception(errOut);
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Duplicate", e);
            }
            return bAns;
        }

        /// <summary>
        /// Adds the accessory to the selected firearm and remove it from the general Accessories.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Move(string databasePath, long itemId, long gunId, out string errOut)
        {
            bool bAns = false;
            try
            {
                BSOtherObjects obj = new BSOtherObjects();
                List<GeneralAccessoriesList> details = Lists(databasePath, (int)itemId, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (GeneralAccessoriesList l in details)
                {
                    if (!Accessories.Add(databasePath, gunId, l.Manufacturer, l.Model, l.SerialNumber, l.Condition,
                        obj.FC(l.Notes), obj.FC(l.Use), Convert.ToDouble(l.PurchaseValue), Convert.ToDouble(l.AppriasedValue),
                        l.CountInValue, l.IsChoke, 0, out errOut)) throw new Exception(errOut);
                    bAns = true;
                    if (!Delete(databasePath, (int)itemId, out errOut)) throw new Exception(errOut);
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Move", e);
            }
            return bAns;
        }


        /// <summary>
        /// Updates the specified accessory in the database.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
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
        public static bool Update(string databasePath, long id, string manufacturer, string model, string serialNumber, 
            string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iCiv = civ ? 1 : 0;
                int iIc = ic ? 1 : 0;

                string sql = $"Update General_Accessories set Manufacturer='{manufacturer}',Model='{model}'," +
                             $"SerialNumber='{serialNumber}',Condition='{condition}',Notes='{notes}',Use='{use}'," +
                             $"PurValue={purValue},AppValue={appValue},CIV={iCiv},IC={iIc},sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);

                if (GeneralAccessoriesLinking.IsAttached(databasePath, id, out errOut))
                {
                    List<GeneralAccessoriesLinkers> ga = GeneralAccessoriesLinking.Lists(databasePath, id, out errOut);
                    if (errOut.Length > 0) throw new Exception(errOut);
                    foreach(GeneralAccessoriesLinkers o in ga)
                    {
                        if (!GeneralAccessoriesLinking.UpdateFirearm(databasePath, Convert.ToInt32(id), o.Gid, out errOut)) throw new Exception(errOut);
                    }
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }

            return bAns;
        }

        #region "List functions"
        /// <summary>
        /// Send a datable to get that converted into an GeneralAcceeories List type
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns>GeneralAccessoriesList List Format</returns>
        private static List<GeneralAccessoriesList> MyList(DataTable dt, out string errOut)
        {
            List<GeneralAccessoriesList> lst = new List<GeneralAccessoriesList>();
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

                    lst.Add(new GeneralAccessoriesList()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        Manufacturer = d["Manufacturer"] != DBNull.Value ? d["Manufacturer"].ToString() : " ",
                        Model = d["Model"] != DBNull.Value ? d["Model"].ToString() : " ",
                        LastSync = d["sync_lastupdate"] != DBNull.Value ? d["sync_lastupdate"].ToString() : " ",
                        Notes = d["notes"] != DBNull.Value ? d["notes"].ToString() : " ",
                        SerialNumber = d["SerialNumber"] != DBNull.Value ? d["SerialNumber"].ToString() : " ",
                        Condition = d["Condition"] != DBNull.Value ? d["Condition"].ToString() : " ",
                        Use = d["Use"] != DBNull.Value ? d["Use"].ToString() : " ",
                        PurchaseValue = d["PurValue"] != DBNull.Value ? d["PurValue"].ToString() : " ",
                        AppriasedValue = d["AppValue"] != DBNull.Value ? d["AppValue"].ToString() : " ",
                        CountInValue = countinValue,
                        IsChoke = isChoke,
                        FAID = d["FAID"] != DBNull.Value ? Convert.ToInt32(d["FAID"]) : 0,
                        IsLinked = d["IsLinked"] != DBNull.Value ? Convert.ToBoolean(d["IsLinked"]) : false
                    });
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("MyList", e);
            }

            return lst;
        }

        /// <summary>
        /// Return a List of the general accessories based on it's id
        /// </summary>
        /// <param name="databasePath">The Database Path</param>
        /// <param name="id">The id of the Accessory that you want to work with</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        public static List<GeneralAccessoriesList> Lists(string databasePath, int id, out string errOut)
        {
            List<GeneralAccessoriesList> lst = new List<GeneralAccessoriesList>();
            try
            {
                string sql = $"select * from General_Accessories where id={id}";
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
        /// Return a List of all the general accessories
        /// </summary>
        /// <param name="databasePath">The Database Path</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        public static List<GeneralAccessoriesList> Lists(string databasePath, out string errOut)
        {
            List<GeneralAccessoriesList> lst = new List<GeneralAccessoriesList>();
            try
            {
                string sql = $"select * from General_Accessories";
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
        #endregion
        #region "Exist Functions
        /// <summary>
        /// Check to see an in accessory exists based on the Manufacture, Model and serial number.
        /// Might not even be needed since This section is designed to hold misc accessories which 
        /// can contain multiple of the same product.  But not listed in qty since they can be different
        /// in some way and not all equal, or you might have or create a serial number for it.
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        /// <param name="serialNumber"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static bool Exists(string databasePath, string manufacturer, string model, 
            string serialNumber, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                List<GeneralAccessoriesList> lst = Lists(databasePath, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                bAns = lst.Any(a => a.Model.Equals(model) && a.Manufacturer.Equals(manufacturer) && 
                a.SerialNumber.Equals(serialNumber)); ;

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Exists", e);
            }

            return bAns;
        }

        #endregion
        /// <summary>
        /// Gets the identifier of the selected accessorie details 
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="use">The use.</param>
        /// <param name="civ">if set to <c>true</c> [civ].</param>
        /// <param name="ic">if set to <c>true</c> [ic].</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64. The id in the table based on the information passed</returns>
        /// <exception cref="System.Exception"></exception>
        public static long GetId(string databasePath, string manufacturer, string model, string serialNumber, string condition,
            string use, bool civ, bool ic, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                List<GeneralAccessoriesList> lst = Lists(databasePath, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);

                foreach (GeneralAccessoriesList a in lst.Where( w=> w.Model.Equals(model) && w.Manufacturer.Equals(manufacturer) 
                && serialNumber.Equals(serialNumber) && w.Condition.Equals(condition) && w.Use.Equals(use) && 
                w.CountInValue.Equals(civ) && w.IsChoke.Equals(ic)))
                {
                    lAns = a.Id;
                    break;
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetId", e);
            }

            return lAns;
        }

        /// <summary>
        /// Gets the identifier of the selected accessorie details 
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64. The id in the table based on the information passed</returns>
        /// <exception cref="System.Exception"></exception>
        public static long GetId(string databasePath, string manufacturer, string model, string serialNumber, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                List<GeneralAccessoriesList> lst = Lists(databasePath, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);

                foreach (GeneralAccessoriesList ag in lst.Where(a => a.Model.Equals(model) && a.Manufacturer.Equals(manufacturer) && 
                a.SerialNumber.Equals(serialNumber)))
                {
                    lAns = ag.Id;
                    break;
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetId", e);
            }

            return lAns;
        }
        /// <summary>
        /// Delete an Accessory from the General Accessory list and removes all the links.
        /// </summary>
        /// <param name="databasePath">The Database path</param>
        /// <param name="id">The Accessory ID</param>
        /// <param name="errOut">Exception error message</param>
        /// <returns>Truw if delete was ok, false if there was an error</returns>
        public static bool Delete(string databasePath, int id, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string sql = $"Delete from General_Accessories where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception ex)
            {
                errOut = ErrorMessage("Delete", ex);
            }
            return bAns;
        }
        /// <summary>
        /// Deletes the specified Accessory from the links and general tables, as well as the option to delete it
        /// from all the firearms that it is attacted to so a complete clelan up.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="deleteFromFirearms">if set to <c>true</c> [delete from firearms].</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Delete(string databasePath, int id, bool deleteFromFirearms, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                if (deleteFromFirearms)
                {
                    if (!Accessories.Delete(databasePath, id, out errOut)) throw new Exception(errOut);
                }
                if (!Delete(databasePath, id, out errOut)) throw new Exception(errOut);
                bAns= true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }

            return bAns;
        }

    }
}
