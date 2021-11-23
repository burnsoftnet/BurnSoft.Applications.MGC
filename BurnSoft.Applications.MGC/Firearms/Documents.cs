using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using BurnSoft.Applications.MGC.Types;
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global

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
        /// Gets the document from HDD.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetDocFromHdd(string filePath, out string errOut)
        {
            byte[] btAns = null;
            errOut = "";
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                btAns = br.ReadBytes(Convert.ToInt32(fs.Length));
                br.Close();
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetDocFromHdd", e);
            }
            return btAns;
        }
        /// <summary>
        /// Updates the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="fileWasSelected">if set to <c>true</c> [file was selected].</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="category">The category.</param>
        /// <param name="filePathAndName">Name of the file path and.</param>
        /// <param name="selectedFileType">Type of the selected file.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Update(string databasePath,int documentId, bool fileWasSelected,string title, string description, string category,string filePathAndName, int selectedFileType, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                OleDbConnection conn = new OleDbConnection(Database.ConnectionStringOle(databasePath, out errOut));
                conn.Open();
                String sql =
                    "update Gun_Collection_Docs set doc_name=@doc_name,doc_description=@doc_description,doc_cat=@doc_cat where id=@did";
                if (fileWasSelected) sql = "update Gun_Collection_Docs set doc_name=@doc_name,doc_description=@doc_description,doc_cat=@doc_cat,doc_filename=@doc_filename,doc_file=@doc_file,length=@length,doc_ext=@doc_ext where id=@did";

                OleDbCommand addDoc = conn.CreateCommand();
                addDoc.CommandText = sql;
                addDoc.Connection = conn;
                addDoc.Parameters.Add(new OleDbParameter("@doc_name", title));
                addDoc.Parameters.Add(new OleDbParameter("@doc_description", description));
                addDoc.Parameters.Add(new OleDbParameter("@doc_cat", category));

                if (fileWasSelected)
                {
                    Byte[] doc = GetDocFromHdd(filePathAndName, out errOut);
                    addDoc.Parameters.Add(new OleDbParameter("@doc_filename", Path.GetFileName(filePathAndName)));
                    addDoc.Parameters.Add(new OleDbParameter("@doc_file", doc));
                    addDoc.Parameters.Add(new OleDbParameter("@length", doc.Length));
                    addDoc.Parameters.Add(new OleDbParameter("@doc_ext", GetDocType(selectedFileType)));
                }
                addDoc.Parameters.Add(new OleDbParameter("@did", documentId));
                addDoc.ExecuteNonQuery();
                conn.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }
            return bAns;
        }
        /// <summary>
        /// Adds the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="category">The category.</param>
        /// <param name="filePathAndName">Name of the file path and.</param>
        /// <param name="selectedFileType">Type of the selected file.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Add(string databasePath, string title, string description, string category, string filePathAndName, int selectedFileType, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                OleDbConnection conn = new OleDbConnection(Database.ConnectionStringOle(databasePath, out errOut));
                conn.Open();
                String sql =
                    "insert into Gun_Collection_Docs (doc_name,doc_description,doc_filename,doc_file,length,doc_ext,doc_cat) values(@doc_name,@doc_description,@doc_filename,@doc_file,@length,@doc_ext,@doc_cat)";

                OleDbCommand addDoc = conn.CreateCommand();
                addDoc.CommandText = sql;
                addDoc.Connection = conn;

                OleDbParameter docName = new OleDbParameter("@doc_name", OleDbType.VarChar);
                OleDbParameter docDesc = new OleDbParameter("@doc_description", OleDbType.VarChar);
                OleDbParameter docCat = new OleDbParameter("@doc_cat", OleDbType.VarChar);
                OleDbParameter docFile = new OleDbParameter("@doc_filename", OleDbType.VarChar);


                //TODO #33 This does not  match the ad din the form need to update to match above.
                addDoc.Parameters.Add(new OleDbParameter("@doc_name", title));
                addDoc.Parameters.Add(new OleDbParameter("@doc_description", description));
                addDoc.Parameters.Add(new OleDbParameter("@doc_cat", category));
                Byte[] doc = GetDocFromHdd(filePathAndName, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                addDoc.Parameters.Add(new OleDbParameter("@doc_filename", Path.GetFileName(filePathAndName)));
                addDoc.Parameters.Add(new OleDbParameter("@doc_file", doc));
                addDoc.Parameters.Add(new OleDbParameter("@length", doc.Length));
                addDoc.Parameters.Add(new OleDbParameter("@doc_ext", GetDocType(selectedFileType)));
                
                addDoc.ExecuteNonQuery();
                conn.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Add", e);
            }
            return bAns;
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
        /// Determines whether [has documents attached] [the specified database path].
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if [has documents attached] [the specified database path]; otherwise, <c>false</c>.</returns>
        public static bool HasDocumentsAttached(string databasePath, int gunId, out string errOut)
        {
            return Database.DataExists(databasePath, $"select * from Gun_Collection_Docs_Links where GID={gunId}", out errOut);
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
