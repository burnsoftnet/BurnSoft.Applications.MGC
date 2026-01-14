using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Universal;
// ReSharper disable MustUseReturnValue

// ReSharper disable ExpressionIsAlwaysNull

// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global


namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class PictureDisplay.
    /// </summary>
    public class PictureDisplay
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.Firearms.PictureDisplay";
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
        /// Gets the list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;PictureDisplayList&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static List<PictureDisplayList> GetList(string databasePath, out string errOut)
        {
            List<PictureDisplayList> lst = new List<PictureDisplayList>();
            errOut = @"";
            try
            {
                string sql = "SELECT p.id,p.cid,c.FullName, p.Picture from Gun_Collection_Pictures p inner join Gun_Collection c on c.id=p.cid where p.ISMAIN=1 order by c.FullName asc;";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
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
        /// <param name="isDetails">if set to <c>true</c> [is details].</param>
        /// <param name="dbPath">The database path.</param>
        /// <returns>List&lt;PictureDisplayList&gt;.</returns>
        internal static List<PictureDisplayList> MyList(DataTable dt, out string errOut, bool isDetails = false, string dbPath = "")
        {
            List<PictureDisplayList> lst = new List<PictureDisplayList>();
            errOut = @"";
            try
            {
                BSOtherObjects obj = new BSOtherObjects();

                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new PictureDisplayList()
                    {
                        Id = Convert.ToInt32(d["id"] != DBNull.Value ? d["id"] : 0),
                        Cid = Convert.ToInt32(d["CID"] != DBNull.Value ? d["CID"] : 0),
                        FullName = d["FullName"].ToString()
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
