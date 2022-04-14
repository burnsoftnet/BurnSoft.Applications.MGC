using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
// ReSharper disable UnusedMember.Local
// ReSharper disable RedundantAssignment

namespace BurnSoft.Applications.MGC.ThirdParty
{
    /// <summary>
    /// Class Firearms the handles anything related with the firearms
    /// </summary>
    public class Firearms
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.ThirdParty.Firearms";
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
        
        /// <summary>
        /// Counts the firearms.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static long CountFirearms(out string errOut)
        {
            long lAns = 0;
            errOut = "";
            try
            {
                string databasePath = Main.GetDatabaseLocation(out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                List<GunCollectionList> lst = new List<GunCollectionList>();
                string sql = $"SELECT * from Gun_Collection where ItemSold=0";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyCollection.MyList(dt, out errOut, databasePath);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lAns = lst.Count;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("CountFirearms", e);
            }

            return lAns;
        }
    }
}
