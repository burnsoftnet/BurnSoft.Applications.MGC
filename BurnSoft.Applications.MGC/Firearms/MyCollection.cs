using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Universal;
// ReSharper disable UnusedMember.Local

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
        
        public static bool Add(string databasePath,long ownerId, long manufactureId, string fullName, string modelName, long modelId, string serialNumber,
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
                int iIsClassIII = isClassIii ? 1 : 0;
                int iisCandR = isCandR ? 1 : 0;

                string sql = $"INSERT INTO Gun_Collection(OID,MID,FullName,ModelName,ModelID,SerialNumber,Type,Caliber,Finish,Condition," +
                "CustomID,NatID,GripID,Qty,Weight,Height,StockType,BarrelLength,BarrelWidth,BarrelHeight," +
                "Action,Feedsystem,Sights,PurchasedPrice,PurchasedFrom,AppraisedValue,AppraisalDate,AppraisedBy," +
                "InsuredValue,StorageLocation,ConditionComments,AdditionalNotes,Produced,PetLoads,dtp,IsCandR,Importer," +
                "ReManDT,POI,SGChoke,sync_lastupdate,HasMB,DBID,IsInBoundBook,TwistRate,lbs_trigger,Caliber3,Classification,DateofCR," +
                $"ItemSold,BID,IsClassIII,ClassIII_owner) VALUES({ownerId},{manufactureId},'{fullName}','{modelName}', {modelId}, '{serialNumber}'," +
                $"'{firearmType}','{caliber}','{finish}','{condition}','{customId}',{natId},{gripId},1,'{weight}','{height}','{stockType}','{barrelLength}'" +
                $",'{barrelWidth}','{barrelHeight}','{action}','{feedsystem}','{sights}','{purchasedPrice}','{purchasedFrom}','{appraisedValue}'," +
                $"'{appraisalDate}','{appraisedBy}','{insuredValue}','{storageLocation}','{conditionComments}','{additionalNotes}','{produced}'," +
                $"'{petLoads}','{dtp}','{iisCandR}','{importer}','{reManDt}','{poi}','{sgChoke}',Now(),0,0,{iBoundBook},'{twistRate}','{lbsTrigger}'" +
                $",'{caliber3}','{classification}','{dateofCr}',0,2,{iIsClassIII},'{classIiiOwner}')";
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
                string sql = $"select * from Gun_Collection";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
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
                lst = MyList(dt, out errOut);
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
        /// <returns>List&lt;GunCollectionList&gt;.</returns>
        internal static List<GunCollectionList> MyList(DataTable dt, out string errOut)
        {
            List<GunCollectionList> lst = new List<GunCollectionList>();
            errOut = @"";
            try
            {
                BSOtherObjects obj = new BSOtherObjects();
                foreach (DataRow d in dt.Rows)
                {
                    int appriaserId = 0;
                    if (d["AppriaserID"] != null && d["AppriaserID"].ToString().Length > 0)
                    {
                        appriaserId = Convert.ToInt32(d["AppriaserID"]);
                    }
                    
                    lst.Add(new GunCollectionList()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        Oid = Convert.ToInt32(d["oid"]),
                        Mid = Convert.ToInt32(d["mid"]),
                        FullName = d["FullName"].ToString(),
                        ModelName = d["ModelName"].ToString(),
                        ModelId = Convert.ToInt32(d["ModelID"]),
                        SerialNumber = d["SerialNumber"].ToString(),
                        Type = d["Type"].ToString(),
                        Caliber = d["Caliber"].ToString(),
                        Caliber3 = d["Caliber3"].ToString(),
                        PetLoads = d["PetLoads"].ToString(),
                        Finish = d["Finish"].ToString(),
                        FeedSystem = d["FeedSystem"].ToString(),
                        Condition = d["Condition"].ToString(),
                        CustomId = d["CustomId"].ToString(),
                        NationalityId = Convert.ToInt32(d["NatId"].ToString()),
                        BarrelLength = d["BarrelLength"].ToString(),
                        GripId = Convert.ToInt32(d["GripID"].ToString()),
                        Qty = Convert.ToInt32(d["Qty"].ToString()),
                        Weight = d["Weight"].ToString(),
                        Height = d["Height"].ToString(),
                        StockType = d["StockType"].ToString(),
                        BarrelHeight = d["BarrelHeight"].ToString(),
                        BarrelWidth = d["BarrelWidth"].ToString(),
                        Action = d["Action"].ToString(),
                        Sights = d["Sights"].ToString(),
                        PurchasePrice = d["PurchasedPrice"].ToString(),
                        PurchaseFrom = d["PurchasedFrom"].ToString(),
                        AppriasedBy = d["AppraisedBy"].ToString(),
                        AppriasedValue = d["AppraisedValue"].ToString(),
                        AppriaserId = appriaserId,
                        AppraisalDate = d["AppraisalDate"].ToString(),
                        InsuredValue = d["InsuredValue"].ToString(),
                        StorageLocation = d["StorageLocation"].ToString(),
                        ConditionComments = d["ConditionComments"].ToString(),
                        AdditionalNotes = d["AdditionalNotes"].ToString(),
                        HasAccessory = obj.ConvertIntToBool(Convert.ToInt32(d["HasAss"])),
                        DateProduced = d["Produced"].ToString(),
                        DateTimeAddedInDb = d["dt"].ToString(),
                        ItemSold = obj.ConvertIntToBool(Convert.ToInt32(d["ItemSold"].ToString())),
                        Sid = Convert.ToInt32(d["SID"].ToString()),
                        Bid = Convert.ToInt32(d["BID"].ToString()),
                        DateSold = d["dtSold"].ToString(),
                        IsCAndR = obj.ConvertIntToBool(Convert.ToInt32(d["IsCandR"].ToString())),
                        DateTimeAdded = d["dtp"].ToString(),
                        Importer = d["Importer"].ToString(),
                        RemanufactureDate = d["ReManDT"].ToString(),
                        Poi = d["POI"].ToString(),
                        HasMb = obj.ConvertIntToBool(Convert.ToInt32(d["HasMB"].ToString())),
                        DbId = Convert.ToInt32(d["DBID"].ToString()),
                        ShotGunChoke = d["SGChoke"].ToString(),
                        IsInBoundBook = obj.ConvertIntToBool(Convert.ToInt32(d["IsInBoundBook"].ToString())),
                        TwistRate = d["TwistRate"].ToString(),
                        TriggerPullInPounds = d["lbs_trigger"].ToString(),
                        Classification = d["Classification"].ToString(),
                        DateOfCAndR = d["DateofCR"].ToString(),
                        LastSyncDate = d["sync_lastupdate"].ToString(),
                        IsClass3Item = obj.ConvertIntToBool(Convert.ToInt32(d["IsClassIII"].ToString())),
                        Class3Owner = d["ClassIII_owner"].ToString()

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
