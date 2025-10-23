using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Applications.MGC.Other
{
    /// <summary>
    /// General Class to handline the linking between the firearm and the General Accessories.  
    /// We are keeping the Firearm accessories the way it is because there are some things that will
    /// never be put into general, while others can be. 
    /// </summary>
    public class GeneralAccessoriesLinking
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Other.GeneralAccessoriesLinking";
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
        /// Attaches The general accessory to the select firearm accessories and adds it to the link list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool AttachToFirearm(string databasePath, int id, long gunId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"INSERT INTO General_Accessories_Link(GID, AID) Values({gunId},{id})";
                if (!Database.Execute(databasePath, sql, out errOut)) throw new Exception(errOut);
                List<GeneralAccessoriesList> lst = GeneralAccessories.List(databasePath, id, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (GeneralAccessoriesList l in lst)
                {
                    if (!Accessories.Add(databasePath, gunId, l.Manufacturer, l.Model, l.SerialNumber, l.Condition, 
                        l.Notes, l.Use, Convert.ToDouble(l.PurchaseValue), Convert.ToDouble(l.AppriasedValue), 
                        l.CountInValue, l.IsChoke, id, out errOut)) throw new Exception(errOut);
                }
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("AttachToFirearm", e);
            }

            return bAns;
        }

        public static bool UpdateFirearm(string databasePath, int id, long gunId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                List<GeneralAccessoriesList> lst = GeneralAccessories.List(databasePath, id, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (GeneralAccessoriesList l in lst)
                {
                    long gaid = Accessories.GetId(databasePath, gunId, l.Manufacturer, l.Model, l.SerialNumber, l.Condition,
                        l.Notes, l.Use, Convert.ToDouble(l.PurchaseValue), Convert.ToDouble(l.AppriasedValue), l.CountInValue,
                        l.IsChoke, id, out errOut);
                    if (errOut.Length > 0) throw new Exception(errOut);
                    if (!Accessories.Update(databasePath, gaid, gunId, l.Manufacturer, l.Model, l.SerialNumber, l.Condition,
                        l.Notes, l.Use, Convert.ToDouble(l.PurchaseValue), Convert.ToDouble(l.AppriasedValue),
                        l.CountInValue, l.IsChoke, id, out errOut)) throw new Exception(errOut);
                }
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("UpdateFirearm", e);
            }

            return bAns;
        }
    }
}
