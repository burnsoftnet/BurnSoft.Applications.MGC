﻿using System;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Global;

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.hotixes
{
    /// <summary>
    /// Class HotFix. Hotfix fix main functions
    /// </summary>
    public class HotFix
    {
        /// <summary>
        /// The number of fixes
        /// </summary>
        public const int NumberOfFixes = 9;
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.hotixes.HotFix";
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
        #region "Events"        
        /// <summary>
        /// Occurs when [status].
        /// </summary>
        public event EventHandler<string> Status;
        /// <summary>
        /// Occurs when [errors].
        /// </summary>
        public event EventHandler<string> Errors;
        /// <summary>
        /// Sends the status.
        /// </summary>
        /// <param name="value">The value.</param>
        protected virtual void SendStatus(string value)
        {
            Status?.Invoke(this, value);
        }
        /// <summary>
        /// Sends the errors.
        /// </summary>
        /// <param name="value">The value.</param>
        protected virtual void SendErrors(string value)
        {
            Errors?.Invoke(this, value);
        }
        #endregion
        #region "Private Hotfix Helpers"
        /// <summary>
        /// Updates the reg.
        /// </summary>
        /// <param name="hotfixNumber">The hotfix number.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        private bool UpdateReg(int hotfixNumber, out string errOut)
        {
            errOut = "";
            bool bAns = false;
            try
            {
                if (!MyRegistry.SetHotFix(hotfixNumber, out errOut)) throw new Exception(errOut);
                if (!MyRegistry.SetLastUpdate(hotfixNumber, out errOut)) throw new Exception(errOut);
                SendStatus($"Hotfix {hotfixNumber} is Completed!");
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("UpdateReg", e));
            }
            return bAns;
        }


        #endregion
        #region "Private Hotfixes"        

        /// <summary>
        /// Ones the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        private bool One(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 1;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                if (!Database.Security.AddPassword(databasePath, out errOut)) throw new Exception(errOut);
                if (!Database.Management.Tables.Columns.Add(databasePath, "PetLoads", "Gun_Collection", "TEXT(255)", "'  '", out errOut))
                    throw new Exception(errOut);
                if (!Database.Management.Tables.Columns.Add(databasePath, "dtp", "Gun_Collection", "DATE", "'  '", out errOut))
                    throw new Exception(errOut);
                if (!Database.RunSql(databasePath, "Update Gun_Collection set PetLoads=' '", out errOut, true)) throw new Exception(errOut);

                if (!Database.Management.Tables.Columns.Add(databasePath, "IsCandR", "Gun_Collection", "Number", "0", out errOut))
                    throw new Exception(errOut);

                if (!UpdateReg(hotFixNumber, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("One", e));
            }
            return bAns;
        }
        /// <summary>
        /// Twoes the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="doSwapValues">if set to <c>true</c> [do swap values].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        private bool Two(string databasePath, out string errOut, bool doSwapValues = true)
        {
            errOut = "";
            int hotFixNumber = 2;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                if (!Database.AddNewData(databasePath, "Gun_Cal", "Cal", "10 Gauge", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Cal", "Cal", "12 Gauge", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Cal", "Cal", "16 Gauge", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Cal", "Cal", "20 Gauge", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Cal", "Cal", "28 Gauge", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Cal", "Cal", ".410 Gauge", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Slide Action", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Commemorative", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Fixed Barrel", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Flintlock", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Derringer", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Bolt Action", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Semi-Auto - SA/DA", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Semi-Auto - SA Only", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Semi-Auto - DAO", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Single Shot", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Misc", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Revolver: SA/DA", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Revolver: SA only", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Type", "Type", "Revolver: Misc", out errOut)) throw new Exception(errOut);

                if (doSwapValues)
                {
                    if (!Database.ApplicationSpecific.SwapValues(databasePath, "Gun_Collection", "dt", "dtp", out errOut))
                        throw new Exception(errOut);
                }
                if (!UpdateReg(hotFixNumber, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("Two", e));
            }
            return bAns;
        }
        /// <summary>
        /// Threes the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        private bool Three(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 3;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                if (!Database.Management.Tables.Columns.Add(databasePath, "ISMAIN", "Gun_Collection_Pictures", "Number", "0", out errOut))
                    throw new Exception(errOut);
                if (!Database.RunSql(databasePath, "UPDATE Gun_Collection_Pictures set ISMAIN=0 where ISMAIN <> 1", out errOut)) throw new Exception(errOut);
  
                if (!Pictures.SetMainPictures(databasePath, out errOut)) throw new Exception(errOut);
                if (!UpdateReg(hotFixNumber, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("Three", e));
            }
            return bAns;
        }

        private bool Four(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 4;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                if (!MyRegistry.SetValue("Settings", "BackupOnExit", "False", out errOut)) throw new Exception(errOut);
                if (!MyRegistry.SetValue("Settings", "UseOrgImage", "False", out errOut)) throw new Exception(errOut);
                if (!MyRegistry.SetValue("Settings", "ViewPetLoads", "true", out errOut)) throw new Exception(errOut);
                if (!MyRegistry.SetValue("Settings", "IndvReports", "true", out errOut)) throw new Exception(errOut);
                
                if (!Database.Management.Tables.Columns.Add(databasePath, "Importer", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!Database.Management.Tables.Drop(databasePath, "Gun_Collection_Ammo_Details", out errOut)) throw new Exception(errOut);
                if (!Database.Management.Tables.Drop(databasePath, "Gun_Collection_Ammo_Details_Pictures", out errOut)) throw new Exception(errOut);
                if (!Database.Management.Tables.Drop(databasePath, "Gun_Shop_SalesEmp", out errOut)) throw new Exception(errOut);

                if (!Database.AddNewData(databasePath, "Gun_Cal", "Cal", ".223 Remington", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Cal", "Cal", "5.56 x 45mm", out errOut)) throw new Exception(errOut);
                if (!Database.AddNewData(databasePath, "Gun_Cal", "Cal", ".30-06", out errOut)) throw new Exception(errOut);

                if (!Database.Management.Tables.Columns.Add(databasePath, "UID", "Owner_Info", "Memo", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!Database.Management.Tables.Columns.Add(databasePath, "forgot_word", "Owner_Info", "Memo", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!Database.Management.Tables.Columns.Add(databasePath, "forgot_phrase", "Owner_Info", "Memo", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!Database.Management.Tables.Columns.Add(databasePath, "dcal", "Gun_Collection_Ammo", "number", "0", out errOut))
                    throw new Exception(errOut);
                if (!Ammo.Inventory.ConvertAmmoGrainsToNum(databasePath, out errOut)) throw new Exception(errOut);
                //Perform Update in Registry of new hotfix
                if (!UpdateReg(hotFixNumber, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("Three", e));
            }
            return bAns;
        }
        #endregion
    }
}
