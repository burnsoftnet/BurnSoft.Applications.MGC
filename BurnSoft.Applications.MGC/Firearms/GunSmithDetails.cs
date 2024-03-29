﻿using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Types;

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class GunSmithDetails, Class to handle management of the gunsmith_details table.
    /// </summary>
    public class GunSmithDetails
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Firearms.GunSmithDetails";
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
        /// Existses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="smithName">Name of the smith.</param>
        /// <param name="orderDetails"></param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Exists(string databasePath,long gunId,string smithName, string orderDetails, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from GunSmith_Details where gsmith like '{smithName}%' and gid={gunId} and od='{orderDetails}'";
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
        /// Adds the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="smithName">Name of the smith.</param>
        /// <param name="gunSmithId">The gun smith identifier.</param>
        /// <param name="orderDetails">The order details.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Add(string databasePath, long gunId, string smithName, long gunSmithId, string orderDetails, string notes, string startDate, string returnDate, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"INSERT INTO GunSmith_Details(GID,gsmith,GSID,od,notes,sdate,rdate,sync_lastupdate) VALUES({gunId}," +
                             $"'{smithName}',{gunSmithId},'{orderDetails}','{notes}','{startDate}','{returnDate}',Now())";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }

            return bAns;
        }
        /// <summary>
        /// Adds the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="smithName">Name of the smith.</param>
        /// <param name="orderDetails">The order details.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Add(string databasePath, long gunId, string smithName, string orderDetails, string notes, string startDate, string returnDate, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"INSERT INTO GunSmith_Details(GID,gsmith,od,notes,sdate,rdate,sync_lastupdate) VALUES({gunId}," +
                             $"'{smithName}','{orderDetails}','{notes}','{startDate}','{returnDate}',Now())";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }

            return bAns;
        }
        /// <summary>
        /// Determines whether [has collection attached] [the specified database path].
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.Exception"></exception>
        public static int HasCollectionAttached(string databasePath, string name, out string errOut)
        {
            int iAns = 0;
            errOut = @"";
            try
            {
                string sql = $"SELECT Count(*) as Total from GunSmith_Details where gsmith='{name}'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                iAns = dt.Rows.Count;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("HasCollectionAttached", e);
            }
            return iAns;
        }
        /// <summary>
        /// Updates The gun smith details for a firearm
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="smithName">Name of the smith.</param>
        /// <param name="gunSmithId">The gun smith identifier.</param>
        /// <param name="orderDetails">The order details.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Update(string databasePath,long id, long gunId, string smithName, long gunSmithId, string orderDetails, string notes, string startDate, string returnDate, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql =
                    $"UPDATE GunSmith_Details set GID={gunId},gsmith='{smithName}',gsid={gunSmithId},od='{orderDetails}'" +
                    $",notes='{notes}',sdate='{startDate}',rdate='{returnDate}',sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }

            return bAns;
        }
        /// <summary>
        /// Updates the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="smithName">Name of the smith.</param>
        /// <param name="orderDetails">The order details.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Update(string databasePath, long id, string smithName, string orderDetails, string notes, string startDate, string returnDate, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql =
                    $"UPDATE GunSmith_Details set gsmith='{smithName}',od='{orderDetails}'" +
                    $",notes='{notes}',sdate='{startDate}',rdate='{returnDate}',sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }

            return bAns;
        }
        /// <summary>
        /// Updates the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="smithName">Name of the smith.</param>
        /// <param name="orderDetails">The order details.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Update(string databasePath, long id, long gunId, string smithName, string orderDetails, string notes, string startDate, string returnDate, out string errOut)
        {
            return Update(databasePath, id, gunId, smithName, 0, orderDetails, notes, startDate, returnDate,
                out errOut);
        }
        /// <summary>
        /// Updates The gun smith details for a firearm
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="smithName">Name of the smith.</param>
        /// <param name="gunSmithId">The gun smith identifier.</param>
        /// <param name="orderDetails">The order details.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Update(string databasePath, long id, string smithName, long gunSmithId, string orderDetails, string notes, string startDate, string returnDate, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql =
                    $"UPDATE GunSmith_Details set gsmith='{smithName}',gsid={gunSmithId},od='{orderDetails}'" +
                    $",notes='{notes}',sdate='{startDate}',rdate='{returnDate}',sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }

            return bAns;
        }
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="gunSmithId">The gun smith identifier.</param>
        /// <param name="orderDetails">The order details.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static long GetId(string databasePath, long gunId, long gunSmithId, string orderDetails, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                string sql = $"select * from  GunSmith_Details where GID={gunId} and gsid={gunSmithId} and od='{orderDetails}'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                List<GunSmithWorkDone> lst = GetData(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (GunSmithWorkDone l in lst)
                {
                    lAns = l.Id;
                }

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetId", e);
            }

            return lAns;
        }
        /// <summary>
        /// Deletes the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Delete(string databasePath, long id, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"DELETE from GunSmith_Details where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }

            return bAns;
        }
        /// <summary>
        /// Listses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;GunSmithWorkDone&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static List<GunSmithWorkDone> Lists(string databasePath, long gunId, out string errOut)
        {
            List<GunSmithWorkDone> lst = new List<GunSmithWorkDone>();
            errOut = @"";
            try
            {
                string sql = $"select * from GunSmith_Details where gid={gunId}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = GetData(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Lists", e);
            }
            return lst;
        }
        /// <summary>
        /// Listses the by identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;GunSmithWorkDone&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static List<GunSmithWorkDone> ListsById(string databasePath, long id, out string errOut)
        {
            List<GunSmithWorkDone> lst = new List<GunSmithWorkDone>();
            errOut = @"";
            try
            {
                string sql = $"select * from GunSmith_Details where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = GetData(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Lists", e);
            }
            return lst;
        }
        /// <summary>
        /// Listses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunSmithName">Name of the gun smith.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;GunSmithWorkDone&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static List<GunSmithWorkDone> Lists(string databasePath, string gunSmithName, out string errOut)
        {
            List<GunSmithWorkDone> lst = new List<GunSmithWorkDone>();
            errOut = @"";
            try
            {
                string sql = $"select * from GunSmith_Details where gsmith='{gunSmithName}'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = GetData(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Lists", e);
            }
            return lst;
        }

        /// <summary>
        /// Listses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="doDistinct"></param>
        /// <returns>List&lt;GunSmithWorkDone&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static List<GunSmithWorkDone> Lists(string databasePath,  out string errOut, bool doDistinct = false)
        {
            List<GunSmithWorkDone> lst = new List<GunSmithWorkDone>();
            errOut = @"";
            try
            {
                string sql = $"select * from GunSmith_Details";
                if (doDistinct) sql = $"SELECT DISTINCT(gsmith) as name from GunSmith_Details";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = GetData(dt, out errOut, doDistinct);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Lists", e);
            }
            return lst;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="doDistinctGunSmiths"></param>
        /// <returns>List&lt;GunSmithWorkDone&gt;.</returns>
        private static List<GunSmithWorkDone> GetData(DataTable dt, out string errOut, bool doDistinctGunSmiths = false)
        {
            List<GunSmithWorkDone> lst = new List<GunSmithWorkDone>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    if (!doDistinctGunSmiths)
                    {
                        long id = Convert.ToInt32(d["id"]);
                        long gunId = d["gid"] != DBNull.Value ? Convert.ToInt32(d["gid"]) : 0;
                        long gsid = 0;
                        try
                        {
                            gsid = d["gsid"] != DBNull.Value ? Convert.ToInt32(d["gsid"]) : 0;
                        }
#pragma warning disable 168
                        catch (Exception e)
#pragma warning restore 168
                        {
                            //Temp Catch for databases that are missing the gsid field
                        }
                        string orderDetails = d["od"] != DBNull.Value ? d["od"].ToString().Trim() : "";
                        string rDate = d["rdate"] != DBNull.Value ? d["rdate"].ToString().Trim() : "";
                        string sDate = d["sdate"] != DBNull.Value ? d["sdate"].ToString().Trim() : "";
                        string notes = d["notes"] != DBNull.Value ? d["notes"].ToString().Trim() : "";
                        string smith = d["gsmith"] != DBNull.Value ? d["gsmith"].ToString().Trim() : "";

                        lst.Add(new GunSmithWorkDone()
                        {
                            Id = id,
                            GunId = gunId,
                            GunSmithId = gsid,
                            OrderDetails = orderDetails,
                            ReturnDate = rDate,
                            StartDate = sDate,
                            Notes = notes,
                            GunSmithName = smith,
                            LastSync = d["sync_lastupdate"] != null ? d["sync_lastupdate"].ToString() : ""
                        });
                    }
                    else
                    {
                        string smith = d["name"] != DBNull.Value ? d["name"].ToString().Trim() : "";
                        lst.Add(new GunSmithWorkDone()
                        {
                            Id = 0,
                            GunId = 0,
                            GunSmithId = 0,
                            OrderDetails = "",
                            ReturnDate = "",
                            StartDate = "",
                            Notes = "",
                            GunSmithName = smith,
                            LastSync = ""
                        });
                    }
                    
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetData", e);
            }
            return lst;
        }
    }
}
