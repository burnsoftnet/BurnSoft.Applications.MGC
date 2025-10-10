using BurnSoft.Applications.MGC.Types;
using System;
using System.Collections.Generic;

namespace BurnSoft.Applications.MGC.DebugHelpers
{
    /// <summary>
    /// Get the data from the lists and put them in a format that can be 
    /// printed or displated in abother windows for debugging and testing
    /// </summary>
    public class PrintListValues
    {
        /// <summary>
        /// Prints the gun collection list.
        /// </summary>
        /// <param name="value">The GunCollectionList container.</param>
        /// <returns>System.String.</returns>
        public static string PrintGunCollectionList(List<GunCollectionList> value)
        {
            string sAns = "";
            if (value.Count > 0)
            {
                foreach (GunCollectionList g in value)
                {
                    sAns += $"id : {g.Id}{Environment.NewLine}";
                    sAns += $"Full Name: {g.FullName}{Environment.NewLine}";
                    sAns += $"Owner id: {g.Oid}{Environment.NewLine}";
                    sAns += $"Manufacture Id: {g.Mid}{Environment.NewLine}";
                    sAns += $"ModelName: {g.ModelName}{Environment.NewLine}";
                    sAns += $"Model Id: {g.ModelId}{Environment.NewLine}";
                    sAns += $"SerialNumber: {g.SerialNumber}{Environment.NewLine}";
                    sAns += $"Type: {g.Type}{Environment.NewLine}";
                    sAns += $"Caliber: {g.Caliber}{Environment.NewLine}";
                    sAns += $"Caliber 2: {g.PetLoads}{Environment.NewLine}";
                    sAns += $"Caliber 3: {g.Caliber3}{Environment.NewLine}";
                    sAns += $"Feed System: {g.FeedSystem}{Environment.NewLine}";
                    sAns += $"Finish: {g.Finish}{Environment.NewLine}";
                    sAns += $"Condition: {g.Condition}{Environment.NewLine}";
                    sAns += $"CustomId: {g.CustomId}{Environment.NewLine}";
                    sAns += $"NationalityId: {g.NationalityId}{Environment.NewLine}";
                    sAns += $"BarrelLength: {g.BarrelLength}{Environment.NewLine}";
                    sAns += $"GripId: {g.GripId}{Environment.NewLine}";
                    sAns += $"Qty: {g.Qty}{Environment.NewLine}";
                    sAns += $"Weight: {g.Weight}{Environment.NewLine}";
                    sAns += $"Height: {g.Height}{Environment.NewLine}";
                    sAns += $"StockType: {g.StockType}{Environment.NewLine}";
                    sAns += $"BarrelHeight: {g.BarrelHeight}{Environment.NewLine}";
                    sAns += $"BarrelWidth: {g.BarrelWidth}{Environment.NewLine}";
                    sAns += $"Action: {g.Action}{Environment.NewLine}";
                    sAns += $"Sights: {g.Sights}{Environment.NewLine}";
                    sAns += $"PurchasePrice: {g.PurchasePrice}{Environment.NewLine}";
                    sAns += $"PurchaseFrom: {g.PurchaseFrom}{Environment.NewLine}";
                    sAns += $"AppriasedBy: {g.AppriasedBy}{Environment.NewLine}";
                    sAns += $"AppriasedValue: {g.AppriasedValue}{Environment.NewLine}";
                    sAns += $"AppriaserId: {g.AppriaserId}{Environment.NewLine}";
                    sAns += $"AppraisalDate: {g.AppraisalDate}{Environment.NewLine}";
                    sAns += $"InsuredValue: {g.InsuredValue}{Environment.NewLine}";
                    sAns += $"StorageLocation: {g.StorageLocation}{Environment.NewLine}";
                    sAns += $"ConditionComments: {g.ConditionComments}{Environment.NewLine}";
                    sAns += $"AdditionalNotes: {g.AdditionalNotes}{Environment.NewLine}";
                    sAns += $"HasAccessory: {g.HasAccessory}{Environment.NewLine}";
                    sAns += $"DateProduced: {g.DateProduced}{Environment.NewLine}";
                    sAns += $"DateTimeAddedInDb: {g.DateTimeAddedInDb}{Environment.NewLine}";
                    sAns += $"ItemSold: {g.ItemSold}{Environment.NewLine}";
                    sAns += $"Selled Id: {g.Sid}{Environment.NewLine}";
                    sAns += $"Buyer Id: {g.Bid}{Environment.NewLine}";
                    sAns += $"Date Sold: {g.DateSold}{Environment.NewLine}";
                    sAns += $"Is C&R Items: {g.IsCAndR}{Environment.NewLine}";
                    sAns += $"DateTimeAdded: {g.DateTimeAddedInDb}{Environment.NewLine}";
                    sAns += $"Importer: {g.Importer}{Environment.NewLine}";
                    sAns += $"RemanufactureDate: {g.RemanufactureDate}{Environment.NewLine}";
                    sAns += $"Poi: {g.Poi}{Environment.NewLine}";
                    sAns += $"HasMb : {g.HasMb}{Environment.NewLine}";
                    sAns += $"DbId: {g.DbId}{Environment.NewLine}";
                    sAns += $"ShotGunChoke: {g.ShotGunChoke}{Environment.NewLine}";
                    sAns += $"IsInBoundBook: {g.IsInBoundBook}{Environment.NewLine}";
                    sAns += $"TwistRate: {g.TwistRate}{Environment.NewLine}";
                    sAns += $"TriggerPullInPounds: {g.TriggerPullInPounds}{Environment.NewLine}";
                    sAns += $"Classification: {g.Classification}{Environment.NewLine}";
                    sAns += $"DateOfCAndR: {g.DateOfCAndR}{Environment.NewLine}";
                    sAns += $"LastSyncDate: {g.LastSyncDate}{Environment.NewLine}";
                    sAns += $"IsClass3Item: {g.IsClass3Item}{Environment.NewLine}";
                    sAns += $"Class3Owner: {g.Class3Owner}{Environment.NewLine}";
                    sAns += $"WaS Stolen: {g.WasStolen}{Environment.NewLine}";
                    sAns += $"Was Sold: {g.WasSold}{Environment.NewLine}";
                    sAns += $"Is Stogun: {g.IsShotGun}{Environment.NewLine}";
                    sAns += $"--------------------------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                }
            }
            return sAns;
        }
    }
}
