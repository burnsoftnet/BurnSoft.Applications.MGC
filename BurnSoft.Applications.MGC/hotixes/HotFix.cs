﻿using System;
using System.Collections.Generic;
using System.Globalization;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Global;
using BurnSoft.Applications.MGC.hotixes.types;
// ReSharper disable UnusedMember.Global
// ReSharper disable UseObjectOrCollectionInitializer

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.hotixes
{
    /// <summary>
    /// Class HotFix. Hotfix fix main functions
    /// </summary>
    public class HotFix
    {
        /// <summary>
        /// The number of fixes for this version in the datrabase
        /// </summary>
        public const int NumberOfFixes = 10;

        
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
        /// <param name="installNotice">Default marks as oninstall, but if you apply on update, then use date</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        private bool UpdateReg(int hotfixNumber, out string errOut, string installNotice = "OnInstall")
        {
            errOut = "";
            bool bAns = false;
            try
            {
                if (!MyRegistry.SetHotFix(hotfixNumber, out errOut, installNotice)) throw new Exception(errOut);
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
                if (!HfDatabase.Security.AddPassword(databasePath, out errOut)) throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "PetLoads", "Gun_Collection", "TEXT(255)", "'  '", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "dtp", "Gun_Collection", "DATE", "'  '", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath, "Update Gun_Collection set PetLoads=' '", out errOut, true)) throw new Exception(errOut);

                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "IsCandR", "Gun_Collection", "Number", "0", out errOut))
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
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "10 Gauge", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "12 Gauge", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "16 Gauge", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "20 Gauge", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "28 Gauge", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", ".410 Gauge", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Slide Action", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Commemorative", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Fixed Barrel", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Flintlock", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Derringer", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Bolt Action", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Semi-Auto - SA/DA", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Semi-Auto - SA Only", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Semi-Auto - DAO", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Single Shot", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Pistol: Misc", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Revolver: SA/DA", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Revolver: SA only", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Type", "Type", "Revolver: Misc", out errOut)) throw new Exception(errOut);

                if (doSwapValues)
                {
                    if (!HfDatabase.ApplicationSpecific.SwapValues(databasePath, "Gun_Collection", "dt", "dtp", out errOut))
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
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "ISMAIN", "Gun_Collection_Pictures", "Number", "0", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath, "UPDATE Gun_Collection_Pictures set ISMAIN=0 where ISMAIN <> 1", out errOut, true)) throw new Exception(errOut);
  
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
        /// <summary>
        /// hot fix 4
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
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
                
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "Importer", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Drop(databasePath, "Gun_Collection_Ammo_Details", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Drop(databasePath, "Gun_Collection_Ammo_Details_Pictures", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Drop(databasePath, "Gun_Shop_SalesEmp", out errOut)) throw new Exception(errOut);

                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", ".223 Remington", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "5.56 x 45mm", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", ".30-06", out errOut)) throw new Exception(errOut);

                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "UID", "Owner_Info", "Memo", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "forgot_word", "Owner_Info", "Memo", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "forgot_phrase", "Owner_Info", "Memo", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "dcal", "Gun_Collection_Ammo", "number", "0", out errOut))
                    throw new Exception(errOut);
                if (!Ammo.Inventory.ConvertAmmoGrainsToNum(databasePath, out errOut)) throw new Exception(errOut);
                //Perform Update in Registry of new hotfix
                if (!UpdateReg(hotFixNumber, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("Four", e));
            }
            return bAns;
        }
        /// <summary>
        /// hot Fix 5
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        private bool Five(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 5;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE CR_ColumnList (ID AUTOINCREMENT PRIMARY KEY,TID INTEGER, Col Text(255), DN Text(255));",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE CR_SavedReports (ID AUTOINCREMENT PRIMARY KEY,ReportName Text(255), MySQL MEMO,DTC DATETIME);",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE CR_TableList (ID INTEGER PRIMARY KEY,Tables Text(255), DN Text(255));",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "DELETE from CR_ColumnList",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "DELETE from CR_TableList",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_TableList (ID,Tables,DN) VALUES (1,'Gun_Cal','Caliber List')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_TableList (ID,Tables,DN) VALUES (2,'Gun_Collection_Ammo','Ammunition Inventory')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_TableList (ID,Tables,DN) VALUES (3,'Gun_Manufacturer','Manufacturer List')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_TableList (ID,Tables,DN) VALUES (4,'qryGunCollectionDetails','Gun Collection')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_TableList (ID,Tables,DN) VALUES (5,'Gun_Shop_Details','Firearm Stores')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_TableList (ID,Tables,DN) VALUES (6,'Gun_Collection_SoldTo','Buyer List')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_TableList (ID,Tables,DN) VALUES (7,'Wishlist','Wishlist')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(1,'Cal','Caliber')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(2,'Manufacturer','Manufacturer')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(2,'Name','Name')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(2,'Cal','Caliber')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(2,'Grain','Bullet Grains')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(2,'Jacket','Jacket')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(2,'Qty','Qty')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(3,'Brand','Name')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'FullName','Full Name')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'ModelName','Model Name')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'SerialNumber','Serial Number')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Type','Firearm Type')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Caliber','Caliber')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Finish','Finish')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Condition','Condition')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'CustomID','Custom ID')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'NatID','Place of Origin')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Weight','Weight')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Height','Height')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'StockType','Stock')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'BarrelLength','Barrel Length')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Action','Action')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'FeedSystem','Feed System')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Sights','Sights')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'PurchasedPrice','Purchased Price')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'PurchasedFrom','Purchased From')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'AppraisedValue','Appraised Value')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'AppraisedDate','Appraised Date')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'AppraisedBy','Appraised By')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'InsuredValue','Insured Value')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Produced','Produced Date')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Dt','Date Added')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'dtSold','Date Sold')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'dtp','Date Purchased')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Importer','Importer')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'Brand','Manufacturer')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'Name','Name')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'Address1','Address')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'Address2','Address 2')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'City','City')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'State','State')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'Zip','Zip Code')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'Country','Country')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'Phone','Phone')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'fax','fax')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'website','website')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'email','email')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(5,'lic','FFL License')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'Name','Name')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'Address1','Address')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'Address2','Address 2')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'City','City')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'State','State')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'Country','Country')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'Phone','Phone')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'fax','fax')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'website','website')",
                    out errOut, true)) throw new Exception(errOut); 
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'email','email')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'lic','FFL/CCL')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'DOB','Date of Birth')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'Dlic','Drivers License')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'Resident','Resident')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(6,'ZipCode','Zip Code')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(7,'Manufacturer','Manufacturer')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(7,'Model','Model')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(7,'PlacetoBuy','Place to Buy')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(7,'Qty','Qty')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(7,'Value','Price')",
                    out errOut, true)) throw new Exception(errOut);


                //Perform Update in Registry of new hotfix
                if (!UpdateReg(hotFixNumber, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("Five", e));
            }
            return bAns;
        }
        /// <summary>
        /// hot fix 6
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        private bool Six(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 6;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE Gun_Collection_Ammo_PriceAudit (ID AUTOINCREMENT PRIMARY KEY,AID INTEGER,DTA DATETIME,Qty INTEGER,PricePaid DOUBLE,PPB DOUBLE);",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "ReManDT", "Gun_Collection", "DATETIME", "Now()", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "POI", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'ReManDT','Remanufacture Date')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'POI','Place Of Import')",
                    out errOut, true)) throw new Exception(errOut);

                //Perform Update in Registry of new hotfix
                if (!UpdateReg(hotFixNumber, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("Six", e));
            }
            return bAns;
        }
        /// <summary>
        /// Sevens the specified database path.
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
        private bool Seven(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 7;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "New", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "New, Discontinued", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Perfect", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Perfect, Discontinued", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Excellent", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Excellent, Discontinued", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Very Good", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Good", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Good, Discontinued", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Fair", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Poor", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Antique Factory New", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Antique Excellent", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Antique Fine", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Antique Very Good", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Antique Good", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Antique Fair", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Antique Poor", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Refinished", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "100%", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "90%", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "80%", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "70%", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "60%", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "50%", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "40%", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "30%", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "20%", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "10%", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Condition", "[Name]", "Broken", out errOut)) throw new Exception(errOut);

                //Create barrel System Types
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE Gun_Collection_BarrelSysTypes (ID AUTOINCREMENT PRIMARY KEY, [Name] TEXT(255));",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_BarrelSysTypes", "[Name]", "Regular Barrel", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_BarrelSysTypes", "[Name]", "Ported Barrel", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_BarrelSysTypes", "[Name]", "Threaded Barrel", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_BarrelSysTypes", "[Name]", "Complete Upper", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_BarrelSysTypes", "[Name]", "Conversion Kit", out errOut)) throw new Exception(errOut);

                //Perform Update in Registry of new hotfix
                if (!Database.SaveDatabaseVersion(databasePath, "4.5", out errOut)) throw new Exception(errOut);
                if (!UpdateReg(hotFixNumber, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("Seven", e));
            }
            return bAns;
        }
        /// <summary>
        /// Eights the specified database path.
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
        private bool Eight(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 8;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE sync_tables(ID AUTOINCREMENT PRIMARY KEY,tblname TEXT(255));",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "CR_SavedReports", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "GunSmith_Details", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Cal", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Accessories", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Ammo", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Ammo_PriceAudit", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_BarrelSysTypes", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Condition", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Ext", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Ext_Links", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Pictures", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_SoldTo", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_GripType", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Manufacturer", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Model", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Nationality", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Shop_Details", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Type", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Maintance_Details", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Maintance_Plans", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Owner_Info", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.AddSyncToTable(databasePath, "Wishlist", out errOut, true)) throw new Exception(errOut);

                //Perform Update in Registry of new hotfix
                if (!Database.SaveDatabaseVersion(databasePath, "5.0", out errOut)) throw new Exception(errOut);
                if (!UpdateReg(hotFixNumber, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("Eight", e));
            }
            return bAns;
        }
        /// <summary>
        /// Hotfix Number 9
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        private bool Nine(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 9;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                if (!HfDatabase.RunSql(databasePath,
                    "UPDATE CR_ColumnList set Col='AppraisalDate' where Col='AppraisedDate'",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "IsInBoundBook", "Gun_Collection", "number", "0", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "IsClassIII", "Gun_Collection", "number", "0", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "ClassIII_owner", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "TwistRate", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "lbs_trigger", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "Caliber3", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "Classification", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "DateofCR", "Gun_Collection", "DATETIME", "Now()", out errOut))
                    throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "UPDATE Gun_Collection set IsInBoundBook=1",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "UPDATE Gun_Collection set IsClassIII=0",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "UPDATE Gun_Collection set Classification='Modern'",
                    out errOut, true)) throw new Exception(errOut);
                string sql =
                    "CREATE TABLE Appriaser_Contact_Details (ID AUTOINCREMENT PRIMARY KEY,aName Text(255), Address1 Text(255)" +
                    ", Address2 Text(255),City Text(255),State Text(255), Country Text(255), Phone Text(255), fax Text(255)" +
                    ",website Text(255), email Text(255), lic Text(255), zip Text(255), SIB INTEGER);";
                if (!HfDatabase.RunSql(databasePath,
                    sql,
                    out errOut, true))
                {
                    if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                }
                if (!HfDatabase.AddSyncToTable(databasePath, "Appriaser_Contact_Details", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "ALTER TABLE Appriaser_Contact_Details ALTER SIB Number DEFAULT 1 NOT NULL;",
                    out errOut, true)) throw new Exception(errOut);

                sql ="CREATE TABLE GunSmith_Contact_Details (ID AUTOINCREMENT PRIMARY KEY,gName Text(255), Address1 Text(255)" +
                    ", Address2 Text(255),City Text(255),State Text(255), Country Text(255), Phone Text(255), fax Text(255)" +
                    ",website Text(255), email Text(255), lic Text(255), zip Text(255), SIB INTEGER);";
                if (!HfDatabase.RunSql(databasePath,
                    sql,
                    out errOut, true))
                {
                    if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                }

                if (!HfDatabase.AddSyncToTable(databasePath, "GunSmith_Contact_Details", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "ALTER TABLE GunSmith_Contact_Details ALTER SIB Number DEFAULT 1 NOT NULL;",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.ApplicationSpecific.MoveAppraisers(databasePath, out errOut)) throw new Exception(errOut);
                if (!HfDatabase.ApplicationSpecific.MoveGunSmiths(databasePath, out errOut)) throw new Exception(errOut);

                sql =
                    "CREATE TABLE Gun_Collection_Docs (ID AUTOINCREMENT PRIMARY KEY,doc_name Text(255), doc_description Text(255)" +
                    ", doc_filename Text(255),dta DATETIME,doc_file OLEOBJECT,length Number, doc_thumb OLEOBJECT,doc_ext Text(255), doc_cat Text(255));";
                if (!HfDatabase.RunSql(databasePath,
                    sql,
                    out errOut, true))
                {
                    if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                }
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Docs", out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "ALTER TABLE Gun_Collection_Docs ALTER dta DATETIME DEFAULT NOW() NOT NULL;",
                    out errOut, true)) throw new Exception(errOut);


                sql = "CREATE TABLE Gun_Collection_Docs_Links (ID AUTOINCREMENT PRIMARY KEY,DID INTEGER, GID INTEGER,dta DATETIME)";
                if (!HfDatabase.RunSql(databasePath,
                    sql,
                    out errOut, true))
                {
                    if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                }
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Docs_Links", out errOut, true)) throw new Exception(errOut);

                sql = "CREATE TABLE Gun_Collection_Classification (ID AUTOINCREMENT PRIMARY KEY,myclass Text(255))";
                if (!HfDatabase.RunSql(databasePath,
                    sql,
                    out errOut, true))
                {
                    if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                }
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Classification", out errOut, true)) throw new Exception(errOut);

                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Classification", "[myclass]", "Antique", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Classification", "[myclass]", "C&R", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Classification", "[myclass]", "Modern", out errOut)) throw new Exception(errOut);


                //Perform Update in Registry of new hotfix
                if (!Database.SaveDatabaseVersion(databasePath, "6.0", out errOut)) throw new Exception(errOut);
                if (!UpdateReg(hotFixNumber, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("Nine", e));
            }
            return bAns;
        }
        /// <summary>
        /// Hot Fix number 10
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        private bool Ten(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 10;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE Gun_Collection_Accessories_Link (ID AUTOINCREMENT PRIMARY KEY, GID Number, AID Number);",
                    out errOut, true))
                {
                    if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                }

                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Accessories_Link", out errOut, true)) throw new Exception(errOut);
                

                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "isCompetition", "Gun_Collection", "number", "0", out errOut))
                    throw new Exception(errOut);

                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "IsNoLeathal", "Gun_Collection", "number", "0", out errOut))
                    throw new Exception(errOut);

                if (!HfDatabase.RunSql(databasePath, "UPDATE Gun_Collection set isCompetition=0,IsNoLeathal=0",
                    out errOut, true)) throw new Exception(errOut);

                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "GSID", "GunSmith_Details", "number", "0", out errOut))
                    throw new Exception(errOut);


                //Perform Update in Registry of new hotfix
                if (!Database.SaveDatabaseVersion(databasePath, "6.1", out errOut)) throw new Exception(errOut);
                if (!UpdateReg(hotFixNumber, out errOut, DateTime.Now.ToString(CultureInfo.InvariantCulture))) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                SendErrors(ErrorMessage("Ten", e));
            }
            return bAns;
        }
        #endregion        
        /// <summary>
        /// Runs the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="hotFixNumber">The hot fix number.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Run(string databasePath, int hotFixNumber, out string errOut)
        {
            bool bans = false;
            errOut = "";
            try
            {
                HotFix hotfix = new HotFix();
                switch (hotFixNumber)
                {
                    case 1:
                        bans = hotfix.One(databasePath, out errOut);
                        break;
                    case 2:
                        bans = hotfix.Two(databasePath, out errOut);
                        break;
                    case 3:
                        bans = hotfix.Three(databasePath, out errOut);
                        break;
                    case 4:
                        bans = hotfix.Four(databasePath, out errOut);
                        break;
                    case 5:
                        bans = hotfix.Five(databasePath, out errOut);
                        break;
                    case 6:
                        bans = hotfix.Six(databasePath, out errOut);
                        break;
                    case 7:
                        bans = hotfix.Seven(databasePath, out errOut);
                        break;
                    case 8:
                        bans = hotfix.Eight(databasePath, out errOut);
                        break;
                    case 9:
                        bans = hotfix.Nine(databasePath, out errOut);
                        break;
                    case 10:
                        bans = hotfix.Ten(databasePath, out errOut);
                        break;
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Run", e);
            }
            return bans;
        }
        /// <summary>
        /// Hotfixes to database version.
        /// </summary>
        /// <returns>List&lt;HotFixToDbList&gt;.</returns>
        private static List<HotFixToDbList> HotfixToDbVersion()
        {
            List<HotFixToDbList> cmd = new List<HotFixToDbList>();
            cmd.Add(new HotFixToDbList()
            {
                HotFix = 1,
                DbVersion = 0
            });
            cmd.Add(new HotFixToDbList()
            {
                HotFix = 2,
                DbVersion = 0
            });
            cmd.Add(new HotFixToDbList()
            {
                HotFix = 3,
                DbVersion = 0
            });
            cmd.Add(new HotFixToDbList()
            {
                HotFix = 4,
                DbVersion = 0
            });
            cmd.Add(new HotFixToDbList()
            {
                HotFix = 5,
                DbVersion = 0
            });
            cmd.Add(new HotFixToDbList()
            {
                HotFix = 6,
                DbVersion = 0
            });
            cmd.Add(new HotFixToDbList()
            {
                HotFix = 7,
                DbVersion = 4.5
            });
            cmd.Add(new HotFixToDbList()
            {
                HotFix = 8,
                DbVersion = 5.0
            });
            cmd.Add(new HotFixToDbList()
            {
                HotFix = 9,
                DbVersion = 6.0
            });
            cmd.Add(new HotFixToDbList()
            {
                HotFix = 10,
                DbVersion = 6.1
            });
            return cmd;
        }
        /// <summary>
        /// Needses the update.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;System.Int32&gt;.</returns>
        internal static List<int> UpdateList(string databasePath, out string errOut)
        {
            List<int> hotFixList = new List<int>();
            errOut = "";
            try
            {
                string version = DatabaseRelated.GetDatabaseVersion(databasePath, out errOut);
                double ver = Convert.ToDouble(version);
                List<HotFixToDbList> toDoList = HotfixToDbVersion();

                foreach (HotFixToDbList t in toDoList)
                {
                    if (t.DbVersion > ver)
                    {
                        hotFixList.Add(t.HotFix);
                    }
                }
                hotFixList.Sort();
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("UpdateList", e);
            }
            return hotFixList;
        }
        /// <summary>
        /// Needses the update.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool NeedsUpdate(string databasePath, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                List<int> hotFixList = UpdateList(databasePath, out errOut);
                bAns = hotFixList.Count > 0;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("NeedsUpdate", e);
            }
            return bAns;
        }

        /// <summary>
        /// Applies the missing hot fixes.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="appliedFixes"></param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool ApplyMissingHotFixes(string databasePath, out string errOut, out string appliedFixes)
        {
            bool bAns = false;
            errOut = "";
            appliedFixes = "";
            try
            {
                List<int> hotFixList = UpdateList(databasePath, out errOut);

                foreach (int h in hotFixList)
                {
                    if (!Run(databasePath, h, out errOut)) throw new Exception(errOut);
                    appliedFixes += $"{h} ";
                }
                bAns = true;
                if (appliedFixes.Length > 0)
                {
                    appliedFixes = appliedFixes.Trim();
                    appliedFixes = appliedFixes.Replace(" ", ",");

                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("ApplyMissingHotFixes", e);
            }
            return bAns;
        }
    }
}
