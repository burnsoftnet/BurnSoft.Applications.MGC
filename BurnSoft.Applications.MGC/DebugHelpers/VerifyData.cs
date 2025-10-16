using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Applications.MGC.DebugHelpers
{
    /// <summary>
    /// The Verify Data Class will get the data returned to help validate that 
    /// some or all values are not a default, null or zero.
    /// </summary>
    public class VerifyData
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.DebugHelpers.VerifyData";
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
        private static bool IsNotEmptyOrNull(string value)
        {
            if (string.IsNullOrEmpty(value)) 
            { 
                return false; 
            } else { 
                return true; 
            }
        }

        private static bool IsNotEmptyOrNull(int? value)
        {
            if (value == null)
            {
                return false;
            }
            else
            {
                if (value == 0)
                {
                    return false;
                } else
                {
                    return true;
                }
            }
        }

        private static string MsgFormat(string control, bool isNumber = false)
        {
            if (!isNumber)
            {
                return $"{control} is empty or null";
            } else
            {
                return $"{control} is 0 ot null";
            }
        }

        public static bool FirearmDetailsById(string databasePath, long id, out string errOut)
        {
            bool bAns =false;
            errOut = "";
            try
            {
                List<GunCollectionFullList> lst = MyCollection.GetFullList(databasePath, id, out errOut);
                if (errOut.Length > 0)  throw new Exception(errOut);
                foreach (GunCollectionFullList l in lst)
                {
                    if (!IsNotEmptyOrNull(l.FullName)) throw new Exception(MsgFormat("Full Name"));
                    if (!IsNotEmptyOrNull(l.ModelId)) throw new Exception(MsgFormat("Model ID", true));
                    if (!IsNotEmptyOrNull(l.Mid)) throw new Exception(MsgFormat("Manufacturer ID", true));
                    if (!IsNotEmptyOrNull(l.ModelName)) throw new Exception(MsgFormat("Model Name"));
                    if (!IsNotEmptyOrNull(l.SerialNumber)) throw new Exception(MsgFormat("Serial Name"));
                    if (!IsNotEmptyOrNull(l.Type)) throw new Exception(MsgFormat("Type"));
                    if (!IsNotEmptyOrNull(l.Caliber)) throw new Exception(MsgFormat("Caliber"));
                    if (!IsNotEmptyOrNull(l.Finish)) throw new Exception(MsgFormat("Finish"));
                    if (!IsNotEmptyOrNull(l.Condition)) throw new Exception(MsgFormat("Condition"));
                    if (!IsNotEmptyOrNull(l.NationalityId)) throw new Exception(MsgFormat("Nationality ID", true));
                    if (!IsNotEmptyOrNull(l.GripId)) throw new Exception(MsgFormat("Grip ID", true));
                    if (!IsNotEmptyOrNull(l.Sid)) throw new Exception(MsgFormat("Seller ID", true));
                    if (!IsNotEmptyOrNull(l.DbId)) throw new Exception(MsgFormat("Default Barrel ID", true));
                }
                bAns = true;
            }
            catch (Exception e)
            {
                ErrorMessage("FirearmDetails", e);
            }

            return bAns;
        }

        public static bool FirearmDetailsAll(string databasePath, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                List<GunCollectionList> lst = MyCollection.GetList(databasePath, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (GunCollectionList l in lst)
                {
                    if (!IsNotEmptyOrNull(l.FullName)) throw new Exception(MsgFormat("Full Name"));
                    if (!IsNotEmptyOrNull(l.ModelId)) throw new Exception(MsgFormat("Model ID", true));
                    if (!IsNotEmptyOrNull(l.Mid)) throw new Exception(MsgFormat("Manufacturer ID", true));
                    if (!IsNotEmptyOrNull(l.ModelName)) throw new Exception(MsgFormat("Model Name"));
                    if (!IsNotEmptyOrNull(l.SerialNumber)) throw new Exception(MsgFormat("Serial Name"));
                    if (!IsNotEmptyOrNull(l.Type)) throw new Exception(MsgFormat("Type"));
                    if (!IsNotEmptyOrNull(l.Caliber)) throw new Exception(MsgFormat("Caliber"));
                    if (!IsNotEmptyOrNull(l.Finish)) throw new Exception(MsgFormat("Finish"));
                    if (!IsNotEmptyOrNull(l.Condition)) throw new Exception(MsgFormat("Condition"));
                    if (!IsNotEmptyOrNull(l.NationalityId)) throw new Exception(MsgFormat("Nationality ID", true));
                    if (!IsNotEmptyOrNull(l.GripId)) throw new Exception(MsgFormat("Grip ID", true));
                    if (!IsNotEmptyOrNull(l.Sid)) throw new Exception(MsgFormat("Seller ID", true));
                    if (!IsNotEmptyOrNull(l.DbId)) throw new Exception(MsgFormat("Default Barrel ID", true));
                }
                bAns = true;
            }
            catch (Exception e)
            {
                ErrorMessage("FirearmDetails", e);
            }

            return bAns;
        }
    }
}
