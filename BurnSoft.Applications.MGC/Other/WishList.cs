﻿using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Types;

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Other
{
    /// <summary>
    /// Class WishList will handle the functions to add, edit, get or delete data from the wishlist table.
    /// </summary>
    public class WishList
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Other.WishList";
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
        /// Adds the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="placetoBuy">The placeto buy.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="value">The value.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Add(string databasePath,  string manufacturer, string model, string placetoBuy, string qty, string value, string notes, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {

                string sql = $"INSERT INTO Wishlist (Manufacturer,Model,PlacetoBuy,Qty,[Value],Notes,sync_lastupdate) VALUES(" +
                             $"'{manufacturer}','{model}','{placetoBuy}','{qty}','{value}','{notes}',Now())";
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
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="placetoBuy">The placeto buy.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="value">The value.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Update(string databasePath, long id, string manufacturer, string model, string placetoBuy, string qty, string value, string notes, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"UPDATE Wishlist set Manufacturer='{manufacturer}',Model='{model}',PlacetoBuy='{placetoBuy}',Qty='{qty}',[Value]='{value}',Notes='{notes}',sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }

            return bAns;
        }
        /// <summary>
        /// Existses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public static bool Exists(string databasePath, string manufacturer, string model, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"select * from  Wishlist where Manufacturer='{manufacturer}' and Model='{model}'";
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
        /// Gets the name.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        public static string GetName(string databasePath, long id, out string errOut)
        {
            string ans = "";
            errOut = @"";
            try
            {
                string sql = $"SELECT * from WishList where ID={id}";

                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (DataRow d in dt.Rows)
                {
                    ans = $"{d["Manufacturer"]} {d["Model"]}";
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetName", e);
            }

            return ans;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="Exception"></exception>
        public static long GetId(string databasePath, string manufacturer, string model, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                string sql = $"select * from Wishlist where Manufacturer='{manufacturer}' and Model='{model}'";

                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (DataRow d in dt.Rows)
                {
                    lAns = Convert.ToInt32(d["id"]);
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
        public static bool Delete(string databasePath, long id, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"Delete from Wishlist where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }

            return bAns;
        }
        /// <summary>
        /// Lists the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;WishlistList&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static List<WishlistList> List(string databasePath, out string errOut)
        {
            List<WishlistList> lst = new List<WishlistList>();
            errOut = @"";
            try
            {
                string sql = "select * from Wishlist";
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
        /// Lists the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;WishlistList&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static List<WishlistList> List(string databasePath,long id, out string errOut)
        {
            List<WishlistList> lst = new List<WishlistList>();
            errOut = @"";
            try
            {
                string sql = $"select * from Wishlist where id={id}";
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
        /// Mies the list.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;WishlistList&gt;.</returns>
        private static List<WishlistList> MyList(DataTable dt, out string errOut)
        {
            List<WishlistList> lst = new List<WishlistList>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new WishlistList()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        Manufacturer = d["Manufacturer"] != DBNull.Value ? d["Manufacturer"].ToString() : "",
                        Model = d["Model"] != DBNull.Value ? d["Model"].ToString() : "",
                        LastSync = d["sync_lastupdate"] != DBNull.Value ? d["sync_lastupdate"].ToString() : "",
                        Notes = d["notes"] != DBNull.Value ? d["notes"].ToString() : "",
                        Qty = d["Qty"] != DBNull.Value ? d["Qty"].ToString() : "",
                        Value = d["Value"] != DBNull.Value ? d["Value"].ToString() : "",
                        PlacetoBuy = d["PlacetoBuy"] != DBNull.Value ? d["PlacetoBuy"].ToString() : ""
                    });
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("MyList", e);
            }

            return lst;
        }
    }
}
