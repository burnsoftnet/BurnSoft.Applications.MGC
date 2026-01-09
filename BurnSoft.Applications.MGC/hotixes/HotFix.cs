using System;
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

                SendStatus($"Updating Registry with hotfix {hotFixNumber} being applied");
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

                SendStatus($"Updating Registry with hotfix {hotFixNumber} being applied");
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

                SendStatus($"Updating Registry with hotfix {hotFixNumber} being applied");
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
        /// <param name="databasePath">The Database Path</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        private bool Four(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 4;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                SendStatus($"Adding Settings Values to Registry");
                if (!MyRegistry.SetValue("Settings", "BackupOnExit", "False", out errOut)) throw new Exception(errOut);
                if (!MyRegistry.SetValue("Settings", "UseOrgImage", "False", out errOut)) throw new Exception(errOut);
                if (!MyRegistry.SetValue("Settings", "ViewPetLoads", "true", out errOut)) throw new Exception(errOut);
                if (!MyRegistry.SetValue("Settings", "IndvReports", "true", out errOut)) throw new Exception(errOut);

                SendStatus($"Adding Importer to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "Importer", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Dropping Table Gun Collection Ammo Details");
                if (!HfDatabase.Management.Tables.Drop(databasePath, "Gun_Collection_Ammo_Details", out errOut)) throw new Exception(errOut);
                SendStatus($"Dropping Table Gun Collection Ammo Details Pictures");
                if (!HfDatabase.Management.Tables.Drop(databasePath, "Gun_Collection_Ammo_Details_Pictures", out errOut)) throw new Exception(errOut);
                SendStatus($"Dropping Table Gun Shop Sales Emp");
                if (!HfDatabase.Management.Tables.Drop(databasePath, "Gun_Shop_SalesEmp", out errOut)) throw new Exception(errOut);

                SendStatus($"Adding New Gun Calibers to Table ");
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", ".223 Remington", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "5.56 x 45mm", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", ".30-06", out errOut)) throw new Exception(errOut);

                SendStatus($"Adding new Columns to Owner Info Table");
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
                SendStatus($"Updating Registry with hotfix {hotFixNumber} being applied");
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
        /// <param name="databasePath">The Database Path</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        private bool Five(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 5;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                SendStatus($"Creating Custom Reports Column List Table");
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE CR_ColumnList (ID AUTOINCREMENT PRIMARY KEY,TID INTEGER, Col Text(255), DN Text(255));",
                    out errOut, true)) throw new Exception(errOut);
                SendStatus($"Creating Custom Reports Saved Report Table");
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE CR_SavedReports (ID AUTOINCREMENT PRIMARY KEY,ReportName Text(255), MySQL MEMO,DTC DATETIME);",
                    out errOut, true)) throw new Exception(errOut);
                SendStatus($"Creating Custom Reports Table");
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE CR_TableList (ID INTEGER PRIMARY KEY,Tables Text(255), DN Text(255));",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "DELETE from CR_ColumnList",
                    out errOut, true)) throw new Exception(errOut);
                SendStatus($"Deleting Data into the Custom Reports Table");
                if (!HfDatabase.RunSql(databasePath,
                    "DELETE from CR_TableList",
                    out errOut, true)) throw new Exception(errOut);
                SendStatus($"Inserting Data into the Custom Reports Table");
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
                SendStatus($"Updating Registry with hotfix {hotFixNumber} being applied");
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
        /// <param name="databasePath">The Database Path</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        private bool Six(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 6;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                SendStatus($"Creating new Table Gun_Collection_Ammo_PriceAudit");
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE Gun_Collection_Ammo_PriceAudit (ID AUTOINCREMENT PRIMARY KEY,AID INTEGER,DTA DATETIME,Qty INTEGER,PricePaid DOUBLE,PPB DOUBLE);",
                    out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Column ReManDT to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "ReManDT", "Gun_Collection", "DATETIME", "Now()", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Adding Column POI to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "POI", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Updating Custom Report Column Lists");
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'ReManDT','Remanufacture Date')",
                    out errOut, true)) throw new Exception(errOut);
                if (!HfDatabase.RunSql(databasePath,
                    "INSERT INTO CR_ColumnList(TID,Col,DN) VALUES(4,'POI','Place Of Import')",
                    out errOut, true)) throw new Exception(errOut);

                //Perform Update in Registry of new hotfix
                SendStatus($"Updating Registry with hotfix {hotFixNumber} being applied");
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
            double dbVersion = 4.5;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                SendStatus($"Adding Data to Gun Collection Condition.");
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
                SendStatus($"Creating new Table for Barrel System Types");
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE Gun_Collection_BarrelSysTypes (ID AUTOINCREMENT PRIMARY KEY, [Name] TEXT(255));",
                    out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Data System Types to Barrel System Types");
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_BarrelSysTypes", "[Name]", "Regular Barrel", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_BarrelSysTypes", "[Name]", "Ported Barrel", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_BarrelSysTypes", "[Name]", "Threaded Barrel", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_BarrelSysTypes", "[Name]", "Complete Upper", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_BarrelSysTypes", "[Name]", "Conversion Kit", out errOut)) throw new Exception(errOut);

                //Perform Update in Registry of new hotfix
                SendStatus($"Adding new database Version {dbVersion}");
                if (!Database.SaveDatabaseVersion(databasePath, $"{dbVersion}", out errOut)) throw new Exception(errOut);
                SendStatus($"Updating Registry with hotfix {hotFixNumber} being applied");
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
            double dbVersion = 5.0;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                SendStatus($"Creating Sync Table");
                if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE sync_tables(ID AUTOINCREMENT PRIMARY KEY,tblname TEXT(255));",
                    out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value CR_SavedReports Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "CR_SavedReports", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value GunSmith_Details Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "GunSmith_Details", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Cal Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Cal", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Collection Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Collection_Accessories Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Accessories", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Collection_Ammo Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Ammo", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Collection_Ammo_PriceAudit Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Ammo_PriceAudit", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Collection_BarrelSysTypes Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_BarrelSysTypes", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Collection_Condition Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Condition", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Collection_Ext Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Ext", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Collection_Ext_Links Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Ext_Links", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Collection_Pictures Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Pictures", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Collection_SoldTo Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_SoldTo", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_GripType Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_GripType", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Manufacturer Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Manufacturer", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Model Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Model", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Nationality Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Nationality", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Shop_Details Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Shop_Details", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Gun_Type Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Type", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Maintance_Details Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Maintance_Details", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Maintance_Plans Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Maintance_Plans", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Owner_Info Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Owner_Info", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding Value Wishlist Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Wishlist", out errOut, true)) throw new Exception(errOut);

                //Perform Update in Registry of new hotfix
                SendStatus($"Adding new database Version {dbVersion}");
                if (!Database.SaveDatabaseVersion(databasePath, $"{dbVersion}", out errOut)) throw new Exception(errOut);
                SendStatus($"Updating Registry with hotfix {hotFixNumber} being applied");
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
        /// <param name="databasePath">The Database Path</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        private bool Nine(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 9;
            double dbVersion = 6.1;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                SendStatus($"Adding AppraisalDate colum to CR_ColumnList Table");
                if (!HfDatabase.RunSql(databasePath,
                    "UPDATE CR_ColumnList set Col='AppraisalDate' where Col='AppraisedDate'",
                    out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding IsInBoundBook column to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "IsInBoundBook", "Gun_Collection", "number", "0", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Adding IsClassIII column to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "IsClassIII", "Gun_Collection", "number", "0", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Adding ClassIII_owner column to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "ClassIII_owner", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Adding TwistRate column to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "TwistRate", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Adding lbs_trigger column to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "lbs_trigger", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Adding Caliber3 column to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "Caliber3", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Adding Classification column to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "Classification", "Gun_Collection", "Text(255)", "N/A", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Adding DateofCR column to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "DateofCR", "Gun_Collection", "DATETIME", "Now()", out errOut))
                    throw new Exception(errOut);

                SendStatus($"Setting New IsInBoundBook to 1 where values are Null");
                if (!HfDatabase.RunSql(databasePath,
                    "UPDATE Gun_Collection set IsInBoundBook=1 where IsInBoundBook Is Null",
                    out errOut, true)) throw new Exception(errOut);

                SendStatus($"Setting New IsClassIII to 0 where values are Null");
                if (!HfDatabase.RunSql(databasePath,
                    "UPDATE Gun_Collection set IsClassIII=0 where IsClassIII Is Null",
                    out errOut, true)) throw new Exception(errOut);

                SendStatus($"Setting New Classification to Modern where values are Nul");
                if (!HfDatabase.RunSql(databasePath,
                    "UPDATE Gun_Collection set Classification='Modern' where Classification Is Null",
                    out errOut, true)) throw new Exception(errOut);

                SendStatus($"Creating new table Appriaser_Contact_Details");
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

                SendStatus($"Adding Appriaser_Contact_Details to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Appriaser_Contact_Details", out errOut, true)) throw new Exception(errOut);

                SendStatus($"Adding Colum SIB to Appriaser_Contact_Details Table");
                if (!HfDatabase.RunSql(databasePath,
                    "ALTER TABLE Appriaser_Contact_Details ALTER SIB Number DEFAULT 1 NOT NULL;",
                    out errOut, true)) throw new Exception(errOut);

                SendStatus($"Creating new Table GunSmith_Contact_Details");
                sql ="CREATE TABLE GunSmith_Contact_Details (ID AUTOINCREMENT PRIMARY KEY,gName Text(255), Address1 Text(255)" +
                    ", Address2 Text(255),City Text(255),State Text(255), Country Text(255), Phone Text(255), fax Text(255)" +
                    ",website Text(255), email Text(255), lic Text(255), zip Text(255), SIB INTEGER);";
                if (!HfDatabase.RunSql(databasePath,
                    sql,
                    out errOut, true))
                {
                    if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                }

                SendStatus($"Adding GunSmith_Contact_Details Table to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "GunSmith_Contact_Details", out errOut, true)) throw new Exception(errOut);

                SendStatus($"Adding Column SIB to GunSmith_Contact_Details Table");
                if (!HfDatabase.RunSql(databasePath,
                    "ALTER TABLE GunSmith_Contact_Details ALTER SIB Number DEFAULT 1 NOT NULL;",
                    out errOut, true)) throw new Exception(errOut);

                SendStatus($"Moving Appraisers to New Table");
                if (!HfDatabase.ApplicationSpecific.MoveAppraisers(databasePath, out errOut)) throw new Exception(errOut);

                SendStatus($"Moving Gunsmiths to New Table");
                if (!HfDatabase.ApplicationSpecific.MoveGunSmiths(databasePath, out errOut)) throw new Exception(errOut);

                SendStatus($"Creating New Table for Document Storage");
                sql =
                    "CREATE TABLE Gun_Collection_Docs (ID AUTOINCREMENT PRIMARY KEY,doc_name Text(255), doc_description Text(255)" +
                    ", doc_filename Text(255),dta DATETIME,doc_file OLEOBJECT,length Number, doc_thumb OLEOBJECT,doc_ext Text(255), doc_cat Text(255));";
                if (!HfDatabase.RunSql(databasePath,
                    sql,
                    out errOut, true))
                {
                    if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                }

                SendStatus($"Adding Table Gun_Collection_Docs to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Docs", out errOut, true)) throw new Exception(errOut);

                SendStatus($"Adding Table Gun_Collection_Docs to Sync Table");
                if (!HfDatabase.RunSql(databasePath,
                    "ALTER TABLE Gun_Collection_Docs ALTER dta DATETIME DEFAULT NOW() NOT NULL;",
                    out errOut, true)) throw new Exception(errOut);

                SendStatus($"Creating new Table Gun_Collection_Docs_Links");
                sql = "CREATE TABLE Gun_Collection_Docs_Links (ID AUTOINCREMENT PRIMARY KEY,DID INTEGER, GID INTEGER,dta DATETIME)";
                if (!HfDatabase.RunSql(databasePath,
                    sql,
                    out errOut, true))
                {
                    if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                }

                SendStatus($"Adding Table Gun_Collection_Docs_Links to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Docs_Links", out errOut, true)) throw new Exception(errOut);

                SendStatus($"Creating new Table Gun_Collection_Classification");
                sql = "CREATE TABLE Gun_Collection_Classification (ID AUTOINCREMENT PRIMARY KEY,myclass Text(255))";
                if (!HfDatabase.RunSql(databasePath,
                    sql,
                    out errOut, true))
                {
                    if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                }

                SendStatus($"Adding Table Gun_Collection_Classification to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "Gun_Collection_Classification", out errOut, true)) throw new Exception(errOut);

                SendStatus($"Adding Antique to Gun_Collection_Classification");
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Classification", "[myclass]", "Antique", out errOut)) throw new Exception(errOut);

                SendStatus($"Adding C&R to Gun_Collection_Classification");
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Classification", "[myclass]", "C&R", out errOut)) throw new Exception(errOut);

                SendStatus($"Adding Modern to Gun_Collection_Classification");
                if (!HfDatabase.AddNewData(databasePath, "Gun_Collection_Classification", "[myclass]", "Modern", out errOut)) throw new Exception(errOut);


                //Perform Update in Registry of new hotfix
                SendStatus($"Adding new database Version {dbVersion}");
                if (!Database.SaveDatabaseVersion(databasePath, $"{dbVersion}", out errOut)) throw new Exception(errOut);

                SendStatus($"Updating Registry with hotfix {hotFixNumber} being applied");
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
        /// Hot Fix number 10, Mostly Related to the 7.x release
        /// </summary>
        /// <param name="databasePath">The Database Path</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        private bool Ten(string databasePath, out string errOut)
        {
            errOut = "";
            int hotFixNumber = 10;
            double dbVersion = 7.4;
            bool bAns = false;
            SendStatus($"Starting Hotfix {hotFixNumber}.");
            try
            {
                SendStatus($"Adding Column ToSell ( ToSell ) to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "ToSell", "Gun_Collection", "YESNO", out errOut))
                    throw new Exception(errOut);

                SendStatus($"Adding Column GunSmithJob ( GunSmithJob ) to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "GunSmithJob", "Gun_Collection", "YESNO", out errOut))
                    throw new Exception(errOut);

                SendStatus($"Adding Column For Collecting ( ForCollecting ) to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "ForCollecting", "Gun_Collection", "YESNO", out errOut))
                    throw new Exception(errOut);

                if (!HfDatabase.TableExists(databasePath, "General_Accessories_Link", out errOut))
                {
                    SendStatus($"Creating Table Accessories Link");
                    if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE General_Accessories_Link (ID AUTOINCREMENT PRIMARY KEY, GID Number, AID Number, " +
                    "sync_lastupdate DATETIME);",
                    out errOut, true))
                    {
                        if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                    }
                }
                else
                {
                    SendStatus($"Table Accessories Link Already Exists");
                }

                if (!HfDatabase.TableExists(databasePath, "General_Accessories", out errOut))
                {
                    SendStatus($"Creating Table General Accessories Table");
                    if (!HfDatabase.RunSql(databasePath,
                    "CREATE TABLE General_Accessories (ID AUTOINCREMENT PRIMARY KEY, Manufacturer Text(255), Model Text(255), " +
                    "SerialNumber Text(255), Condition Text(255), Notes Text(255), Use Text(255), PurValue Text(255), " +
                    "AppValue Number, CIV NUmber, IC Number, FAID Number, IsLinked YESNO, sync_lastupdate DATETIME);",
                    out errOut, true))
                    {
                        if (!errOut.Contains(" already exists")) throw new Exception(errOut);
                    }
                }
                else
                {
                    SendStatus($"Table General Accessories Already Exists");
                }

                    
                SendStatus($"Adding Accessories Link to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "General_Accessories_Link", out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding General Accessories to Sync Table");
                if (!HfDatabase.AddSyncToTable(databasePath, "General_Accessories", out errOut, true)) throw new Exception(errOut);

                SendStatus($"Adding Column Firearm Accessories Link ID ( GALID ) to Gun Collection Accessories Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "GALID", "Gun_Collection_Accessories", "number", "0", out errOut))
                    throw new Exception(errOut);

                SendStatus($"Adding Column Firearm Accessories IsLinked ( IsLinked ) to Gun Collection Accessories Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "IsLinked", "Gun_Collection_Accessories", "YESNO", out errOut))
                    throw new Exception(errOut);

                SendStatus($"Settings all GALID to 0 for Gun Collection Accessories Table");
                if (!HfDatabase.RunSql(databasePath,
                   "UPDATE Gun_Collection_Accessories set GALID=0",
                   out errOut, true)) throw new Exception(errOut);

                SendStatus($"Adding Column isCompetitition to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "isCompetition", "Gun_Collection", "number", "0", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Adding column is Non Lethal to Gun Collection");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "IsNoLeathal", "Gun_Collection", "number", "0", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Setting new columns to 0 in Gun Collection table");
                if (!HfDatabase.RunSql(databasePath, "UPDATE Gun_Collection set isCompetition=0,IsNoLeathal=0",
                    out errOut, true)) throw new Exception(errOut);
                SendStatus($"Adding GunSmith ID to Gunsmith Details Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "GSID", "GunSmith_Details", "number", "0", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Adding Rating column to Gun Collection Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "Rating", "Gun_Collection", "number", "0", out errOut))
                    throw new Exception(errOut);

                SendStatus($"Settings all Ratings to 0 for Gun Collection Table if all colmuns are null");
                if (!HfDatabase.RunSql(databasePath,
                  "UPDATE Gun_Collection set Rating=0 where Rating is Null",
                  out errOut, true)) throw new Exception(errOut);

                SendStatus($"Adding PicOrder to Gun Collection Pictures Table");
                if (!HfDatabase.Management.Tables.Columns.Add(databasePath, "PicOrder", "Gun_Collection_Pictures", "number", "0", out errOut))
                    throw new Exception(errOut);
                SendStatus($"Settings Order to 0 on pic Orders");
                if (!HfDatabase.RunSql(databasePath,
                  "UPDATE Gun_Collection_Pictures set PicOrder=0 where PicOrder is Null",
                  out errOut, true)) throw new Exception(errOut);

                SendStatus($"Adding New Gun Calibers to Table ");
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "6.8x51mm SIG Fury", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "7 PRC", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "6mm ARC", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "6.8 Western", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", ".30 Super Carry", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "25 RPM", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", ".350 Legend", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "6.5 PRC", out errOut)) throw new Exception(errOut);
                if (!HfDatabase.AddNewData(databasePath, "Gun_Cal", "Cal", "6mm Creedmoor", out errOut)) throw new Exception(errOut);

                //Perform Update in Registry of new hotfix
                SendStatus($"Updating Databbase version to {dbVersion}");
                if (!Database.SaveDatabaseVersion(databasePath, $"{dbVersion}", out errOut)) throw new Exception(errOut);
                SendStatus($"Applying hotfix to registry ");
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
        /// Runs the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="hotFixNumber">The hot fix number.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RunObj(string databasePath, int hotFixNumber, out string errOut)
        {
            bool bans = false;
            errOut = "";
            try
            {
                SendStatus($"Starting up hot fix number: {hotFixNumber}");

                switch (hotFixNumber)
                {
                    case 1:
                        bans = One(databasePath, out errOut);
                        break;
                    case 2:
                        bans = Two(databasePath, out errOut);
                        break;
                    case 3:
                        bans = Three(databasePath, out errOut);
                        break;
                    case 4:
                        bans = Four(databasePath, out errOut);
                        break;
                    case 5:
                        bans = Five(databasePath, out errOut);
                        break;
                    case 6:
                        bans = Six(databasePath, out errOut);
                        break;
                    case 7:
                        bans = Seven(databasePath, out errOut);
                        break;
                    case 8:
                        bans = Eight(databasePath, out errOut);
                        break;
                    case 9:
                        bans = Nine(databasePath, out errOut);
                        break;
                    case 10:
                        bans = Ten(databasePath, out errOut);
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
            cmd.Add(new HotFixToDbList()
            {
                HotFix = 11,
                DbVersion = 7.4
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
