using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurnSoft.Applications.MGC.Types;

namespace BurnSoft.Applications.MGC.PeopleAndPlaces
{
    /// <summary>
    /// Class Appraisers will handle the general functions needed to manage the Appraisers table
    /// </summary>
    public class Appraisers
    {

        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "";
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
        //End Snippet        
        /// <summary>
        /// Adds the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Add(string databasePath, string name, out string errOut)
        {
            return Add(databasePath, name, "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", true,
                out errOut);
        }
        /// <summary>
        /// Adds the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="country">The country.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="eMail">The e mail.</param>
        /// <param name="license">The license.</param>
        /// <param name="webSite">The web site.</param>
        /// <param name="stillInBusiness">if set to <c>true</c> [still in business].</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Add(string databasePath, string name, string address, string city, string state,
            string zipCode, string country, string phone, string fax, string eMail, string license, string webSite,
            bool stillInBusiness, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int sib = stillInBusiness ? 1 : 0;
                string sql =
                    $"INSERT INTO Appriaser_Contact_Details (aname,Address1,City,State,Zip,country, phone, fax, website,email, lic,sib,sync_lastupdate) " +
                    $"VALUES('{name}','{address}','{city}','{state}','{zipCode}','{country}','{phone}','{fax}','{webSite}','{eMail}','{license}',{sib},Now())";
                bAns = Database.Execute(databasePath, sql, out errOut);
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
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="address">The address.</param>
        /// <param name="address2">The address2.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="country">The country.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="eMail">The e mail.</param>
        /// <param name="license">The license.</param>
        /// <param name="webSite">The web site.</param>
        /// <param name="stillInBusiness">if set to <c>true</c> [still in business].</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Update(string databasePath, long id, string name, string address, string address2,
            string city, string state,
            string zipCode, string country, string phone, string fax, string eMail, string license, string webSite,
            bool stillInBusiness, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int sib = stillInBusiness ? 1 : 0;
                string sql =
                    $"Update Appriaser_Contact_Details set aname='{name}',Address1='{address}', Address2='{address2}',City='{city}'," +
                    $"State='{state}',Zip='{zipCode}',country='{country}', phone='{phone}', fax='{fax}', website='{webSite}'" +
                    $",email='{eMail}', lic='{license}',sib={sib},sync_lastupdate=Now() where id={id};";

                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }

            return bAns;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;AppraisersContactDetails&gt;.</returns>
        private static List<AppraisersContactDetails> GetList(DataTable dt, out string errOut)
        {
            List<AppraisersContactDetails> lst = new List<AppraisersContactDetails>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    //d[""] == DBNull.Value ? "N/A" : 
                    lst.Add(new AppraisersContactDetails()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        Name = d["aName"] == DBNull.Value ? "N/A" : d["aName"].ToString(),
                        Address1 = d["Address1"] == DBNull.Value ? "N/A" : d["Address1"].ToString(),
                        Address2 = d["Address2"] == DBNull.Value ? "N/A" : d["Address2"].ToString(),
                        City = d["City"] == DBNull.Value ? "N/A" : d["City"].ToString(),
                        State = d["State"] == DBNull.Value ? "N/A" : d["State"].ToString(),
                        ZipCode = d["Zip"] == DBNull.Value ? "N/A" : d["Zip"].ToString(),
                        Phone = d["Phone"] == DBNull.Value ? "N/A" : d["Phone"].ToString(),
                        Country = d["Country"] == DBNull.Value ? "N/A" : d["Country"].ToString(),
                        Email = d["Email"] == DBNull.Value ? "N/A" : d["Email"].ToString(),
                        Lic = d["Lic"] == DBNull.Value ? "N/A" : d["Lic"].ToString(),
                        WebSite = d["WebSite"] == DBNull.Value ? "N/A" : d["WebSite"].ToString(),
                        Fax = d["Fax"] == DBNull.Value ? "N/A" : d["Fax"].ToString(),
                        StillInBusiness = (Convert.ToInt32(d["SIB"].ToString()) == 1),
                        LastSync = d["sync_lastupdate"] == DBNull.Value ? "N/A" : d["sync_lastupdate"].ToString()
                    });
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetList", e);
            }
            return lst;
        }
    }
}
