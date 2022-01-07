using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ADODB;
using BurnSoft.Applications.MGC.Global;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Universal;

// ReSharper disable ExpressionIsAlwaysNull

// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class Pictures will handle all the functions relating to adding viewing and managing pictures in the database
    /// </summary>
    public class Pictures
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.Firearms.Pictures";
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
        /// Determines whether the firearm ( collection id ) already has a default picture set or not
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if [is first pic] [the specified database path]; otherwise, <c>false</c>.</returns>
        /// <exception cref="Exception"></exception>
        public static bool IsFirstPic(string databasePath, long collectionId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Collection_Pictures where CID={collectionId} and ISMAIN=1";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw  new Exception(errOut);
                bAns = dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("IsFirstPic", e);
            }
            return bAns;
        }

        /// <summary>
        /// Determines whether [has default picture] [the specified database path].
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="defaultPic"></param>
        /// <param name="errOut">The error out.</param>
        /// <param name="addPic">if set to <c>true</c> [add pic].</param>
        /// <returns><c>true</c> if [has default picture] [the specified database path]; otherwise, <c>false</c>.</returns>
        public static bool HasDefaultPicture(string databasePath, long id, string defaultPic,out string errOut, bool addPic = false)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Collection_Pictures where CID={id} and IsMain=1";
                bAns = Database.DataExists(databasePath, sql, out errOut);
                if (!bAns && addPic) AddDefaultPic(databasePath, id, defaultPic, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("AddDefaultPic", e);
            }
            return bAns;
        }
        /// <summary>
        /// Deletes the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool Delete(string databasePath, long id,  out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"DELETE from Gun_Collection_Pictures where ID={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Delete", e);
            }
            return bAns;
        }

        /// <summary>
        /// Adds the default pic.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="defaultPic"></param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool AddDefaultPic(string databasePath, long id, string defaultPic, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sFileName = Path.Combine(Directory.GetCurrentDirectory(), defaultPic);
                string sThumbName = Path.Combine(Directory.GetCurrentDirectory(), @"\mgc_thumb.jpg");
                // ---Start Function to convert picture to database format-----
                FileStream st = new FileStream(sFileName, FileMode.Open, FileAccess.Read);
                BinaryReader mbr = new BinaryReader(st);
                byte[] buffer = new byte[st.Length + 1];
                mbr.Read(buffer, 0, Convert.ToInt32(st.Length));
                st.Close();
                // ---End Function to convert picture to database format-----
                // --Start Function to convert picture to thumbnail for database format--
                int intPicHeight = 64;
                int intPicWidth = 64;
                var myBitmap = Image.FromFile(sFileName);
                Image.GetThumbnailImageAbort myPicCallback = null/* TODO Change to default(_) if this is not a reference type */;
                var myNewPic = myBitmap.GetThumbnailImage(intPicWidth, intPicHeight, myPicCallback, IntPtr.Zero);
                myBitmap.Dispose();
                File.Delete(sThumbName);
                myNewPic.Save(sThumbName, ImageFormat.Jpeg);
                myNewPic.Dispose();
                FileStream stT = new FileStream(sThumbName, FileMode.Open, FileAccess.Read);
                BinaryReader mbrT = new BinaryReader(stT);
                byte[] bufferT = new byte[stT.Length + 1];
                mbrT.Read(bufferT, 0, Convert.ToInt32(stT.Length));
                stT.Close();
                // --End Function to convert picture to thumbnail for database format--
               
                Connection myConn = new Connection();
                myConn.Open(Database.ConnectionString(databasePath, out errOut));
                Recordset rs = new Recordset();
                rs.Open("Gun_Collection_Pictures", myConn, CursorTypeEnum.adOpenStatic , LockTypeEnum.adLockPessimistic);
                rs.AddNew();
                rs.Fields["CID"].Value = id; 
                rs.Fields["PICTURE"].AppendChunk(buffer);
                rs.Fields["THUMB"].AppendChunk(bufferT);
                rs.Fields["ISMAIN"].Value = 1;
                rs.Fields["sync_lastupdate"].Value = DateTime.Now;
                rs.Update();
                rs.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("AddDefaultPic", e);
            }
            return bAns;
        }

        /// <summary>
        /// Saves the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="file">The file.</param>
        /// <param name="applicationPathData">The application path data.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Save(string databasePath, string file, string applicationPathData, long gunId,string name, string notes, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {

                FileStream st = new FileStream(file, FileMode.Open, FileAccess.Read);
                BinaryReader mbr = new BinaryReader(st);
                byte[] buffer = new byte[st.Length + 1];
                mbr.Read(buffer, 0, Convert.ToInt32(st.Length));
                st.Close();

                int intPicHeight = 64;
                int intPicWidth = 64;
                string sThumbName = $"{applicationPathData}\\mgc_thumb.jpg";

                Image myBitmap = Image.FromFile(file);
                Image.GetThumbnailImageAbort myPicCallback = null;
                Image myNewPic = myBitmap.GetThumbnailImage(intPicWidth, intPicHeight, myPicCallback, IntPtr.Zero);
                myBitmap.Dispose();
                File.Delete(sThumbName);
                myNewPic.Save(sThumbName, ImageFormat.Jpeg);
                myNewPic.Dispose();
                FileStream stT = new FileStream(sThumbName, FileMode.Open, FileAccess.Read);
                BinaryReader mbrT = new BinaryReader(stT);
                byte[] bufferT = new byte[stT.Length + 1];
                mbrT.Read(bufferT, 0, Convert.ToInt32(stT.Length));
                stT.Close();

                Connection conn = new Connection();
                conn.Open(Database.ConnectionString(databasePath, out errOut));
                Recordset rs = new Recordset();
                //TODO: #7 Finish Importing the picture function and figure out why the ADODB is glitching in c# or get the right format
                rs.Open("Gun_Collection_Pictures", conn, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic);
                rs.AddNew();
                rs.Fields["CID"].Value = gunId;
                rs.Fields["PICTURE"].AppendChunk(buffer);
                rs.Fields["THUMB"].AppendChunk(bufferT);
                rs.Fields["ISMAIN"].Value = IsFirstPic(databasePath, gunId, out errOut) ? 1 : 0;

                rs.Fields["pd_name"].Value = name;
                rs.Fields["pd_note"].Value = notes;
                rs.Fields["sync_lastupdate"].Value = DateTime.Now;
                rs.Update();
                rs.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Save", e);
            }

            return bAns;
        }
        /// <summary>
        /// Count all the pictures that are tied to a particular firearm
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="gunId"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public static long CountPics(string databasePath, long gunId, out string errOut)
        {
            long lAns = 0;
            errOut = @"";
            try
            {
                List<PictureDetails> lst = GetList(databasePath, gunId, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                lAns = lst.Count;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("CountPics", e);
            }
            return lAns;

        }

        /// <summary>
        /// Get all the data from teh tabl based on the firearm they are attached to.
        /// </summary>
        /// <param name="databasePath">full path and file name to the database</param>
        /// <param name="gunId">firearm id</param>
        /// <param name="errOut">exception message</param>
        /// <param name="isDetails">toggle if just the text is returned or all</param>
        /// <returns></returns>
        public static List<PictureDetails> GetList(string databasePath, long gunId, out string errOut, bool isDetails = false)
        {
            List<PictureDetails> lst = new List<PictureDetails>();
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Collection_Pictures where CID={gunId}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut, isDetails);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetList", e);
            }
            return lst;

        }

        /// <summary>
        /// Generate a list of the data returned from the datatable query relating to the pictures table.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="errOut"></param>
        /// <param name="isDetails"></param>
        /// <param name="dbPath"></param>
        /// <returns></returns>
        internal static List<PictureDetails> MyList(DataTable dt, out string errOut,bool isDetails = false, string dbPath = "")
        {
            List<PictureDetails> lst = new List<PictureDetails>();
            errOut = @"";
            try
            {
                BSOtherObjects obj = new BSOtherObjects();

                foreach (DataRow d in dt.Rows)
                {
                    if (!isDetails)
                    {
                        object oThumb = d["thumb"] != DBNull.Value ? d["thumb"] : "";
                        object oPic = d["Picture"] != DBNull.Value ? d["Picture"] : "";
                        Byte[] bThumb = Helpers.ObjectToByteArray(oThumb);
                        Byte[] bPic = Helpers.ObjectToByteArray(oPic);

                        MemoryStream thumbStream = new MemoryStream();
                        MemoryStream picStream = new MemoryStream();
                        if (bThumb.Length > 0)
                        {
                            thumbStream = new MemoryStream(bThumb, true);
                            thumbStream.Write(bThumb, 0, bThumb.Length);
                            thumbStream.Close();
                        }
                        if (bPic.Length > 0)
                        {
                            picStream = new MemoryStream(bPic, true);
                            picStream.Write(bPic, 0, bPic.Length);
                            picStream.Close();
                        }
                        lst.Add(new PictureDetails()
                        {
                            Id = Convert.ToInt32(d["id"] != DBNull.Value ? d["id"] : 0),
                            LastSyncDate = d["sync_lastupdate"] != DBNull.Value ? d["sync_lastupdate"].ToString().Trim() : "",
                            CollectionId = Convert.ToInt32(d["CID"] != DBNull.Value ? d["CID"] : 0),
                            Picture = oPic,
                            IsMain = obj.ConvertIntToBool(Convert.ToInt32(d["ISMAIN"] != DBNull.Value ? d["ISMAIN"] : 0)),
                            Thumb = oThumb,
                            PictureDisplayName = d["pd_name"] != DBNull.Value ? d["pd_name"].ToString().Trim() : "",
                            PictureNotes = d["pd_note"] != DBNull.Value ? d["pd_note"].ToString().Trim() : "",
                            ThumbMemoryStream = thumbStream,
                            PictureMemoryStream = picStream
                        });
                    }
                    else
                    {
                        lst.Add(new PictureDetails()
                        {
                            Id = Convert.ToInt32(d["id"] != DBNull.Value ? d["id"] : 0),
                            LastSyncDate = d["sync_lastupdate"] != DBNull.Value ? d["sync_lastupdate"].ToString().Trim() : "",
                            CollectionId = Convert.ToInt32(d["CID"] != DBNull.Value ? d["CID"] : 0),
                            IsMain = obj.ConvertIntToBool(Convert.ToInt32(d["ISMAIN"] != DBNull.Value ? d["ISMAIN"] : 0)),
                            PictureDisplayName = d["pd_name"] != DBNull.Value ? d["pd_name"].ToString().Trim() : "",
                            PictureNotes = d["pd_note"] != DBNull.Value ? d["pd_note"].ToString().Trim() : ""
                        });
                    }
                    
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("MyList", e);
            }
            return lst;
        }
        /// <summary>
        /// Updates the picture details.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="title">The title.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool UpdatePictureDetails(string databasePath, long id,string title, string notes, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"UPDATE Gun_Collection_Pictures set pd_name='{title}', pd_note='{notes}',sync_lastupdate=Now() where ID={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("UpdatePictureDetails", e);
            }
            return bAns;
        }
    }
}
