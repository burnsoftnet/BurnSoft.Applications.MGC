using BurnSoft.Applications.MGC.Ammo;
using BurnSoft.Applications.MGC.Global;
using System;
using System.Collections.Generic;

namespace BurnSoft.Applications.MGC.LoadersLog
{
    /// <summary>
    /// Class AmmoHelper mostly helps process the ammunition that is being exported from the My Loaders 
    /// Log Application to the My Gun Collection Ammo Inventory Table
    /// </summary>
    public class AmmoHelper
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.LoadersLog.AmmoHelper";
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
        /// Imports the ammo made.
        /// </summary>
        /// <param name="newAmmo">The new ammo.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool ImportAmmoMade(List<Types.Ammunition> newAmmo, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string databasePath = RegistryHelpers.GetMGCPath(out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (Types.Ammunition a in newAmmo)
                {
                    if (FirearmHelpers.AmmoIsAlreadyListed(a.Manufacturer, a.Name, a.Cal, a.Grain, a.Jacket,
                        out var qty, out var ammoId, out errOut))
                    {
                        if (!Inventory.UpdateQty(databasePath, ammoId, qty + a.Qty, out errOut)) throw new Exception(errOut);
                    } else
                    {
                        if (!Inventory.Add(databasePath, a.Manufacturer, a.Name, a.Cal, a.Grain, a.Jacket,
                            a.Qty, a.Dcal, a.Vel_n, out errOut)) throw new Exception(errOut);
                    }
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("ImportAmmoMade", e);
            }
            return bAns;
        }
        /// <summary>
        /// Addeds to ammo list.
        /// </summary>
        /// <param name="ammoList">The ammo list.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="name">The name.</param>
        /// <param name="caliber">The caliber.</param>
        /// <param name="grain">The grain.</param>
        /// <param name="jacket">The jacket.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="velocity">The velocity.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;Types.Ammunition&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        public static List<Types.Ammunition> AddedToAmmoList(List<Types.Ammunition> ammoList, string manufacturer, string name, string caliber, 
            string grain, string jacket, int qty, int velocity, out string errOut)
        {
            errOut = "";
            List<Types.Ammunition> lst = ammoList;
            try
            {
                int id = lst.Count + 1;
                double decimalGrain = Helpers.ConvertTextToNumber(grain, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                lst.Add(new Types.Ammunition
                {
                    Id = id,
                    Manufacturer = manufacturer,
                    Name = name,
                    Cal = caliber,
                    Grain = grain,
                    Dcal = decimalGrain,
                    Vel_n = velocity,
                    Vel_t = velocity.ToString(), 
                    Jacket = jacket, 
                    Qty = qty,
                    Sync_lastupdate = DateTime.Now.ToString(),
                });
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("AddedToAmmoList", e);
            }
            return lst;
        }
            
    }
}
