using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurnSoft.Applications.MGC.Types;

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class Models will help manage the data in the Gun_Model table
    /// </summary>
    public class Models
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Firearms.Models";
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
        public static bool Add(string databasePath, string name, long manufacturerId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = "INSERT INTO Gun_Model(Model, GMID,sync_lastupdate) VALUES(" +
                             $"'{name}',{manufacturerId},Now())";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }
            return bAns;
        }

        public static bool Update(string databasePath,long id, string name, long manufacturerId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"UPDATE Gun_Model set Model='{name}', GMID={manufacturerId},sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }
            return bAns;
        }

        public static bool Update(string databasePath, long id, string name, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"UPDATE Gun_Model set Model='{name}',sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }
            return bAns;
        }

        public static bool Exists(string databasePath, string name, long manufacturerId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Model where Model='{name}' and GMID={manufacturerId}";
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

        public static bool Delete(string databasePath, long id, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"delete from Gun_Model where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }
            return bAns;
        }

        public static long GetId(string databasePath, string name, long manufacturerId, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from  Gun_Model where Model='{name}' and GMID={manufacturerId}";
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
        public static string GetName(string databasePath, long id, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Model where id={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                List<ModelList> lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                foreach (ModelList l in lst)
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

        public static List<ModelList> Lists(string databasePath, long manufacturerId, out string errOut)
        {
            List<ModelList> lst = new List<ModelList>();
            errOut = @"";
            try
            {
                string sql = $"SELECT * from  Gun_Model where GMID={manufacturerId}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Lists", e);
            }

            return lst;
        }

        public static List<ModelList> Lists(string databasePath, out string errOut)
        {
            List<ModelList> lst = new List<ModelList>();
            errOut = @"";
            try
            {
                string sql = $"SELECT * from  Gun_Model";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Lists", e);
            }

            return lst;
        }

        private static List<ModelList> MyList(DataTable dt, out string errOut)
        {
            List<ModelList> lst = new List<ModelList>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new ModelList()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        ManufacturerId = Convert.ToInt32(d["GMID"]),
                        Name = d["Model"] != DBNull.Value ? d["Model"].ToString() : "",
                        LastSync = d["sync_lastupdate"] != DBNull.Value ? d["sync_lastupdate"].ToString() : ""
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
