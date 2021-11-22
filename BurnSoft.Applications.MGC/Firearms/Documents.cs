﻿using System;
using System.Collections.Generic;
using System.Data;
using BurnSoft.Applications.MGC.Types;
// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class Documents to manage the doucments section, upload, edit assisgn, and delete
    /// </summary>
    public class Documents
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string ClassLocation = "BurnSoft.Applications.MGC.Firearms.Documents";
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
        /// The file filter list
        /// </summary>
        public static string FileFilterList = "PDF Files(*.pdf)|*.pdf|Text Files(*.txt)|*.txt|Jpg Files(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp|Microsoft Word(*.doc)|*.doc|Microsoft Word Open XML(*.docx)|*.docx|Portable Network Graphics(*.png)|*.png";
        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <param name="selectedIndex">Index of the selected.</param>
        /// <returns>System.String.</returns>
        public static string GetDocType(int selectedIndex)
        {
            string sAns = "";
            switch (selectedIndex)
            {
                case 1:
                    sAns = "pdf";
                    break;
                case 2:
                    sAns = "txt";
                    break;
                case 3:
                    sAns = "jpg";
                    break;
                case 4:
                    sAns = "bmp";
                    break;
                case 5:
                    sAns = "doc";
                    break;
                case 6:
                    sAns = "docx";
                    break;
                case 7:
                    sAns = "png";
                    break;
            }
            return sAns;
        }
        
        /// <summary>
        /// Gets the last identifier.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static long GetLastId(string databasePath, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                string sql = "select top 1 id from Gun_Collection_Docs order by ID DESC";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw  new Exception(errOut);
                List<DocumentList> lst = MyList(dt, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (DocumentList d in lst)
                {
                    lAns = d.Id;
                }

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("", e);
            }

            return lAns;
        }
        /// <summary>
        /// Performs the document link.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="firearmId">The firearm identifier.</param>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool PerformDocLink(string databasePath, int firearmId, int documentId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"INSERT INTO Gun_Collection_Docs_Links (GID,DID) VALUES({firearmId},{documentId})";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("PerformDocLink", e);
            }
            return bAns;
        }
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;DocumentList&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static List<DocumentList> GetList(string databasePath, out string errOut)
        {
            List<DocumentList> lst = new List<DocumentList>();
            errOut = @"";
            try
            {
                string sql = "select * from Gun_Collection_Docs";
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
        /// Gets the list.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;DocumentList&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static List<DocumentList> GetList(string databasePath,int id, out string errOut)
        {
            List<DocumentList> lst = new List<DocumentList>();
            errOut = @"";
            try
            {
                string sql = $"select * from Gun_Collection_Docs where ID={id}";
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
        /// <returns>List&lt;BarrelSystems&gt;.</returns>
        internal static List<DocumentList> MyList(DataTable dt, out string errOut)
        {
            List<DocumentList> lst = new List<DocumentList>();
            errOut = @"";
            try
            {
                foreach (DataRow d in dt.Rows)
                {
                    lst.Add(new DocumentList()
                    {
                        Id = Convert.ToInt32(d["id"]),
                        DocName = d["doc_name"].ToString(),
                        DocDescription = d["doc_description"].ToString(),
                        DocFilename = d["doc_filename"].ToString(),
                        Dta = d["dta"].ToString(),
                        DataFile = d["doc_file"],
                        Length = Convert.ToInt32(d["length"]),
                        DataFileThumb = d["doc_thumb"],
                        DocExt = d["doc_ext"].ToString(),
                        Category = d["doc_cat"].ToString(),
                        SyncLastUpdate = d["sync_lastupdate"].ToString()

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
