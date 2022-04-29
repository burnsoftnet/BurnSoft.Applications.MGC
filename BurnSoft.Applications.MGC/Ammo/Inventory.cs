using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using BurnSoft.Applications.MGC.Global;
using BurnSoft.Applications.MGC.Types;
using Microsoft.VisualBasic;
// ReSharper disable UnusedMember.Global

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Ammo
{
    /// <summary>
    /// Class Inventory contains all the functions used to manage the ammo in the database
    /// </summary>
    public class Inventory : IDisposable
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.Ammo.Inventory";
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
        /// Updates the qty.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="ammoId">The ammo identifier.</param>
        /// <param name="currentQty">The current qty.</param>
        /// <param name="roundCountUsed">The Number of rounds that was used to be subtracted by the current inventory number</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="doAdd">by default it will subtract, is this is set to true it will add it instead</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool UpdateQty(string databasePath, long ammoId, long currentQty, int roundCountUsed,
            out string errOut, bool doAdd = false)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                long endTotal = currentQty - roundCountUsed;
                if (doAdd) endTotal = currentQty + roundCountUsed;
                string sql = $"UPDATE Gun_Collection_Ammo set Qty={endTotal} where id={ammoId}";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("UpdateQty", e);
            }
            return bAns;
        }


        /// <summary>
        /// Deletes the specified ammo from the database as well as the audit information
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="ammoId">The ammo identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Delete(string databasePath, long ammoId, out string errOut)
        {
            Audit.Delete(databasePath, ammoId, out errOut);
            string sql = $"Delete from Gun_Collection_Ammo where id={ammoId}";
            return Database.Execute(databasePath, sql, out errOut);
        }
        /// <summary>
        /// Adds the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="name">The name.</param>
        /// <param name="cal">The cal.</param>
        /// <param name="grain">The grain.</param>
        /// <param name="jacket">The jacket.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="dcal">The dcal.</param>
        /// <param name="velocityNumber">The velocity number.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Add(string databasePath, string manufacturer, string name, string cal, string grain, string jacket, long qty, double dcal, long velocityNumber , out string errOut)
        {
            string sql = $"INSERT INTO Gun_Collection_Ammo(Manufacturer,Name,Cal,Grain,Jacket,Qty,dcal,vel_n,sync_lastupdate) VALUES('{manufacturer}','{name}','{cal}','{grain}','{jacket}',{qty},{dcal},{velocityNumber},Now())";
            return Database.Execute(databasePath, sql, out errOut);
        }
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="name">The name.</param>
        /// <param name="cal">The cal.</param>
        /// <param name="grain">The grain.</param>
        /// <param name="jacket">The jacket.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="dcal">The dcal.</param>
        /// <param name="velocityNumber">The velocity number.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long GetId(string databasePath, string manufacturer, string name, string cal, string grain, string jacket, long qty, double dcal, long velocityNumber,out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                string sql = $"SELECT Top 1 * from Gun_Collection_Ammo where Manufacturer='{manufacturer}' and Name='{name}' and Cal='{cal}' and Grain='{grain}' and Jacket='{jacket}' and Qty={qty} and dcal={dcal} and vel_n={velocityNumber} order by ID DESC";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                List<Ammunition> lst = MyList(dt, out errOut);
                foreach (Ammunition a in lst)
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
        /// Gets the total inventory.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.Exception"></exception>
        public static long GetTotalInventory(string databasePath, out string errOut)
        {
            return DatabaseRelated.GetTotal(databasePath,
                "SELECT SUM(QTY) as T from Gun_Collection_Ammo",
                "GetTotalInventory", out errOut);
        }

        /// <summary>
        /// Totals the rounds fired.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long TotalRoundsFired(string databasePath,int gunId, out string errOut)
        {
            return DatabaseRelated.GetTotal(databasePath,
                $"SELECT SUM(cInt(RndFired)) as T from Maintance_Details where GID={gunId} and DC=1",
                "TotalRoundsFired", out errOut);
        }
        /// <summary>
        /// Totals the ammo selected.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="caliber">The caliber.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long TotalAmmoSelected(string databasePath, string caliber, out string errOut)
        {
            return DatabaseRelated.GetTotal(databasePath,
                $"SELECT SUM(QTY) as T from Gun_Collection_Ammo where Cal='{caliber}'",
                "TotalRoundsFired", out errOut);
        }
        /// <summary>
        /// Totals the ammo selected.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="caliber">The caliber.</param>
        /// <param name="caliber2">The caliber2.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long TotalAmmoSelected(string databasePath, string caliber,string caliber2, out string errOut)
        {
            return DatabaseRelated.GetTotal(databasePath,
                $"SELECT SUM(QTY) as T from Gun_Collection_Ammo where Cal='{caliber}' or Cal='{caliber2}'",
                "TotalRoundsFired", out errOut);
        }
        /// <summary>
        /// Totals the ammo selected.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="caliber">The caliber.</param>
        /// <param name="caliber2">The caliber2.</param>
        /// <param name="caliber3">The caliber3.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long TotalAmmoSelected(string databasePath, string caliber, string caliber2,string caliber3, out string errOut)
        {
            return DatabaseRelated.GetTotal(databasePath,
                $"SELECT SUM(QTY) as T from Gun_Collection_Ammo where Cal='{caliber}' or Cal='{caliber2}' or Cal='{caliber3}'",
                "TotalRoundsFired", out errOut);
        }

        /// <summary>
        /// Gets the qty.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long GetQty(string databasePath, long id, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Collection_Ammo where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                List<Ammunition> lst = MyList(dt, out errOut);
                foreach (Ammunition a in lst)
                {
                    lAns = a.Qty;
                }

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetQty", e);
            }
            return lAns;
        }
        /// <summary>
        /// Updates the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="name">The name.</param>
        /// <param name="cal">The cal.</param>
        /// <param name="grain">The grain.</param>
        /// <param name="jacket">The jacket.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="dcal">The dcal.</param>
        /// <param name="velocityNumber">The velocity number.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Update(string databasePath,long id, string manufacturer, string name, string cal, string grain, string jacket, long qty, double dcal, long velocityNumber, out string errOut)
        {
            string sql = $"UPDATE Gun_Collection_Ammo set Manufacturer='{manufacturer}', Name='{name}', Cal='{cal}', Grain='{grain}', Jacket='{jacket}', Qty={qty}, dcal={dcal}, vel_n={velocityNumber}, sync_lastupdate=Now() where id={id}";
            return Database.Execute(databasePath, sql, out errOut);
        }
        /// <summary>
        /// Existses the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="name">The name.</param>
        /// <param name="cal">The cal.</param>
        /// <param name="grain">The grain.</param>
        /// <param name="jacket">The jacket.</param>
        /// <param name="dcal">The dcal.</param>
        /// <param name="velocityNumber">The velocity number.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Exists(string databasePath,  string manufacturer, string name, string cal, string grain, string jacket, double dcal, long velocityNumber, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT Top 1 * from Gun_Collection_Ammo where Manufacturer='{manufacturer}' and Name='{name}' and Cal='{cal}' and Grain='{grain}' and Jacket='{jacket}' and dcal={dcal} and vel_n={velocityNumber}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                List<Ammunition> lst = MyList(dt, out errOut);
                bAns = lst.Count > 0;

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Exists", e);
            }
            return bAns;
        }

        /// <summary>
        /// Gets the last ammo identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        public static long GetLastAmmoId(string databasePath, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                string sql = "SELECT Top 1 * from Gun_Collection_Ammo order by id desc";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                List<Ammunition> lst = MyList(dt, out errOut);
                foreach (Ammunition a in lst)
                {
                    lAns = a.Id;
                }

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetLastAmmoId", e);
            }
            return lAns;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="name">The name.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="cal">The cal.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;Ammunition&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Ammunition> GetList(string databasePath, string name, string manufacturer, string cal,
            out string errOut)
        {
            List<Ammunition> lst = new List<Ammunition>();
            errOut = @"";
            try
            {
                string sql = $"select * from Gun_Collection_Ammo where name='{name}' and Manufacturer='{manufacturer}' and Cal='{cal}'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception($"{errOut}{Environment.NewLine}SQL = {sql}");
                lst = MyList(dt, out errOut);
                if (errOut.Length > 0) throw new Exception($"{errOut}{Environment.NewLine}SQL = {sql}");
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetList", e);
            }

            return lst;
        }
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;Ammunition&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Ammunition> GetList(string databasePath, long id, out string errOut)
        {
            List<Ammunition> lst = new List<Ammunition>();
            errOut = @"";
            try
            {
                string sql = $"select * from Gun_Collection_Ammo where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception($"{errOut}{Environment.NewLine}SQL = {sql}");
                lst = MyList(dt, out errOut);
                if (errOut.Length > 0) throw new Exception($"{errOut}{Environment.NewLine}SQL = {sql}");
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetList", e);
            }

            return lst;
        }
        /// <summary>
        /// Convs to number.
        /// </summary>
        /// <param name="strValue">The string value.</param>
        /// <returns>System.Double.</returns>
        public static double ConvToNum(string strValue)
        {
            double dAns;
            short intChar = (short)strValue.Length;
            short i;
            string newValue = "";
            string lastValue = "";
            bool needDiv = false;
            for (i = 1; i <= intChar; i++)
            {
                var curValue = Strings.Mid(strValue, i, 1);
                if (curValue == " ")
                    break;
                if (Information.IsNumeric(curValue))
                {
                    if (Strings.Len(lastValue) != 0)
                        lastValue = Strings.Mid(newValue, Strings.Len(newValue), 1);
                    else
                        lastValue = curValue;
                    if (!needDiv)
                        newValue = newValue + curValue;
                    else
                        newValue = Convert.ToString(Convert.ToDouble(curValue) / Convert.ToDouble(lastValue), CultureInfo.InvariantCulture);
                    needDiv = false;
                }
                else
                    switch (curValue)
                    {
                        case ".":
                        {
                            newValue = newValue + curValue;
                            needDiv = false;
                            break;
                        }

                        case "/":
                        {
                            needDiv = true;
                            break;
                        }
                    }
            }
            dAns = Convert.ToDouble(newValue);
            return dAns;
        }

        /// <summary>
        /// Converts the ammo grains to number.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static bool ConvertAmmoGrainsToNum(string databasePath, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                List<Ammunition> lst = GetList(databasePath, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (Ammunition l in lst)
                {
                    if (l.Grain.Length > 0)
                    {
                        double dValue = ConvToNum(l.Grain);
                        string sql = $"UPDATE Gun_Collection_Ammo set dcal={dValue} where id={l.Id}";
                        if (!Database.Execute(databasePath, sql, out errOut)) throw new Exception(errOut);
                    }
                }

                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("ConvertAmmoGrainsToNum", e);
            }
            return bAns;
        }
        /// <summary>
        /// Ammo the is already listed.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="name">The name.</param>
        /// <param name="cal">The cal.</param>
        /// <param name="grain">The grain.</param>
        /// <param name="jacket">The jacket.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="mid">The mid.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static bool AmmoIsAlreadyListed(string databasePath, string manufacturer,string name, string cal, string grain, string jacket,out long qty, out long mid,  out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            qty = 0;
            mid = 0;
            try
            {
                string sql = $"SELECT * from Gun_Collection_Ammo where Manufacturer = '{manufacturer}' and Name='{name}' and Cal='{cal}' and Grain='{grain}' and Jacket='{jacket}'";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception($"{errOut}{Environment.NewLine}SQL = {sql}");
                List<Ammunition> lst = MyList(dt, out errOut);
                if (errOut.Length > 0) throw new Exception($"{errOut}{Environment.NewLine}SQL = {sql}");
                foreach (Ammunition l in lst)
                {
                    qty = l.Qty;
                    mid = l.Id;
                }

                bAns = lst.Count > 0;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("AmmoIsAlreadyListed", e);
            }

            return bAns;
        }
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;Ammunition&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Ammunition> GetList(string databasePath, out string errOut)
        {
            List<Ammunition> lst = new List<Ammunition>();
            errOut = @"";
            try
            {
                string sql = "select * from Gun_Collection_Ammo";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception($"{errOut}{Environment.NewLine}SQL = {sql}");
                lst = MyList(dt, out errOut);
                if (errOut.Length > 0) throw new Exception($"{errOut}{Environment.NewLine}SQL = {sql}");
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetList", e);
            }

            return lst;
        }
        /// <summary>
        /// Mies the list.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;Ammunition&gt;.</returns>
        private static List<Ammunition> MyList(DataTable dt, out string errOut)
        {
            errOut = @"";
            List<Ammunition> lst = new List<Ammunition>();
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new Ammunition()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        Cal = d["cal"] != DBNull.Value ? d["cal"].ToString().Trim() : "",
                        Dcal = Convert.ToDouble(d["dcal"]),
                        Grain = d["grain"] != DBNull.Value ? d["grain"].ToString().Trim() : "",
                        Jacket = d["jacket"] != DBNull.Value ? d["jacket"].ToString().Trim() : "",
                        Manufacturer = d["Manufacturer"] != DBNull.Value ? d["Manufacturer"].ToString().Trim() : "",
                        Name = d["name"] != DBNull.Value ? d["name"].ToString().Trim() : "",
                        Qty = d["qty"] != DBNull.Value ? Convert.ToInt32(d["qty"]) : 0,
                        Sync_lastupdate = d["Sync_lastupdate"].ToString(),
                        Vel_n = d["Vel_n"] != DBNull.Value ? Convert.ToInt32(d["Vel_n"]) : 0,
                        Vel_t = d["Vel_t"] != DBNull.Value ? d["Vel_t"].ToString().Trim() : ""
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
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
