using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Global
{
    /// <summary>
    /// Class Helpers.
    /// </summary>
    public class Helpers
    {

        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.Global.Helpers";
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
        /// Convert an Object to a Byte Array
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// Formats from XML.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string FormatFromXml(string value)
        {
            string sAns = value.Replace("&amp;", "&");
            sAns = sAns.Replace("'", "''");
            return sAns;
        }
        /// <summary>
        /// Sets the type of the catalog to insert into the database.
        /// </summary>
        /// <param name="useNumberOnlyCatalog">if set to <c>true</c> [use number only catalog].</param>
        /// <param name="value">The value.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public static string SetCatalogInsType(bool useNumberOnlyCatalog, string value, out string errOut)
        {
            string sAns = value;
            errOut = @"";
            try
            {
                if (!useNumberOnlyCatalog) sAns = $"'{value}'";
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SetCatalogInsType",e);
            }
            return sAns;
        }


    }
}
