using BurnSoft.Applications.MGC.AutoFill;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Applications.MGC.Other
{
    /// <summary>
    /// General Class to handline the linking between the firearm and the General Accessories.  
    /// We are keeping the Firearm accessories the way it is because there are some things that will
    /// never be put into general, while others can be. 
    /// </summary>
    public class GeneralAccessoriesLinking
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Other.GeneralAccessoriesLinking";
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
        /// Attaches The general accessory to the select firearm accessories and adds it to the link list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool AttachToFirearm(string databasePath, int id, long gunId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"INSERT INTO General_Accessories_Link(GID, AID) Values({gunId},{id})";
                if (!Database.Execute(databasePath, sql, out errOut)) throw new Exception(errOut);
                List<GeneralAccessoriesList> lst = GeneralAccessories.Lists(databasePath, id, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (GeneralAccessoriesList l in lst)
                {
                    if (!Accessories.Add(databasePath, gunId, l.Manufacturer, l.Model, l.SerialNumber, l.Condition, 
                        l.Notes, l.Use, Convert.ToDouble(l.PurchaseValue), Convert.ToDouble(l.AppriasedValue), 
                        l.CountInValue, l.IsChoke, id, out errOut)) throw new Exception(errOut);
                }
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("AttachToFirearm", e);
            }

            return bAns;
        }
        /// <summary>
        /// Adds the specified linker id's to the linker table
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The general accessory identifier.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Add(string databasePath, int id, long gunId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"INSERT INTO General_Accessories_Link(GID, AID) Values({gunId},{id})";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }

            return bAns;
        }
        /// <summary>
        /// Deletes the specified Link by id from the tabl
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="linkId">The link identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Delete(string databasePath, int linkId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"DELETE from General_Accessories_Link where id={linkId}";
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
        /// Deletes the specified link(s) from the table based on the accessory id and gun id.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="accessory_id">The accessory identifier.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Delete(string databasePath, int accessory_id, long gunId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"DELETE from General_Accessories_Link where aid={accessory_id} and gid={gunId}";
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
        /// Deletes the specified links from the table based on the provided list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="deleteList">The delete list.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Delete(string databasePath, List<GeneralAccessoriesLinkers> deleteList, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                foreach(GeneralAccessoriesLinkers a in deleteList)
                {
                    int id = a.Id;
                    if (!Delete(databasePath, id, out errOut)) throw new Exception(errOut);
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }

            return bAns;
        }
        /// <summary>
        /// Updates the firearm accessory with the details that was updated in the general accessories table..
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool UpdateFirearm(string databasePath, int id, long gunId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                List<GeneralAccessoriesList> lst = GeneralAccessories.Lists(databasePath, id, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (GeneralAccessoriesList l in lst)
                {
                    long gaid = Accessories.GetId(databasePath, gunId, l.Manufacturer, l.Model, l.SerialNumber, l.Condition,
                        l.Notes, l.Use, Convert.ToDouble(l.PurchaseValue), Convert.ToDouble(l.AppriasedValue), l.CountInValue,
                        l.IsChoke, id, out errOut);
                    if (errOut.Length > 0) throw new Exception(errOut);
                    if (!Accessories.Update(databasePath, gaid, gunId, l.Manufacturer, l.Model, l.SerialNumber, l.Condition,
                        l.Notes, l.Use, Convert.ToDouble(l.PurchaseValue), Convert.ToDouble(l.AppriasedValue),
                        l.CountInValue, l.IsChoke, id, out errOut)) throw new Exception(errOut);
                }
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("UpdateFirearm", e);
            }

            return bAns;
        }
        #region "Data Lists"
        /// <summary>
        /// Send a datable to get that converted into an GeneralAcceeories List type
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns>GeneralAccessoriesLinkers list format</returns>
        private static List<GeneralAccessoriesLinkers> MyList(DataTable dt, out string errOut)
        {
            //General_Accessories_Link
            List<GeneralAccessoriesLinkers> lst = new List<GeneralAccessoriesLinkers>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new GeneralAccessoriesLinkers()
                    {
                        Id = Convert.ToInt32(d["id"] != DBNull.Value ? d["id"] : 0),
                        Gid = Convert.ToInt32(d["gid"] != DBNull.Value ? d["gid"] : 0),
                        Aid = Convert.ToInt32(d["aid"] != DBNull.Value ? d["aid"] : 0),
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
        /// Return a List of all the general accessories linkers based
        /// </summary>
        /// <param name="databasePath">The Database Path</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        public static List<GeneralAccessoriesLinkers> Lists(string databasePath, out string errOut)
        {
            List<GeneralAccessoriesLinkers> lst = new List<GeneralAccessoriesLinkers>();
            try
            {
                string sql = $"select * from General_Accessories_Link";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("List", e);
            }

            return lst;
        }

        /// <summary>
        /// Return a List of the general accessories linkers based accessory id
        /// </summary>
        /// <param name="databasePath">The Database Path</param>
        /// <param name="accessoryId">The id of the Accessory that you want to work with</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        public static List<GeneralAccessoriesLinkers> Lists(string databasePath, int accessoryId, out string errOut)
        {
            List<GeneralAccessoriesLinkers> lst = new List<GeneralAccessoriesLinkers>();
            try
            {
                string sql = $"select * from General_Accessories_Link where aid={accessoryId}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("List", e);
            }

            return lst;
        }

        /// <summary>
        /// Return a List of the general accessories linkers based accessory and firearm id
        /// </summary>
        /// <param name="databasePath">The Database Path</param>
        /// <param name="gunId">the firearm ID</param>
        /// <param name="accessoryId">The id of the Accessory that you want to work with</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        public static List<GeneralAccessoriesLinkers> Lists(string databasePath, long gunId, int accessoryId, out string errOut)
        {
            List<GeneralAccessoriesLinkers> lst = new List<GeneralAccessoriesLinkers>();
            try
            {
                string sql = $"select * from General_Accessories_Link where aid={accessoryId} and=gid{gunId}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("List", e);
            }

            return lst;
        }
        #endregion

        /// <summary>
        /// Gets the identifier for the general accessory attached to the firearm in the linker table
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="galId">The general accessory identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64. Linker table ID</returns>
        /// <exception cref="System.Exception"></exception>
        public static long GetId(string databasePath, long gunId, int galId, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                List<GeneralAccessoriesLinkers> lst = Lists(databasePath, gunId, galId, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (GeneralAccessoriesLinkers a in lst)
                {
                    lAns = a.Id;
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetId", e);
            }

            return lAns;
        }

        /// <summary>
        /// Check to see if an accessory and gun id already exist in the linkers table.
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="gunId"></param>
        /// <param name="galid"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static bool Exists(string databasePath, long gunId, int galid, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                List<GeneralAccessoriesLinkers> lst = Lists(databasePath, gunId, galid, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                bAns = lst.Any(a => a.Gid.Equals(gunId) && a.Aid.Equals(galid));

            }
            catch (Exception e)
            {
                ErrorMessage("Exists", e);
            }
            return bAns;
        }
    }
}
