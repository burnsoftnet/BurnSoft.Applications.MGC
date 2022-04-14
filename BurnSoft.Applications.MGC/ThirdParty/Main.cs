using System;
using BurnSoft.Applications.MGC.Global;
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global

namespace BurnSoft.Applications.MGC.ThirdParty
{
    /// <summary>
    /// Class Third Party Class for some simply functions that another application can use to interact with the Gun Collection Application. This is mostly based off the My Loader Load Functions
    /// </summary>
    public class Main
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.ThirdParty.Main";
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
    }
}
