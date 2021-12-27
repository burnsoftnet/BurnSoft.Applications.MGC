using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Security.RegularEncryption.SHA;

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.PeopleAndPlaces
{
    /// <summary>
    /// Class OwnerInformation. handing the Owner_infotable in the database
    /// </summary>
    public class OwnerInformation
    {
        #region "Exception Error Handling"

        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.PeopleAndPlaces.OwnerInformation";

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
        /// Adds the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="ccdwl">The CCDWL.</param>
        /// <param name="usePwd">if set to <c>true</c> [use password].</param>
        /// <param name="pwd">The password.</param>
        /// <param name="uid">The uid.</param>
        /// <param name="forgotWord">The forgot word.</param>
        /// <param name="forgotPhrase">The forgot phrase.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Add(string databasePath, string name, string address, string city, string state, string zip,
            string phone, string ccdwl, bool usePwd, string pwd, string uid, string forgotWord, string forgotPhrase,
            out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                int iUsePassword = usePwd ? 1 : 0;
                string sql =
                    $"INSERT INTO Owner_Info(name,address,City,State,Zip,Phone,CCDWL,UsePWD,PWD,UID,forgot_word,forgot_phrase,sync_lastupdate) VALUES('" +
                    $"{name}','{address}','{city}','{state}','{zip}','{phone}','{ccdwl}',{iUsePassword},'{pwd}','{uid}','{forgotWord}','{forgotPhrase}',Now())";
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
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="ccdwl">The CCDWL.</param>
        /// <param name="usePwd">if set to <c>true</c> [use password].</param>
        /// <param name="pwd">The password.</param>
        /// <param name="uid">The uid.</param>
        /// <param name="forgotWord">The forgot word.</param>
        /// <param name="forgotPhrase">The forgot phrase.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Update(string databasePath,long id, string name, string address, string city, string state, string zip,
            string phone, string ccdwl, bool usePwd, string pwd, string uid, string forgotWord, string forgotPhrase,
            out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                if (id == 0)
                {
                    bAns = Add(databasePath, name, address, city, state, zip, phone, ccdwl, usePwd, pwd, uid,
                        forgotWord, forgotPhrase, out errOut);
                }
                else
                {
                    int iUsePassword = usePwd ? 1 : 0;
                    string sql =
                        $"UPDATE Owner_Info set name='{name}',address='{address}',City='{city}',State='{state}',Zip='{zip}',Phone='{phone}'" +
                        $",CCDWL='{ccdwl}',UsePWD={iUsePassword},PWD='{pwd}',UID='{uid}',forgot_word='{forgotWord}',forgot_phrase='{forgotPhrase}'" +
                        $",sync_lastupdate=Now() where id={id}";
                    bAns = Database.Execute(databasePath, sql, out errOut);
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }
            return bAns;
        }

        /// <summary>
        /// Gets the owner information from the database
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;OwnerInfo&gt;.</returns>
        /// <exception cref="Exception"></exception>
        public static List<OwnerInfo> GetOwnerInfo(string databasePath, out string errOut)
        {
            List<OwnerInfo> lst = new List<OwnerInfo>();
            errOut = @"";
            try
            {
                DataTable dt = Database.GetDataFromTable(databasePath, "SELECT TOP 1 * from Owner_Info", out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                lst = GetList(dt, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetOwnerInfo", e);
            }
            return lst;
        }
        /// <summary>
        /// Gets the owner identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="ownerName">Name of the owner.</param>
        /// <param name="ownerLic">The owner lic.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.Exception"></exception>
        public static long GetOwnerId(string databasePath,out string ownerName,out string ownerLic,  out string errOut)
        {
            long lAns = 0;
            errOut = "";
            ownerName = "";
            ownerLic = "";
            try
            {
                DataTable dt = Database.GetDataFromTable(databasePath, "SELECT TOP 1 * from Owner_Info", out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                List<OwnerInfo> lst = GetList(dt, out errOut);

                foreach (OwnerInfo l in lst)
                {
                    lAns = l.Id;
                    ownerName = l.Name;
                    ownerLic = One.Decrypt(l.Ccdwl);
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetOwnerId", e);
            }
            return lAns;
        }
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;OwnerInfo&gt;.</returns>
        private static List<OwnerInfo> GetList(DataTable dt, out string errOut)
        {
            List<OwnerInfo> lst = new List<OwnerInfo>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new OwnerInfo()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        Name = d["Name"] != DBNull.Value ? d["Name"].ToString().Trim() : "",
                        Address = d["Address"] != DBNull.Value ? d["Address"].ToString().Trim() : "",
                        City = d["City"] != DBNull.Value ? d["City"].ToString().Trim() : "",
                        State = d["State"] != DBNull.Value ? d["State"].ToString().Trim() : "",
                        ZipCode = d["Zip"] != DBNull.Value ? d["Zip"].ToString().Trim() : "",
                        Phone = d["Phone"] != DBNull.Value ? d["Phone"].ToString().Trim() : "",
                        Ccdwl = d["Ccdwl"] != DBNull.Value ? d["Ccdwl"].ToString().Trim() : "",
                        UsePassword = Convert.ToInt32(d["UsePWD"]) == 1,
                        UserName = d["uid"] != DBNull.Value ? d["uid"].ToString().Trim() : "",
                        ForgotWord = d["forgot_word"] != DBNull.Value ? d["forgot_word"].ToString().Trim() : "",
                        ForgotPhrase = d["forgot_phrase"] != DBNull.Value ? d["forgot_phrase"].ToString().Trim() : "",
                        LastSync = d["sync_lastupdate"].ToString().Trim(),
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
        /// Logins the enabled.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="uid">The uid.</param>
        /// <param name="pwd">The password.</param>
        /// <param name="forgotWord">The forgot word.</param>
        /// <param name="forgotPhrase">The forgot phrase.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool LoginEnabled(string databasePath,out string uid, out string pwd, out string forgotWord, out string forgotPhrase,
            out string errOut)
        {
            bool bAns = false;
            uid = "admin";
            pwd = "";
            forgotWord = "burnsoft";
            forgotPhrase = "The Company that made this App";
            try
            {
                List<OwnerInfo> oi = GetOwnerInfo(databasePath, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (OwnerInfo o in oi)
                {
                    bAns = o.UsePassword;
                    if (bAns)
                    {
                        uid = One.Decrypt(o.UserName);
                        pwd = One.Decrypt(o.Password);
                        if (o.ForgotPhrase.Length > 0)
                        {
                            forgotPhrase = One.Decrypt(o.ForgotPhrase);
                        }

                        if (o.ForgotWord.Length > 0)
                        {
                            forgotWord = One.Decrypt(o.ForgotWord);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("LoginEnabled", e);
            }
            return bAns;
        }
    }
}
