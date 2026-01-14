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
        public static string GunCollectionData(List<GunCollectionList> value)
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
                    sAns += $"Rating: {g.Rating}{Environment.NewLine}";
                    sAns += $"ToSell: {g.ToSell}{Environment.NewLine}";
                    sAns += $"GunSmithJob: {g.GunSmithJob}{Environment.NewLine}";
                    sAns += $"ForCollecting: {g.ForCollecting}{Environment.NewLine}";
                    sAns += $"--------------------------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                }
            }
            return sAns;
        }

        /// <summary>
        /// Prints the gun collection list.
        /// </summary>
        /// <param name="value">The GunCollectionFullList container.</param>
        /// <returns>System.String.</returns>
        public static string GunCollectionFullDetails(List<GunCollectionFullList> value)
        {
            string sAns = "";
            if (value.Count > 0)
            {
                foreach (GunCollectionFullList g in value)
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
                    sAns += $"Ratigin: {g.Rating}{Environment.NewLine}";
                    sAns += $"HasExtraBarrels: {g.HasExtraBarrels}{Environment.NewLine}";
                    sAns += $"BarrelSystemCount: {g.BarrelSystemCount}{Environment.NewLine}";
                    sAns += $"HasDocuments: {g.HasDocuments}{Environment.NewLine}";
                    sAns += $"LinkedDocuments: {g.LinkedDocuments}{Environment.NewLine}";
                    sAns += $"ToSell: {g.ToSell}{Environment.NewLine}";
                    sAns += $"GunSmithJob: {g.GunSmithJob}{Environment.NewLine}";
                    sAns += $"ForCollecting: {g.ForCollecting}{Environment.NewLine}";
                    sAns += $"-----------------Barrel System---------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += BarrelSystemsDetails(g.BarrelSystem);
                    sAns += $"-----------------Accessories---------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += AccessoriesDetails(g.Accessories);
                    sAns += $"-----------------Maintance Details---------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += GunMaintanceDetails(g.MaintanceDetails);
                    sAns += $"-----------------Gun Smith Work---------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += GunSmithWorkDoneDetails(g.GunSmithWork);
                    sAns += $"--------------------------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                }
            }
            return sAns;
        }

        /// <summary>
        /// Prints the barrel systems list.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string BarrelSystemsDetails(List<BarrelSystems> value)
        {
            string sAns = "";
            if (value.Count > 0)
            {
                foreach (BarrelSystems g in value)
                {
                    sAns += $"id : {g.Id}{Environment.NewLine}";
                    sAns += $"Full Name: {g.FullName}{Environment.NewLine}";
                    sAns += $"Finish: {g.Finish}{Environment.NewLine}";
                    sAns += $"BarrelLength: {g.BarrelLength}{Environment.NewLine}";
                    sAns += $"Height: {g.Height}{Environment.NewLine}";
                    sAns += $"Action: {g.Action}{Environment.NewLine}";
                    sAns += $"Sights: {g.Sights}{Environment.NewLine}";
                    sAns += $"PurchasePrice: {g.PurchasedPrice}{Environment.NewLine}";
                    sAns += $"PurchaseFrom: {g.PurchasedFrom}{Environment.NewLine}";
                    sAns += $"Petloads/Caliber2: {g.PetLoads}{Environment.NewLine}";
                    sAns += $"Gun Id: {g.GunId}{Environment.NewLine}";
                    sAns += $"Model Name: {g.ModelName}{Environment.NewLine}";
                    sAns += $"Caliber: {g.Caliber}{Environment.NewLine}";
                    sAns += $"Is Default: {g.IsDefault}{Environment.NewLine}";
                    sAns += $"Last Updated: {g.LastUpdated}{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += $"--------------------------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                }
            }
            return sAns;
        }

        /// <summary>
        /// Prints the accessories list.
        /// </summary>
        /// <param name="value">The AccessoriesList container value.</param>
        /// <returns>System.String.</returns>
        public static string AccessoriesDetails(List<AccessoriesList> value)
        {
            string sAns = "";
            if (value.Count > 0)
            {
                foreach (AccessoriesList v in value)
                {
                    sAns += $"id :{v.Id}{Environment.NewLine}";
                    sAns += $"gun id: {v.GunId}{Environment.NewLine}";
                    sAns += $"manufacturer: {v.Manufacturer}{Environment.NewLine}";
                    sAns += $"Model: {v.Model}{Environment.NewLine}";
                    sAns += $"Condition: {v.Condition}{Environment.NewLine}";
                    sAns += $"AppriasedValue: {v.AppriasedValue}{Environment.NewLine}";
                    sAns += $"CountInValue: {v.CountInValue}{Environment.NewLine}";
                    sAns += $"IsChoke: {v.IsChoke}{Environment.NewLine}";
                    sAns += $"LastSync: {v.LastSync}{Environment.NewLine}";
                    sAns += $"Notes: {v.Notes}{Environment.NewLine}";
                    sAns += $"PurchaseValue: {v.PurchaseValue}{Environment.NewLine}";
                    sAns += $"SerialNumber: {v.SerialNumber}{Environment.NewLine}";
                    sAns += $"Use: {v.Use}{Environment.NewLine}";
                    sAns += $"Is LInked: {v.IsLinked}{Environment.NewLine}";
                    sAns += $"Gen Accessory ID: {v.GALID}{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += $"--------------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                }
            }
            return sAns;
        }


        /// <summary>
        /// Prints the general accessories list.
        /// </summary>
        /// <param name="value">The AccessoriesList container value.</param>
        /// <returns>System.String.</returns>
        public static string GeneralAccessoriesDetails(List<GeneralAccessoriesList> value)
        {
            string sAns = "";
            if (value.Count > 0)
            {
                foreach (GeneralAccessoriesList v in value)
                {
                    sAns += $"id :{v.Id}{Environment.NewLine}";
                    sAns += $"manufacturer: {v.Manufacturer}{Environment.NewLine}";
                    sAns += $"Model: {v.Model}{Environment.NewLine}";
                    sAns += $"Condition: {v.Condition}{Environment.NewLine}";
                    sAns += $"AppriasedValue: {v.AppriasedValue}{Environment.NewLine}";
                    sAns += $"CountInValue: {v.CountInValue}{Environment.NewLine}";
                    sAns += $"IsChoke: {v.IsChoke}{Environment.NewLine}";
                    sAns += $"LastSync: {v.LastSync}{Environment.NewLine}";
                    sAns += $"Notes: {v.Notes}{Environment.NewLine}";
                    sAns += $"PurchaseValue: {v.PurchaseValue}{Environment.NewLine}";
                    sAns += $"SerialNumber: {v.SerialNumber}{Environment.NewLine}";
                    sAns += $"Use: {v.Use}{Environment.NewLine}";
                    sAns += $"FAID: {v.FAID}{Environment.NewLine}";
                    sAns += $"Is LInked: {v.IsLinked}{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += $"--------------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                }
            }
            return sAns;
        }

        /// <summary>
        /// Generals the accessories linkers details.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GeneralAccessoriesLinkersDetails(List<GeneralAccessoriesLinkers> value)
        {
            string sAns = "";
            if (value.Count > 0)
            {
                foreach (GeneralAccessoriesLinkers v in value)
                {
                    sAns += $"id :{v.Id}{Environment.NewLine}";
                    sAns += $"Gid: {v.Gid}{Environment.NewLine}";
                    sAns += $"Aid: {v.Aid}{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += $"--------------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                }
            }
            return sAns;
        }
        /// <summary>
        /// Prints the maintance details list.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GunMaintanceDetails(List<MaintanceDetailsList> value)
        {
            string sAns = "";
            if (value.Count > 0)
            {
                foreach (MaintanceDetailsList g in value)
                {
                    sAns += $"id : {g.Id}{Environment.NewLine}";
                    sAns += $"Plan Id: {g.PlanId}{Environment.NewLine}";
                    sAns += $"Name: {g.Name}{Environment.NewLine}";
                    sAns += $"Gun Id: {g.GunId}{Environment.NewLine}";
                    sAns += $"Operation Date: {g.OperationStartDate}{Environment.NewLine}";
                    sAns += $"Operation Due Date: {g.OperationDueDate}{Environment.NewLine}";
                    sAns += $"Notes: {g.Notes}{Environment.NewLine}";
                    sAns += $"Barrel System Id: {g.BarrelSystemId}{Environment.NewLine}";
                    sAns += $"Counts in Total: {g.DoesCount}{Environment.NewLine}";
                    sAns += $"Last Updated: {g.LastSync}{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += $"--------------------------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                }
            }
            return sAns;
        }

        /// <summary>
        /// Prints the gun smith work done list.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GunSmithWorkDoneDetails(List<GunSmithWorkDone> value)
        {
            string sAns = "";
            if (value.Count > 0)
            {
                foreach (GunSmithWorkDone g in value)
                {
                    sAns += $"id : {g.Id}{Environment.NewLine}";
                    sAns += $"Smith Name: {g.GunSmithName}{Environment.NewLine}";
                    sAns += $"Smith ID: {g.GunSmithId}{Environment.NewLine}";
                    sAns += $"Gun Id: {g.GunId}{Environment.NewLine}";
                    sAns += $"OrderDetails: {g.OrderDetails}{Environment.NewLine}";
                    sAns += $"Notes: {g.Notes}{Environment.NewLine}";
                    sAns += $"Return Date: {g.ReturnDate}{Environment.NewLine}";
                    sAns += $"Start Date: {g.StartDate}{Environment.NewLine}";
                    sAns += $"Last Updated: {g.LastSync}{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += $"--------------------------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                }
            }
            return sAns;
        }

        /// <summary>
        /// Prints the ammunition list.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string AmmunitionDetails(List<Ammunition> value)
        {
            string sAns = "";
            if (value.Count > 0)
            {
                foreach (Ammunition a in value)
                {
                    sAns = $"id: {a.Id}{Environment.NewLine}";
                    sAns = $"Manufacture: {a.Manufacturer}{Environment.NewLine}";
                    sAns = $"Name: {a.Name}{Environment.NewLine}";
                    sAns = $"Caliber: {a.Cal}{Environment.NewLine}";
                    sAns = $"Grain: {a.Grain}{Environment.NewLine}";
                    sAns = $"Jacket: {a.Jacket}{Environment.NewLine}";
                    sAns = $"Qty: {a.Qty}{Environment.NewLine}";
                    sAns = $"Number Version caliber: {a.Dcal}{Environment.NewLine}";
                    sAns = $"Velocity: {a.Vel_n}{Environment.NewLine}";
                    sAns = $"Last Updated: {a.Sync_lastupdate}{Environment.NewLine}";
                    sAns = $"{Environment.NewLine}";
                    sAns = $"----------------------------------{Environment.NewLine}";
                    sAns = $"{Environment.NewLine}";

                }
            }
            return sAns;
        }

        /// <summary>
        /// Prints the appraisers contact details list.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string AppraisersContactInfo(List<AppraisersContactDetails> value)
        {
            string sAns = "";
            if (value.Count > 0)
            {
                foreach (AppraisersContactDetails g in value)
                {
                    sAns += $"id: {g.Id}{Environment.NewLine}";
                    sAns += $"Name: {g.Name}{Environment.NewLine}";
                    sAns += $"Address: {g.Address1}{Environment.NewLine}";
                    sAns += $"Address2: {g.Address2}{Environment.NewLine}";
                    sAns += $"City: {g.City}{Environment.NewLine}";
                    sAns += $"State: {g.State}{Environment.NewLine}";
                    sAns += $"Zip Code: {g.ZipCode}{Environment.NewLine}";
                    sAns += $"Country: {g.Country}{Environment.NewLine}";
                    sAns += $"Phone: {g.Phone}{Environment.NewLine}";
                    sAns += $"Website: {g.WebSite}{Environment.NewLine}";
                    sAns += $"License: {g.Lic}{Environment.NewLine}";
                    sAns += $"Fax: {g.Fax}{Environment.NewLine}";
                    sAns += $"Still in Business: {g.StillInBusiness}{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += $"-------------------------------------{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                }
            }
            return sAns;
        }

        /// <summary>
        /// Prints the buyers list.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string BuyersListInfo(List<BuyersList> value)
        {
            string sAns = "";
            foreach (BuyersList v in value)
            {
                sAns += $"id: {v.Id}{Environment.NewLine}";
                sAns += $"Name: {v.Name}{Environment.NewLine}";
                sAns += $"Address1: {v.Address1}{Environment.NewLine}";
                sAns += $"Address2: {v.Address2}{Environment.NewLine}";
                sAns += $"City: {v.City}{Environment.NewLine}";
                sAns += $"State: {v.State}{Environment.NewLine}";
                sAns += $"ZipCode: {v.ZipCode}{Environment.NewLine}";
                sAns += $"Phone: {v.Phone}{Environment.NewLine}";
                sAns += $"Fax: {v.Fax}{Environment.NewLine}";
                sAns += $"email: {v.Email}{Environment.NewLine}";
                sAns += $"Driver Lic: {v.Dlic}{Environment.NewLine}";
                sAns += $"Date of Birth: {v.Dob}{Environment.NewLine}";
                sAns += $"Country: {v.Country}{Environment.NewLine}";
                sAns += $"Resident: {v.Resident}{Environment.NewLine}";
                sAns += $"License: {v.Lic}{Environment.NewLine}";
                sAns += $"{Environment.NewLine}";
                sAns += $"----------------------------------{Environment.NewLine}";
            }
            return sAns;
        }

        /// <summary>
        /// Prints the list for the PictureDetails list.
        /// </summary>
        /// <param name="p">The PictureDetails List</param>
        public static string PictureDetailsList(List<PictureDetails> p)
        {
            string sAns = "";
            if (p.Count > 0)
            {
                foreach (PictureDetails d in p)
                {
                    sAns += $"{Environment.NewLine}";
                    sAns += $"id: {d.Id}{Environment.NewLine}";
                    sAns += $"isMain: {d.IsMain}{Environment.NewLine}";
                    sAns += $"Last Sync: {d.LastSyncDate}{Environment.NewLine}";
                    sAns += $"Picture: {d.Picture}{Environment.NewLine}";
                    sAns += $"Thumb: {d.Thumb}{Environment.NewLine}";
                    sAns += $"Display Name: {d.PictureDisplayName}{Environment.NewLine}";
                    sAns += $"Display Note: {d.PictureNotes}{Environment.NewLine}";
                    sAns += $"Pic Stream: {d.PictureMemoryStream}{Environment.NewLine}";
                    sAns += $"Thumb Stream: {d.ThumbMemoryStream}{Environment.NewLine}";
                    sAns += $"PicOrder: {d.PicOrder}{Environment.NewLine}";
                    sAns += $"{Environment.NewLine}";
                    sAns += $"----------------------------------------{Environment.NewLine}";
                }
            }
            else
            {
                sAns += "NO DATA IN LIST!";
            }
            return sAns;
        }
        /// <summary>
        /// Prints the Wish Listlist.
        /// </summary>
        /// <param name="value">The value.</param>
        public static string WishListList(List<WishlistList> value)
        {
            string sAns = "";
            if (value.Count > 0)
            {
                foreach (WishlistList v in value)
                {
                    sAns += $"id :{v.Id}";
                    sAns += $"manufacturer: {v.Manufacturer}";
                    sAns += $"Model: {v.Model}";
                    sAns += $"Qty: {v.Qty}";
                    sAns += $"Value: {v.Value}";
                    sAns += $"LastSync: {v.LastSync}";
                    sAns += $"Notes: {v.Notes}";
                    sAns += "";
                    sAns += "--------------------------";
                    sAns += "";
                }
            }
            else
            {
                sAns += "NO DATA IN LIST!";
            }
            return sAns;
        }
    }
}
