using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Applications.MGC.DebugHelpers
{
    /// <summary>
    /// The Verify Data Class will get the data returned to help validate that 
    /// some or all values are not a default, null or zero.
    /// </summary>
    public class VerifyData
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.DebugHelpers.VerifyData";
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
        private static bool IsNotEmptyOrNull(string value)
        {
            if (string.IsNullOrEmpty(value)) 
            { 
                return false; 
            } else { 
                return true; 
            }
        }

        private static bool IsNotEmptyOrNull(int? value)
        {
            if (value == null)
            {
                return false;
            }
            else
            {
                if (value == 0)
                {
                    return false;
                } else
                {
                    return true;
                }
            }
        }
        public static bool FirearmDetailsById(string databasePath, long id, out string errOut)
        {
            bool bAns =false;
            errOut = "";
            try
            {
                List<GunCollectionFullList> lst = MyCollection.GetFullList(databasePath, id, out errOut);
                if (errOut.Length > 0)  throw new Exception(errOut);
                foreach (GunCollectionFullList l in lst)
                {
                    if (!IsNotEmptyOrNull(l.FullName))) throw new Exception("Full Name is Empty");
                    if (!IsNotEmptyOrNull(l.ModelId)) throw new Exception("Model ID is 0 or Exmpty");

                    //sAns += $"id : {g.Id}{Environment.NewLine}";
                    //sAns += $"Full Name: {g.FullName}{Environment.NewLine}";
                    //sAns += $"Owner id: {g.Oid}{Environment.NewLine}";
                    //sAns += $"Manufacture Id: {g.Mid}{Environment.NewLine}";
                    //sAns += $"ModelName: {g.ModelName}{Environment.NewLine}";
                    //sAns += $"Model Id: {g.ModelId}{Environment.NewLine}";
                    //sAns += $"SerialNumber: {g.SerialNumber}{Environment.NewLine}";
                    //sAns += $"Type: {g.Type}{Environment.NewLine}";
                    //sAns += $"Caliber: {g.Caliber}{Environment.NewLine}";
                    //sAns += $"Caliber 2: {g.PetLoads}{Environment.NewLine}";
                    //sAns += $"Caliber 3: {g.Caliber3}{Environment.NewLine}";
                    //sAns += $"Feed System: {g.FeedSystem}{Environment.NewLine}";
                    //sAns += $"Finish: {g.Finish}{Environment.NewLine}";
                    //sAns += $"Condition: {g.Condition}{Environment.NewLine}";
                    //sAns += $"CustomId: {g.CustomId}{Environment.NewLine}";
                    //sAns += $"NationalityId: {g.NationalityId}{Environment.NewLine}";
                    //sAns += $"BarrelLength: {g.BarrelLength}{Environment.NewLine}";
                    //sAns += $"GripId: {g.GripId}{Environment.NewLine}";
                    //sAns += $"Qty: {g.Qty}{Environment.NewLine}";
                    //sAns += $"Weight: {g.Weight}{Environment.NewLine}";
                    //sAns += $"Height: {g.Height}{Environment.NewLine}";
                    //sAns += $"StockType: {g.StockType}{Environment.NewLine}";
                    //sAns += $"BarrelHeight: {g.BarrelHeight}{Environment.NewLine}";
                    //sAns += $"BarrelWidth: {g.BarrelWidth}{Environment.NewLine}";
                    //sAns += $"Action: {g.Action}{Environment.NewLine}";
                    //sAns += $"Sights: {g.Sights}{Environment.NewLine}";
                    //sAns += $"PurchasePrice: {g.PurchasePrice}{Environment.NewLine}";
                    //sAns += $"PurchaseFrom: {g.PurchaseFrom}{Environment.NewLine}";
                    //sAns += $"AppriasedBy: {g.AppriasedBy}{Environment.NewLine}";
                    //sAns += $"AppriasedValue: {g.AppriasedValue}{Environment.NewLine}";
                    //sAns += $"AppriaserId: {g.AppriaserId}{Environment.NewLine}";
                    //sAns += $"AppraisalDate: {g.AppraisalDate}{Environment.NewLine}";
                    //sAns += $"InsuredValue: {g.InsuredValue}{Environment.NewLine}";
                    //sAns += $"StorageLocation: {g.StorageLocation}{Environment.NewLine}";
                    //sAns += $"ConditionComments: {g.ConditionComments}{Environment.NewLine}";
                    //sAns += $"AdditionalNotes: {g.AdditionalNotes}{Environment.NewLine}";
                    //sAns += $"HasAccessory: {g.HasAccessory}{Environment.NewLine}";
                    //sAns += $"DateProduced: {g.DateProduced}{Environment.NewLine}";
                    //sAns += $"DateTimeAddedInDb: {g.DateTimeAddedInDb}{Environment.NewLine}";
                    //sAns += $"ItemSold: {g.ItemSold}{Environment.NewLine}";
                    //sAns += $"Selled Id: {g.Sid}{Environment.NewLine}";
                    //sAns += $"Buyer Id: {g.Bid}{Environment.NewLine}";
                    //sAns += $"Date Sold: {g.DateSold}{Environment.NewLine}";
                    //sAns += $"Is C&R Items: {g.IsCAndR}{Environment.NewLine}";
                    //sAns += $"DateTimeAdded: {g.DateTimeAddedInDb}{Environment.NewLine}";
                    //sAns += $"Importer: {g.Importer}{Environment.NewLine}";
                    //sAns += $"RemanufactureDate: {g.RemanufactureDate}{Environment.NewLine}";
                    //sAns += $"Poi: {g.Poi}{Environment.NewLine}";
                    //sAns += $"HasMb : {g.HasMb}{Environment.NewLine}";
                    //sAns += $"DbId: {g.DbId}{Environment.NewLine}";
                    //sAns += $"ShotGunChoke: {g.ShotGunChoke}{Environment.NewLine}";
                    //sAns += $"IsInBoundBook: {g.IsInBoundBook}{Environment.NewLine}";
                    //sAns += $"TwistRate: {g.TwistRate}{Environment.NewLine}";
                    //sAns += $"TriggerPullInPounds: {g.TriggerPullInPounds}{Environment.NewLine}";
                    //sAns += $"Classification: {g.Classification}{Environment.NewLine}";
                    //sAns += $"DateOfCAndR: {g.DateOfCAndR}{Environment.NewLine}";
                    //sAns += $"LastSyncDate: {g.LastSyncDate}{Environment.NewLine}";
                    //sAns += $"IsClass3Item: {g.IsClass3Item}{Environment.NewLine}";
                    //sAns += $"Class3Owner: {g.Class3Owner}{Environment.NewLine}";
                    //sAns += $"WaS Stolen: {g.WasStolen}{Environment.NewLine}";
                    //sAns += $"Was Sold: {g.WasSold}{Environment.NewLine}";
                    //sAns += $"Is Stogun: {g.IsShotGun}{Environment.NewLine}";
                    //sAns += $"HasExtraBarrels: {g.HasExtraBarrels}{Environment.NewLine}";
                    //sAns += $"BarrelSystemCount: {g.BarrelSystemCount}{Environment.NewLine}";
                    //sAns += $"HasDocuments: {g.HasDocuments}{Environment.NewLine}";
                    //sAns += $"LinkedDocuments: {g.LinkedDocuments}{Environment.NewLine}";
                    //sAns += $"-----------------Barrel System---------------------{Environment.NewLine}";
                    //sAns += $"{Environment.NewLine}";
                    //sAns += BarrelSystemsDetails(g.BarrelSystem);
                    //sAns += $"-----------------Accessories---------------------{Environment.NewLine}";
                    //sAns += $"{Environment.NewLine}";
                    //sAns += AccessoriesDetails(g.Accessories);
                    //sAns += $"-----------------Maintance Details---------------------{Environment.NewLine}";
                    //sAns += $"{Environment.NewLine}";
                    //sAns += GunMaintanceDetails(g.MaintanceDetails);
                    //sAns += $"-----------------Gun Smith Work---------------------{Environment.NewLine}";
                    //sAns += $"{Environment.NewLine}";
                    //sAns += GunSmithWorkDoneDetails(g.GunSmithWork);
                    //sAns += $"--------------------------------------{Environment.NewLine}";
                    //sAns += $"{Environment.NewLine}";
                }
                bAns = true;
            }
            catch (Exception e)
            {
                ErrorMessage("FirearmDetails", e);
            }

            return bAns;
        }
    }
}
