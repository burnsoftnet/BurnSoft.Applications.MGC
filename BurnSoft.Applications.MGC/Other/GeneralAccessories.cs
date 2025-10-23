using System;
using System.Collections.Generic;
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
        public static bool Add(string databasePath, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iCiv = civ ? 1 : 0;
                int iIc = ic ? 1 : 0;

                string sql = $"INSERT INTO General_Accessories(Manufacturer,Model,SerialNumber,Condition,Notes,Use,PurValue,AppValue,CIV,IC,sync_lastupdate) VALUES(" +
                             $"'{manufacturer}','{model}','{serialNumber}','{condition}','{notes}','{use}',{purValue},{appValue}, {iCiv},{iIc},Now())";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }

            return bAns;
        }
    }
}
