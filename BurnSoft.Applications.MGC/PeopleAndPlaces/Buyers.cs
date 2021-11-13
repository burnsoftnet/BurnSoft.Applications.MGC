using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global

namespace BurnSoft.Applications.MGC.PeopleAndPlaces
{
    /// <summary>
    /// Class Buyers, which will handle the information relating to the Gun_Collection_SoldTo table in the database
    /// </summary>
    public class Buyers
    {
        #region "Exception Error Handling"

        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.PeopleAndPlaces.Buyers";

        /// <summary>
        /// Errors the message for regular Exceptions
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, Exception e) =>
            $"{ClassLocation}.{functionName} - {e.Message}";

        /// <summary>
        /// Errors the message for access violations
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, AccessViolationException e) =>
            $"{ClassLocation}.{functionName} - {e.Message}";

        /// <summary>
        /// Errors the message for invalid cast exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, InvalidCastException e) =>
            $"{ClassLocation}.{functionName} - {e.Message}";

        /// <summary>
        /// Errors the message argument exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentException e) =>
            $"{ClassLocation}.{functionName} - {e.Message}";

        /// <summary>
        /// Errors the message for argument null exception.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentNullException e) =>
            $"{ClassLocation}.{functionName} - {e.Message}";

        #endregion        
        /// <summary>
        /// Existses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="address">The address.</param>
        /// <param name="address2">The address2.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="dob">The dob.</param>
        /// <param name="dLic">The d lic.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Exists(string databasePath, string name,string address, string address2, string city, string state, string zipCode,string dob, string dLic, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"select * from Gun_Collection_SoldTo where name='{name}' and Address1='{address}' and Address2='{address2}' and City='{city}' and State='{state}' and ZipCode='{zipCode}' and DOB='{dob}' and DLic='{dLic}'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                bAns = dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Exists", e);
            }
            return bAns;
        }
        /// <summary>
        /// Stolens the buyer exists.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool StolenBuyerExists(string databasePath, string name,out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"select * from Gun_Collection_SoldTo where name='{name}'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                bAns = dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("StolenBuyerExists", e);
            }
            return bAns;
        }
        /// <summary>
        /// Get the Id of the buyer record
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="name"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static long GetId(string databasePath, string name, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                List<BuyersList> lst = Get(databasePath, name, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (BuyersList l in lst)
                {
                    lAns = l.Id;
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetID", e);
            }
            return lAns;
        }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        public static string GetName(string databasePath, int id, out string errOut)
        {
            string sAns = "";
            errOut = @"";
            try
            {
                List<BuyersList> lst = Get(databasePath, id, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (BuyersList l in lst)
                {
                    sAns = l.Name;
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetName", e);
            }
            return sAns;
        }
        /// <summary>Get information from the database based on the buyers ID</summary>
        /// <param name="databasePath"></param>
        /// <param name="id"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static List<BuyersList> Get(string databasePath, long id, out string errOut)
        {
            List<BuyersList> lst = new List<BuyersList>();
            try
            {
                string sql = $"select * from Gun_Collection_SoldTo where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = GetList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Get", e);
            }

            return lst;
        }
        /// <summary>
        /// Get the buyer information based on a specific name
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="name"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static List<BuyersList> Get(string databasePath, string name, out string errOut)
        {
            List<BuyersList> lst = new List<BuyersList>();
            try
            {
                string sql = $"select * from Gun_Collection_SoldTo where name='{name}'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = GetList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Get", e);
            }

            return lst;
        }
        /// <summary>
        /// Get all the Buyers List from the database
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static List<BuyersList> Get(string databasePath, out string errOut)
        {
            List<BuyersList> lst = new List<BuyersList>();
            try
            {
                string sql = "select * from Gun_Collection_SoldTo";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = GetList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Get", e);
            }

            return lst;
        }
        /// <summary>
        /// Internat list get function that will go through the datatable and put the values in the BuyersList
        /// One stop shopping for updates
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        internal static List<BuyersList> GetList(DataTable dt, out string errOut)
        {
            List<BuyersList> lst = new List<BuyersList>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new BuyersList()
                    {
                        //d[""] == DBNull.Value ? "N/A" : 
                        Id = Convert.ToInt32(d["id"]),
                        Name = d["Name"] == DBNull.Value ? "N/A" : d["Name"].ToString().Trim(),
                        Address1 = d["Address1"] == DBNull.Value ? "N/A" : d["Address1"].ToString().Trim(),
                        Address2 = d["Address2"] == DBNull.Value ? "N/A" : d["Address2"].ToString().Trim(),
                        City = d["City"] == DBNull.Value ? "N/A" : d["City"].ToString().Trim(),
                        State = d["State"] == DBNull.Value ? "N/A" : d["State"].ToString().Trim(),
                        ZipCode = d["ZipCode"] == DBNull.Value ? "N/A" : d["ZipCode"].ToString().Trim(),
                        Phone = d["Phone"] == DBNull.Value ? "N/A" : d["Phone"].ToString().Trim(),
                        Country = d["Country"] == DBNull.Value ? "N/A" : d["Country"].ToString().Trim(),
                        Email = d["eMail"] == DBNull.Value ? "N/A" : d["Email"].ToString().Trim(),
                        Lic = d["Lic"] == DBNull.Value ? "N/A" : d["Lic"].ToString().Trim(),
                        WebSite = d["WebSite"] == DBNull.Value ? "N/A" : d["WebSite"].ToString().Trim(),
                        Fax = d["Fax"] == DBNull.Value ? "N/A" : d["Fax"].ToString().Trim(),
                        Dob = d["DOB"] == DBNull.Value ? "N/A" : d["DOB"].ToString().Trim(),
                        Dlic = d["DLic"] == DBNull.Value ? "N/A" : d["DLic"].ToString().Trim(),
                        Resident = d["Resident"] == DBNull.Value ? "N/A" : d["Resident"].ToString().Trim()
                    });
                }

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetList", e);
            }
            return lst;
        }
        /// <summary>
        /// Add a new buyer and related information into the database
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="name"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="phone"></param>
        /// <param name="country"></param>
        /// <param name="eMail"></param>
        /// <param name="lic"></param>
        /// <param name="webSite"></param>
        /// <param name="fax"></param>
        /// <param name="dob"></param>
        /// <param name="dLic"></param>
        /// <param name="resident"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static bool Add(string databasePath, string name, string address1, string address2,
            string city, string state, string zipCode, string phone, string country, string eMail,
            string lic, string webSite, string fax, string dob, string dLic, string resident, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"INSERT INTO Gun_Collection_SoldTo(Name,Address1,Address2,City,State,Country,Phone" +
                             $",fax,website,email,lic,DOB,Dlic,Resident,ZipCode,sync_lastupdate) VALUES('{name}'," +
                             $"'{address1}','{address2}','{city}','{state}','{country}','{phone}','{fax}','{webSite}'" +
                             $",'{eMail}','{lic}','{dob}','{dLic}','{resident}','{zipCode}',Now())";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }
            return bAns;
        }
        /// <summary>
        /// Delete a buyer from the database
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="id"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static bool Delete(string databasePath, long id, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"DELETE from Gun_Collection_SoldTo where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }
            return bAns;
        }
        /// <summary>
        /// Update a buyers information in the database
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="phone"></param>
        /// <param name="country"></param>
        /// <param name="eMail"></param>
        /// <param name="lic"></param>
        /// <param name="webSite"></param>
        /// <param name="fax"></param>
        /// <param name="dob"></param>
        /// <param name="dLic"></param>
        /// <param name="resident"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static bool Update(string databasePath,long id, string name, string address1, string address2,
            string city, string state, string zipCode, string phone, string country, string eMail,
            string lic, string webSite, string fax, string dob, string dLic, string resident, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"Update Gun_Collection_SoldTo set Name='{name}',Address1='{address1}',Address2='{address2}',City='{city}',State='{state}',Country='{country}',Phone='{phone}'" +
                             $",fax='{fax}',website='{webSite}',email='{eMail}',lic='{lic}',DOB='{dob}',Dlic='{dLic}',Resident='{resident}',ZipCode='{zipCode}',sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }
            return bAns;
        }
        /// <summary>
        /// Firearms the bought.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="buyerId">The buyer identifier.</param>
        /// <param name="dateSold">The date sold.</param>
        /// <param name="salePrice">The sale price.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool FirearmBought(string databasePath, long gunId, long buyerId, string dateSold,
            string salePrice, out string errOut)
        {
            return MyCollection.MarkAsSold(databasePath, gunId, buyerId, dateSold, salePrice, out errOut);
        }
    }
}
