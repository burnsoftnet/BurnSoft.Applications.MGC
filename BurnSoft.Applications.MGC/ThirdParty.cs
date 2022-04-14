using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Global;
using BurnSoft.Applications.MGC.Types;
// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC
{
    /// <summary>
    /// Class Third Party Class for some simply functions that another application can use to interact with the Gun Collection Application. This is mostly based off the My Loader Load Functions
    /// </summary>
    public class ThirdParty
    {

        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.ThirdParty";
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
        /// Gets the database location.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public static string GetDatabaseLocation(out string errOut)
        {
            return MyRegistry.GetDatabaseLocation(out errOut);
        }
        /// <summary>
        /// Gets the MGC executable path.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public static string GetMgcExePath(out string errOut)
        {
            return MyRegistry.GetMgcExePath(out errOut);
        }
        /// <summary>
        /// Mies the gun collection is installed.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool MyGunCollectionIsInstalled(out string errOut)
        {
            return MyRegistry.MyGunCollectionIsInstalled(out errOut);
        }
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
                string databasePath = GetDatabaseLocation(out errOut);
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
