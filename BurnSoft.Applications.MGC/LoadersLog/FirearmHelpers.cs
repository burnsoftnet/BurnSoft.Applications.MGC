using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BurnSoft.Applications.MGC.LoadersLog
{
    /// <summary>
    /// Class FirearmHelpers Gun Collection Data Helper for the My Loaders Log Application
    /// </summary>
    public class FirearmHelpers
    {
        /// <summary>
        /// Counts the firearms.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int32.</returns>
        public static int CountFirearms(out string errOut)
        {
            string databasePath = RegistryHelpers.GetMGCPath(out errOut);
            string sql = "SELECT * from Gun_Collection where ItemSold=0";
            List<GunCollectionList> value = MyCollection.GetList(databasePath, sql, out errOut);
            return value.Count;
        }
        /// <summary>
        /// Gets the manufacturers identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long GetManufacturersId(string name, out string errOut) => 
            Manufacturers.GetId(RegistryHelpers.GetMGCPath(out _), name, out errOut);
        /// <summary>
        /// Gets the name of the manufacturers.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public static string GetManufacturersName(int id, out string errOut) => 
            Manufacturers.GetName(RegistryHelpers.GetMGCPath(out _), id, out errOut);
        /// <summary>
        /// Gets the model identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="manufacturerId">The manufacturer identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long GetModelId(string name, long manufacturerId, 
            out string errOut) => Models.GetId(RegistryHelpers.GetMGCPath(out _), 
                name, manufacturerId, out errOut, true);
        /// <summary>
        /// Gets the nationality identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long GetNationalityId(string name, out string errOut) => 
            Nationality.GetId(RegistryHelpers.GetMGCPath(out _), name, out errOut, true);
        /// <summary>
        /// Gets the grip identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long GetGripId(string name, out string errOut) => 
            Grips.GetId(RegistryHelpers.GetMGCPath(out _), name, out errOut, true);
        /// <summary>
        /// Gets the gun shop identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long GetGunShopId(string name, out string errOut) => 
            PeopleAndPlaces.Shops.GetId(RegistryHelpers.GetMGCPath(out _), name, out errOut, true);
        /// <summary>
        /// Gets the last firearm identifier.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long GetLastFirearmId(out string errOut) => 
            MyCollection.GetLastId(RegistryHelpers.GetMGCPath(out _), out errOut);
        /// <summary>
        /// Updates the type of the gun.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool UpdateGunType(string name, out string errOut) => 
            Firearms.GunTypes.Add(RegistryHelpers.GetMGCPath(out _), name, out errOut);
        /// <summary>
        /// Calibers the exists.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool CaliberExists(string name, out string errOut) =>
            Ammo.GlobalList.Exists(RegistryHelpers.GetMGCPath(out _), name, out errOut);
        /// <summary>
        /// Adds the firearm to MGC.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="caliber">The caliber.</param>
        /// <param name="barrel">The barrel.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="gunType">Type of the gun.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="MgcId">The MGC identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool AddFirearmToMGC(string fullName, string manufacturer, string model,
            string caliber, string barrel, string serialNumber, string gunType,
            out string errOut, long MgcId = 1) => MyCollection.QuickAdd(RegistryHelpers.GetMGCPath(out _), 
                fullName, manufacturer, model, caliber, barrel, serialNumber, gunType, out errOut, MgcId: MgcId);
        /// <summary>
        /// Ammoes the is already listed.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="name">The name.</param>
        /// <param name="cal">The cal.</param>
        /// <param name="grain">The grain.</param>
        /// <param name="jacket">The jacket.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="mid">The mid.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool AmmoIsAlreadyListed(string manufacturer, string name,
            string cal, string grain, string jacket, out long qty, out long mid, out string errOut) =>
            Ammo.Inventory.AmmoIsAlreadyListed(RegistryHelpers.GetMGCPath(out _), manufacturer, name, 
                cal, grain, jacket, out qty, out mid, out errOut);
    }
}
