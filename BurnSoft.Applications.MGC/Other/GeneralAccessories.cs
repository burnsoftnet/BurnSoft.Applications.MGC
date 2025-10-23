using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Add(string databasePath, string manufacturer, string model, string serialNumber, string condition, 
            string notes, string use, double purValue, double appValue, bool civ, bool ic, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iCiv = civ ? 1 : 0;
                int iIc = ic ? 1 : 0;

                string sql = $"INSERT INTO General_Accessories(Manufacturer,Model,SerialNumber,Condition,Notes,Use,PurValue," +
                    $"AppValue,CIV,IC,sync_lastupdate) VALUES(" +
                             $"'{manufacturer}','{model}','{serialNumber}','{condition}','{notes}','{use}',{purValue}," +
                             $"{appValue}, {iCiv},{iIc},Now())";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
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
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }

            return bAns;
        }

        /// <summary>
        /// Send a datable to get that converted into an GeneralAcceeories List type
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
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

        /// <summary>
        /// Return a List of the general accessories based on it's id
        /// </summary>
        /// <param name="databasePath">The Database Path</param>
        /// <param name="id">The id of the Accessory that you want to work with</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        public static List<GeneralAccessoriesList> List(string databasePath, int id, out string errOut)
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
                errOut = ErrorMessage("List", e);
            }

            return lst;
        }

        /// <summary>
        /// Return a List of all the general accessories
        /// </summary>
        /// <param name="databasePath">The Database Path</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        public static List<GeneralAccessoriesList> List(string databasePath, out string errOut)
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
                errOut = ErrorMessage("List", e);
            }

            return lst;
        }


    }
}
