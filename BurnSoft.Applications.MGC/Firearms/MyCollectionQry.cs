using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Universal;

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class MyCollection, The majority of this class will hand the data from the qryGunCollectionDetails qurery table.
    /// </summary>
    public class MyCollectionQry
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Firearms.MyCollectionQry";
        /// <summary>
        /// Errors the message for regular Exceptions
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, Exception e) => $"{ClassLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for access violations
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, AccessViolationException e) => $"{ClassLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for invalid cast exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, InvalidCastException e) => $"{ClassLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message argument exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentException e) => $"{ClassLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for argument null exception.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentNullException e) => $"{ClassLocation}.{functionName} - {e.Message}";
        #endregion                
        /// <summary>
        /// Searches the list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="column">The column.</param>
        /// <param name="lookFor">The look for.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;GunCollectionList&gt;.</returns>
        /// <exception cref="Exception"></exception>
        public static List<GunCollectionList> SearchList(string databasePath, string column, string lookFor, out string errOut)
        {
            List<GunCollectionList> lst = new List<GunCollectionList>();
            errOut = @"";
            try
            {
                string sql = $"SELECT ID,FullName as [Full Name],Brand,ModelName as [Model],SerialNumber as [Serial No],Type,Caliber from qryGunCollectionDetails where {column} like'%{lookFor}%'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SearchList", e);
            }
            return lst;
        }
        /// <summary>
        /// Private class to sort the informatimon from a datatable into the Gun Collection List ype
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;GunCollectionList&gt;.</returns>
        private static List<GunCollectionList> MyList(DataTable dt, out string errOut)
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
    }
}
