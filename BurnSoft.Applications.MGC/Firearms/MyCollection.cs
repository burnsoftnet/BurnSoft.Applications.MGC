using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Global;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Universal;
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class MyCollection, The majority of this class will hand the data from the gun_collection table.
    /// </summary>
    public class MyCollection
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.Firearms.MyCollection";
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
        /// Adds the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="useNumberOnlyCatalog">if set to <c>true</c> [use number only catalog].</param>
        /// <param name="ownerId">The owner identifier.</param>
        /// <param name="manufactureId">The manufacture identifier.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="modelName">Name of the model.</param>
        /// <param name="modelId">The model identifier.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="firearmType">Type of the firearm.</param>
        /// <param name="caliber">The caliber.</param>
        /// <param name="finish">The finish.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="customId">The custom identifier.</param>
        /// <param name="natId">The nat identifier.</param>
        /// <param name="gripId">The grip identifier.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="height">The height.</param>
        /// <param name="stockType">Type of the stock.</param>
        /// <param name="barrelLength">Length of the barrel.</param>
        /// <param name="barrelWidth">Width of the barrel.</param>
        /// <param name="barrelHeight">Height of the barrel.</param>
        /// <param name="action">The action.</param>
        /// <param name="feedsystem">The feedsystem.</param>
        /// <param name="sights">The sights.</param>
        /// <param name="purchasedPrice">The purchased price.</param>
        /// <param name="purchasedFrom">The purchased from.</param>
        /// <param name="appraisedValue">The appraised value.</param>
        /// <param name="appraisalDate">The appraisal date.</param>
        /// <param name="appraisedBy">The appraised by.</param>
        /// <param name="insuredValue">The insured value.</param>
        /// <param name="storageLocation">The storage location.</param>
        /// <param name="conditionComments">The condition comments.</param>
        /// <param name="additionalNotes">The additional notes.</param>
        /// <param name="produced">The produced.</param>
        /// <param name="petLoads">The pet loads.</param>
        /// <param name="dtp">The DTP.</param>
        /// <param name="isCandR">if set to <c>true</c> [is cand r].</param>
        /// <param name="importer">The importer.</param>
        /// <param name="reManDt">The re man dt.</param>
        /// <param name="poi">The poi.</param>
        /// <param name="sgChoke">The sg choke.</param>
        /// <param name="isInBoundBook">if set to <c>true</c> [is in bound book].</param>
        /// <param name="twistRate">The twist rate.</param>
        /// <param name="lbsTrigger">The LBS trigger.</param>
        /// <param name="caliber3">The caliber3.</param>
        /// <param name="classification">The classification.</param>
        /// <param name="dateofCr">The dateof cr.</param>
        /// <param name="isClassIii">if set to <c>true</c> [is class iii].</param>
        /// <param name="classIiiOwner">The class iii owner.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static bool Add(string databasePath, bool useNumberOnlyCatalog, long ownerId, long manufactureId, string fullName, string modelName, long modelId, string serialNumber,
            string firearmType, string caliber, string finish, string condition,
            string customId, long natId, long gripId, string weight, string height, string stockType,
            string barrelLength, string barrelWidth, string barrelHeight,
            string action, string feedsystem, string sights, string purchasedPrice, string purchasedFrom,
            string appraisedValue, string appraisalDate, string appraisedBy,
            string insuredValue, string storageLocation, string conditionComments, string additionalNotes,
            string produced, string petLoads, string dtp, bool isCandR, string importer, string reManDt, string poi,
            string sgChoke,bool isInBoundBook,string twistRate, string lbsTrigger,string caliber3,string classification,string dateofCr,bool isClassIii,string classIiiOwner, out string errOut)
        {
            errOut = "";
            bool bAns = false;
            try
            {
                int iBoundBook = isInBoundBook ? 1 : 0;
                int iIsClassIii = isClassIii ? 1 : 0;
                int iisCandR = isCandR ? 1 : 0;

                //string sql = "INSERT INTO Gun_Collection(OID,MID,FullName,ModelName,ModelID,SerialNumber,Type,Caliber,Finish,Condition," +
                //"CustomID,NatID,GripID,Qty,Weight,Height,StockType,BarrelLength,BarrelWidth,BarrelHeight," +
                //"Action,Feedsystem,Sights,PurchasedPrice,PurchasedFrom,AppraisedValue,AppraisalDate,AppraisedBy," +
                //"InsuredValue,StorageLocation,ConditionComments,AdditionalNotes,Produced,PetLoads,dtp,IsCandR,Importer," +
                //"ReManDT,POI,SGChoke,sync_lastupdate,HasMB,DBID,IsInBoundBook,TwistRate,lbs_trigger,Caliber3,Classification,DateofCR," +
                //$"ItemSold,BID,IsClassIII,ClassIII_owner) VALUES({ownerId},{manufactureId},'{fullName}','{modelName}', {modelId}, '{serialNumber}'," +
                //$"'{firearmType}','{caliber}','{finish}','{condition}',{Helpers.SetCatalogInsType(useNumberOnlyCatalog,customId, out _)},{natId}," +
                //$"{gripId},1,'{weight}','{height}','{stockType}','{barrelLength}'" +
                //$",'{barrelWidth}','{barrelHeight}','{action}','{feedsystem}','{sights}','{purchasedPrice}','{purchasedFrom}','{appraisedValue}'," +
                //$"'{appraisalDate}','{appraisedBy}','{insuredValue}','{storageLocation}','{conditionComments}','{additionalNotes}','{produced}'," +
                //$"'{petLoads}','{dtp}',{iisCandR},'{importer}','{reManDt}','{poi}','{sgChoke}',Now(),0,0,{iBoundBook},'{twistRate}','{lbsTrigger}'" +
                //$",'{caliber3}','{classification}','{dateofCr}',0,2,{iIsClassIii},'{classIiiOwner}')";

                string sql =
                    "INSERT INTO Gun_Collection (OID,MID,FullName,ModelName,ModelID,SerialNumber,Type,Caliber,Finish,Condition," +
                    "CustomID,NatID,GripID,Qty,Weight,Height,StockType,BarrelLength,BarrelWidth,BarrelHeight," +
                    "Action,Feedsystem,Sights,PurchasedPrice,PurchasedFrom,AppraisedValue,AppraisalDate,AppraisedBy," +
                    "InsuredValue,StorageLocation,ConditionComments,AdditionalNotes,Produced,PetLoads,dtp,IsCandR,Importer," +
                    "ReManDT,POI,HasMB,DBID,SGChoke,IsInBoundBook,TwistRate,lbs_trigger,Caliber3,Classification,DateofCR,ItemSold," +
                    "BID,sync_lastupdate,IsClassIII,ClassIII_owner) VALUES(" +
                    ownerId + "," + manufactureId + ",'" + fullName + "','" + modelName + "'," + modelId + ",'" +
                    serialNumber + "','" +
                    firearmType + "','" + caliber + "','" + finish + "','" + condition + "'," +
                    Helpers.SetCatalogInsType(useNumberOnlyCatalog, customId, out _) + "," +
                    natId + "," + gripId + "," + 1 + ",'" + weight + "','" + height + "','" +
                    stockType + "','" + barrelLength + "','" + barrelWidth + "','" + barrelHeight + "','" + action +
                    "','" +
                    feedsystem + "','" + sights + "','" + purchasedPrice + "','" + purchasedFrom + "','" + appraisedValue +
                    "','" +
                    appraisalDate + "','" + appraisedBy + "','" + insuredValue + "','" + storageLocation + "','" + conditionComments + "','" +
                    additionalNotes +
                    "','" + produced + "','" + petLoads + "','" + dtp + "'," + iisCandR + ",'" +
                    importer +
                    "','" + reManDt + "','" + poi + "',0,0,'" + sgChoke + "'," + iBoundBook + ",'" + twistRate + "','" +
                    lbsTrigger +
                    "','" + caliber3 + "','" + classification + "','" + dateofCr + "',0,2,Now()," + iIsClassIii +
                    ",'" + classIiiOwner + "')";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (!bAns) throw new Exception(errOut);
                
                //Not Time to add the extra barrel and sellers if they don't exist, get those id's and update the main table with the id's
                long id = GetLastId(databasePath, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                bAns = ExtraBarrelConvoKits.Add(databasePath, id, modelName, caliber, finish, barrelLength, petLoads,
                    action, feedsystem, sights, "0.00", purchasedFrom, height, "Fixed Barrel", true, out errOut);
                long barrelId = ExtraBarrelConvoKits.GetBarrelId(databasePath, id, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                bAns = UpdateDefaultBarrel(databasePath, barrelId, id, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                bAns = ExtraBarrelConvoKits.AddLink(databasePath, barrelId, id, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);

                if (purchasedFrom.Trim().Length > 0)
                {
                    if (!PeopleAndPlaces.Shops.Exists(databasePath, purchasedFrom, out errOut))
                    {
                        PeopleAndPlaces.Shops.Add(databasePath, purchasedFrom, out errOut);
                        if (errOut.Length > 0) throw new Exception(errOut);
                    }

                    long gunShopId = PeopleAndPlaces.Shops.GetId(databasePath, purchasedFrom, out errOut);
                    if (errOut.Length > 0) throw new Exception(errOut);
                    bAns = UpdateSellerId(databasePath, gunShopId, id, out errOut);
                    if (errOut.Length > 0) throw new Exception(errOut);
                }

                if (!Ammo.GlobalList.Exists(databasePath, caliber, out errOut))
                    Ammo.GlobalList.Add(databasePath, caliber, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }
            return bAns;
        }

        /// <summary>
        /// Updates the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="firearmId">The firearm identifier.</param>
        /// <param name="useNumberOnlyCatalog">if set to <c>true</c> [use number only catalog].</param>
        /// <param name="ownerId">The owner identifier.</param>
        /// <param name="manufactureId">The manufacture identifier.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="modelName">Name of the model.</param>
        /// <param name="modelId">The model identifier.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="firearmType">Type of the firearm.</param>
        /// <param name="caliber">The caliber.</param>
        /// <param name="finish">The finish.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="customId">The custom identifier.</param>
        /// <param name="natId">The nat identifier.</param>
        /// <param name="gripId">The grip identifier.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="height">The height.</param>
        /// <param name="stockType">Type of the stock.</param>
        /// <param name="barrelLength">Length of the barrel.</param>
        /// <param name="barrelWidth">Width of the barrel.</param>
        /// <param name="barrelHeight">Height of the barrel.</param>
        /// <param name="action">The action.</param>
        /// <param name="feedsystem">The feedsystem.</param>
        /// <param name="sights">The sights.</param>
        /// <param name="purchasedPrice">The purchased price.</param>
        /// <param name="purchasedFrom">The purchased from.</param>
        /// <param name="appraisedValue">The appraised value.</param>
        /// <param name="appraisalDate">The appraisal date.</param>
        /// <param name="appraisedBy">The appraised by.</param>
        /// <param name="insuredValue">The insured value.</param>
        /// <param name="storageLocation">The storage location.</param>
        /// <param name="conditionComments">The condition comments.</param>
        /// <param name="additionalNotes">The additional notes.</param>
        /// <param name="produced">The produced.</param>
        /// <param name="petLoads">The pet loads.</param>
        /// <param name="dtp">The DTP.</param>
        /// <param name="isCandR">if set to <c>true</c> [is cand r].</param>
        /// <param name="importer">The importer.</param>
        /// <param name="reManDt">The re man dt.</param>
        /// <param name="poi">The poi.</param>
        /// <param name="sgChoke">The sg choke.</param>
        /// <param name="isInBoundBook">if set to <c>true</c> [is in bound book].</param>
        /// <param name="twistRate">The twist rate.</param>
        /// <param name="lbsTrigger">The LBS trigger.</param>
        /// <param name="caliber3">The caliber3.</param>
        /// <param name="classification">The classification.</param>
        /// <param name="dateofCr">The dateof cr.</param>
        /// <param name="isClassIii">if set to <c>true</c> [is class iii].</param>
        /// <param name="isSold">if set to <c>true</c> [is sold].</param>
        /// <param name="dateTimeSold">The date time sold.</param>
        /// <param name="classIiiOwner">The class iii owner.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static bool Update(string databasePath,int firearmId, bool useNumberOnlyCatalog, long ownerId, long manufactureId, string fullName, string modelName, long modelId, string serialNumber,
            string firearmType, string caliber, string finish, string condition,
            string customId, long natId, long gripId, string weight, string height, string stockType,
            string barrelLength, string barrelWidth, string barrelHeight,
            string action, string feedsystem, string sights, string purchasedPrice, string purchasedFrom,
            string appraisedValue, string appraisalDate, string appraisedBy,
            string insuredValue, string storageLocation, string conditionComments, string additionalNotes,
            string produced, string petLoads, string dtp, bool isCandR, string importer, string reManDt, string poi,
            string sgChoke, bool isInBoundBook, string twistRate, string lbsTrigger, string caliber3, string classification, string dateofCr, bool isClassIii, 
            bool isSold,string dateTimeSold, string classIiiOwner, out string errOut)
        {
            errOut = "";
            bool bAns = false;
            try
            {
                int iBoundBook = isInBoundBook ? 1 : 0;
                int iIsClassIii = isClassIii ? 1 : 0;
                int iisCandR = isCandR ? 1 : 0;

                string sql =
                    $"UPDATE Gun_Collection set OID={ownerId},MID={manufactureId},FullName='{fullName}',ModelName='{modelName}',ModelID={modelId}" +
                    $",SerialNumber='{serialNumber}',Type='{firearmType}',Caliber='{caliber}',Finish='{finish}',Condition='{condition}'," +
                    $"CustomID={Helpers.SetCatalogInsType(useNumberOnlyCatalog, customId, out _)},NatID={natId},GripID={gripId}," +
                    $"Qty=1,Weight='{weight}',Height='{height}',StockType='{stockType}',BarrelLength='{barrelLength}',BarrelWidth='{barrelWidth}',BarrelHeight='{barrelHeight}'," +
                    $"Action='{action}',Feedsystem='{feedsystem}',Sights='{sights}',PurchasedPrice='{purchasedPrice}'," +
                    $"PurchasedFrom='{purchasedFrom}',AppraisedValue='{appraisedValue}',AppraisalDate='{appraisalDate}',AppraisedBy='{appraisedBy}'," +
                    $"InsuredValue='{insuredValue}',StorageLocation='{storageLocation}',ConditionComments='{conditionComments}'," +
                    $"AdditionalNotes='{additionalNotes}',Produced='{produced}',PetLoads='{petLoads}',dtp='{dtp}',IsCandR='{iisCandR}',Importer='{importer}'," +
                    $"ReManDT='{reManDt}',POI='{poi}',SGChoke='{sgChoke}',sync_lastupdate=Now(),IsInBoundBook={iBoundBook}," +
                    $"TwistRate='{twistRate}',lbs_trigger='{lbsTrigger}',Caliber3='{caliber3}',Classification='{classification}',DateofCR='{dateofCr}'," +
                    $"IsClassIII={iIsClassIii},ClassIII_owner='{classIiiOwner}'";
                if (isSold) sql += $", dtsold='{dateTimeSold}'";
                sql += $" where id={firearmId};";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (!bAns) throw new Exception(errOut);

                long barrelId = ExtraBarrelConvoKits.GetBarrelId(databasePath, firearmId, out errOut);
                bAns = ExtraBarrelConvoKits.Update(databasePath, firearmId,barrelId, modelName, caliber, finish, barrelLength, petLoads,
                    action, feedsystem, sights, "0.00", purchasedFrom, height, "Fixed Barrel", out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);

                if (purchasedFrom.Trim().Length > 0)
                {
                    if (!PeopleAndPlaces.Shops.Exists(databasePath, purchasedFrom, out errOut))
                    {
                        PeopleAndPlaces.Shops.Add(databasePath, purchasedFrom, out errOut);
                        if (errOut.Length > 0) throw new Exception(errOut);
                    }

                    long gunShopId = PeopleAndPlaces.Shops.GetId(databasePath, purchasedFrom, out errOut);
                    if (errOut.Length > 0) throw new Exception(errOut);
                    bAns = UpdateSellerId(databasePath, gunShopId, firearmId, out errOut);
                    if (errOut.Length > 0) throw new Exception(errOut);
                }

                if (!Ammo.GlobalList.Exists(databasePath, caliber, out errOut))
                    Ammo.GlobalList.Add(databasePath, caliber, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }
            return bAns;
        }

        /// <summary>
        /// Deletes the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="firearmId">The firearm identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Delete(string databasePath, long firearmId, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string sql = $"Delete from Gun_Collection where id={firearmId}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }
            return bAns;
        }
        /// <summary>
        /// Existses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="caliber">The caliber.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Exists(string databasePath, string fullName, string caliber, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Collection where FullName='{fullName}' and Caliber='{caliber}'";
                bAns = Database.DataExists(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Exists", e);
            }
            return bAns;
        }
        /// <summary>
        /// Existses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Exists(string databasePath, string fullName, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Collection where FullName='{fullName}'";
                bAns = Database.DataExists(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Exists", e);
            }
            return bAns;
        }
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="Exception"></exception>
        public static long GetId(string databasePath, string fullName, out string errOut)
        {
            long lAns = 0;
            errOut = "";
            try
            {
                List<GunCollectionList> lst = new List<GunCollectionList>();
                errOut = @"";
            
                string sql = $"select * from Gun_Collection where FullName='{fullName}'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut, databasePath);

                foreach (GunCollectionList g in lst)
                {
                    lAns = g.Id;
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetId", e);
            }

            return lAns;
        }
        /// <summary>
        /// Catalogs the exists details.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="customId">The custom identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        public static string CatalogExistsDetails(string databasePath, string customId, out string errOut,
            int gunId = 0)
        {
            string sAns = "";
            errOut = "";
            try
            {
                string sql = $"SELECT * from Gun_Collection where CustomID='{customId}'";
                if (gunId > 0) sql += $" and ID <> {gunId}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                List<GunCollectionList> lst = MyList(dt, out errOut, databasePath);
                sAns = $"The following firearms have been found {Environment.NewLine} with the same Catalog ID({customId}):{Environment.NewLine}";
                foreach (GunCollectionList l in lst)
                {
                    sAns += $"{l.FullName}{Environment.NewLine}";
                }

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("CatalogExistsDetails", e);
            }
            return sAns;
        }

        /// <summary>
        /// Gets the catalog next identifier number.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="Exception"></exception>
        public static long GetCatalogNextIdNumber(string databasePath, out string errOut)
        {
            long lAns = 0;
            errOut = "";
            try
            {
                string sql = "SELECT Max(CustomID) as CID from Gun_Collection";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);

                foreach (DataRow d in dt.Rows)
                {
                    lAns = Convert.ToInt32(d["cid"]);
                }

                lAns++;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetCatalogNextIDNumber", e);
            }
            return lAns;
        }

        /// <summary>
        /// Updates the default barrel in the main database collection table
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="barrelId">The barrel identifier.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool UpdateDefaultBarrel(string databasePath, long barrelId, long gunId, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string sql = $"UPDATE Gun_Collection set DBID={barrelId} where ID={gunId}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (!bAns) throw  new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("UpdateDefaultBarrel", e);
            }
            return bAns;
        }
        /// <summary>
        /// Updates the seller identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="sellerId">The seller identifier.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool UpdateSellerId(string databasePath, long sellerId, long gunId, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string sql = $"UPDATE Gun_Collection set SID={sellerId} where ID={gunId}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (!bAns) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("UpdateSellerId", e);
            }
            return bAns;
        }

        /// <summary>
        /// Gets the last identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long GetLastId(string databasePath, out string errOut)
        {
            long lAns = 0;
            errOut = "";
            try
            {
                string sql = "SELECT Top 1 ID from Gun_Collection order by ID DESC";
                lAns = Database.GetIDFromTableBasedOnTSQL(databasePath, sql, "ID", out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetLastId", e);
            }
            return lAns;
        }

        /// <summary>
        /// Updates the name of the shop for all the guns that was bought from it due to a name change
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="newName">The new name.</param>
        /// <param name="oldName">The old name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool UpdateShopName(string databasePath, string newName, string oldName, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"update gun_collection set PurchasedFrom='{newName}' where PurchasedFrom='{oldName}'";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("UpdateShopName", e);
            }
            return bAns;
        }
        /// <summary>
        /// Gets all the firearms in the database and their details
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;GunCollectionList&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        public static List<GunCollectionList> GetList(string databasePath,  out string errOut)
        {
            List<GunCollectionList> lst = new List<GunCollectionList>();
            errOut = @"";
            try
            {
                string sql = "select * from Gun_Collection";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut, databasePath);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetList", e);
            }
            return lst;
        }
        /// <summary>
        /// Gets a specfic firearm from the database
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;GunCollectionList&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        public static List<GunCollectionList> GetList(string databasePath, long id, out string errOut)
        {
            List<GunCollectionList> lst = new List<GunCollectionList>();
            errOut = @"";
            try
            {
                string sql = $"select * from Gun_Collection where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut, databasePath);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetList", e);
            }
            return lst;
        }
        /// <summary>
        /// Private class to sort the informatimon from a datatable into the Gun Collection List ype
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="dbPath"></param>
        /// <returns>List&lt;GunCollectionList&gt;.</returns>
        internal static List<GunCollectionList> MyList(DataTable dt, out string errOut, string dbPath = "")
        {
            List<GunCollectionList> lst = new List<GunCollectionList>();
            errOut = @"";
            try
            {
                BSOtherObjects obj = new BSOtherObjects();
                foreach (DataRow d in dt.Rows)
                {
                    int appriaserId = 0;
                    try
                    {
                        if (d["AppriaserID"] != null && d["AppriaserID"].ToString().Length > 0)
                        {
                            appriaserId = Convert.ToInt32(d["AppriaserID"]);
                        }
                    }
                    catch (Exception)
                    {
                        //Don't care default is 0
                    }

                    lst.Add(new GunCollectionList()
                    {
                        Id = Convert.ToInt32(d["id"] != DBNull.Value ? d["id"] : 0),
                        Oid = Convert.ToInt32(d["oid"] != DBNull.Value ? d["oid"] : 0),
                        Mid = Convert.ToInt32(d["mid"] != DBNull.Value ? d["mid"] : 0),
                        Manufacturer = dbPath.Length > 0 ? Manufacturers.GetName(dbPath, Convert.ToInt32(d["mid"] != DBNull.Value ? d["mid"] : 0), out _) : "",
                        FullName = d["FullName"] != DBNull.Value ? d["FullName"].ToString().Trim() : "",
                        ModelName = d["ModelName"] != DBNull.Value ? d["ModelName"].ToString().Trim() : "",
                        ModelId = Convert.ToInt32(d["ModelID"] != DBNull.Value ? d["ModelID"] : "0"),
                        SerialNumber = d["SerialNumber"] != DBNull.Value ? d["SerialNumber"].ToString().Trim() : "",
                        Type = d["Type"] != DBNull.Value ? d["Type"].ToString().Trim(): "",
                        Caliber = d["Caliber"] != DBNull.Value ? d["Caliber"].ToString().Trim() : "",
                        Caliber3 = d["Caliber3"] != DBNull.Value ? d["Caliber3"].ToString().Trim() : "",
                        PetLoads = d["PetLoads"] != DBNull.Value ? d["PetLoads"].ToString().Trim() : "",
                        Finish = d["Finish"] != DBNull.Value ? d["Finish"].ToString().Trim() : "",
                        FeedSystem = d["FeedSystem"] != DBNull.Value ? d["FeedSystem"].ToString().Trim() : "",
                        Condition = d["Condition"] != DBNull.Value ? d["Condition"].ToString().Trim() : "",
                        CustomId = d["CustomId"] != DBNull.Value ? d["CustomId"].ToString().Trim() : "",
                        NationalityId = Convert.ToInt32(d["NatId"].ToString()),
                        Nationality = dbPath.Length > 0 ? Nationality.GetName(dbPath, Convert.ToInt32(d["NatId"]), out _) : "",
                        BarrelLength = d["BarrelLength"] != DBNull.Value ? d["BarrelLength"].ToString().Trim() : "",
                        GripId = Convert.ToInt32(d["GripID"] != DBNull.Value ? d["GripID"].ToString():"0"),
                        GripType = dbPath.Length > 0 ? Grips.GetName(dbPath, Convert.ToInt32(d["GripID"].ToString()), out _) : "",
                        Qty = Convert.ToInt32(d["Qty"] != DBNull.Value ? d["Qty"].ToString(): "0"),
                        Weight = d["Weight"] != DBNull.Value ? d["Weight"].ToString().Trim() : "",
                        Height = d["Height"] != DBNull.Value ? d["Height"].ToString().Trim() : "",
                        StockType = d["StockType"] != DBNull.Value ? d["StockType"].ToString().Trim() : "",
                        BarrelHeight = d["BarrelHeight"] != DBNull.Value ? d["BarrelHeight"].ToString().Trim() : "",
                        BarrelWidth = d["BarrelWidth"] != DBNull.Value ? d["BarrelWidth"].ToString().Trim() : "",
                        Action = d["Action"] != DBNull.Value ? d["Action"].ToString().Trim() : "",
                        Sights = d["Sights"] != DBNull.Value ? d["Sights"].ToString().Trim() : "",
                        PurchasePrice = d["PurchasedPrice"] != DBNull.Value ? d["PurchasedPrice"].ToString().Trim() : "",
                        PurchaseFrom = d["PurchasedFrom"] != DBNull.Value ? d["PurchasedFrom"].ToString().Trim() : "",
                        AppriasedBy = d["AppraisedBy"] != DBNull.Value ? d["AppraisedBy"].ToString().Trim() : "",
                        AppriasedValue = d["AppraisedValue"] != DBNull.Value ? d["AppraisedValue"].ToString().Trim() : "",
                        AppriaserId = appriaserId,
                        AppraisalDate = d["AppraisalDate"] != DBNull.Value ? d["AppraisalDate"].ToString().Trim() : "",
                        InsuredValue = d["InsuredValue"] != DBNull.Value ? d["InsuredValue"].ToString().Trim() : "",
                        StorageLocation = d["StorageLocation"] != DBNull.Value ? d["StorageLocation"].ToString().Trim() : "",
                        ConditionComments = d["ConditionComments"] != DBNull.Value ? d["ConditionComments"].ToString().Trim() : "",
                        AdditionalNotes = d["AdditionalNotes"] != DBNull.Value ? d["AdditionalNotes"].ToString().Trim() : "",
                        HasAccessory = obj.ConvertIntToBool(Convert.ToInt32(d["HasAss"] != DBNull.Value ? d["HasAss"] : 0)),
                        DateProduced = d["Produced"] != DBNull.Value ? d["Produced"].ToString().Trim() : "",
                        DateTimeAddedInDb = d["dt"] != DBNull.Value ? d["dt"].ToString().Trim() : "",
                        ItemSold = obj.ConvertIntToBool(Convert.ToInt32(d["ItemSold"] != DBNull.Value ? d["ItemSold"].ToString() : "0")),
                        Sid = Convert.ToInt32(d["SID"] != DBNull.Value ? d["SID"].ToString() : "0"),
                        Bid = Convert.ToInt32(d["BID"] != DBNull.Value ? d["BID"].ToString() : "0"),
                        DateSold = d["dtSold"] != DBNull.Value ? d["dtSold"].ToString().Trim() : "",
                        IsCAndR = obj.ConvertIntToBool(Convert.ToInt32(d["IsCandR"] != DBNull.Value ? d["IsCandR"].ToString() : "0")),
                        DateTimeAdded = d["dtp"] != DBNull.Value ? d["dtp"].ToString().Trim() : "",
                        Importer = d["Importer"] != DBNull.Value ? d["Importer"].ToString().Trim() : "",
                        RemanufactureDate = d["ReManDT"] != DBNull.Value ? d["ReManDT"].ToString().Trim() : "",
                        Poi = d["POI"] != DBNull.Value ? d["POI"].ToString().Trim() : "",
                        HasMb = obj.ConvertIntToBool(Convert.ToInt32(d["HasMB"] != DBNull.Value ? d["HasMB"].ToString() : "0")),
                        DbId = Convert.ToInt32(d["DBID"] != DBNull.Value ? d["DBID"].ToString(): "0"),
                        ShotGunChoke = d["SGChoke"] != DBNull.Value ? d["SGChoke"].ToString().Trim(): "",
                        IsInBoundBook = obj.ConvertIntToBool(Convert.ToInt32(d["IsInBoundBook"] != DBNull.Value ? d["IsInBoundBook"].ToString(): "0")),
                        TwistRate = d["TwistRate"] != DBNull.Value ? d["TwistRate"].ToString().Trim(): "",
                        TriggerPullInPounds = d["lbs_trigger"] != DBNull.Value ? d["lbs_trigger"].ToString().Trim() : "",
                        Classification = d["Classification"] != DBNull.Value ? d["Classification"].ToString().Trim() : "",
                        DateOfCAndR = d["DateofCR"] != DBNull.Value ? d["DateofCR"].ToString().Trim() : "",
                        LastSyncDate = d["sync_lastupdate"] != DBNull.Value ? d["sync_lastupdate"].ToString().Trim() : "",
                        IsClass3Item = obj.ConvertIntToBool(Convert.ToInt32(d["IsClassIII"] != DBNull.Value ? d["IsClassIII"].ToString():"0")),
                        Class3Owner = d["ClassIII_owner"] != DBNull.Value ? d["ClassIII_owner"].ToString().Trim() : ""

                    });
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("MyList", e);
            }
            return lst;
        }
        /// <summary>
        /// Marks as sold.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="buyerId">The buyer identifier.</param>
        /// <param name="dateSold">The date sold.</param>
        /// <param name="salePrice">The sale price.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool MarkAsSold(string databasePath, long gunId, long buyerId, string dateSold, string salePrice,
            out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"UPDATE Gun_Collection set ItemSold=1,BID={buyerId},dtSold='{dateSold}',AppraisedValue='{salePrice}',sync_lastupdate=Now() where ID={gunId}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("MarkAsSold", e);
            }
            return bAns;
        }
    }
}
