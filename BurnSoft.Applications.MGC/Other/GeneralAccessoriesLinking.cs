using BurnSoft.Applications.MGC.Firearms;
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

        public static bool AttachToFirearm(string databasePath, long id, long gunId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"INSERT INTO General_Accessories_Link(GID, AID) Values({gunId},{id})";
                if (!Database.Execute(databasePath, sql, out errOut)) throw new Exception(errOut);
                //bAns = Accessories.Add
                ////string sql = $"Update General_Accessories set Manufacturer='{manufacturer}',Model='{model}'," +
                ////             $"SerialNumber='{serialNumber}',Condition='{condition}',Notes='{notes}',Use='{use}'," +
                ////             $"PurValue={purValue},AppValue={appValue},CIV={iCiv},IC={iIc},sync_lastupdate=Now() where id={id}";
                //bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("AttachToFirearm", e);
            }

            return bAns;
        }
    }
}
