using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BurnSoft.Applications.MGC.Global;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Universal;
// ReSharper disable MustUseReturnValue

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
        /// The file filter list
        /// </summary>
        public static string FileFilterList = "Bmp Files(*.bmp)|*.bmp|Gif Files(*.gif)|*.gif|Jpg Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png";
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
        /// <param name="applicationPath"></param>
        /// <param name="defaultPic"></param>
        /// <param name="errOut">The error out.</param>
        /// <param name="addPic">if set to <c>true</c> [add pic].</param>
        /// <returns><c>true</c> if [has default picture] [the specified database path]; otherwise, <c>false</c>.</returns>
        public static bool HasDefaultPicture(string databasePath, long id, string applicationPath, string defaultPic,out string errOut, bool addPic = false)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Collection_Pictures where CID={id} and IsMain=1";
                bAns = Database.DataExists(databasePath, sql, out errOut);
                if (!bAns && addPic) if(!AddDefaultPic(databasePath, id, applicationPath, defaultPic, out errOut)) throw  new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("HasDefaultPicture", e);
            }
            return bAns;
        }
        /// <summary>
        /// Determines whether [has default picture] [the specified database path].
        /// </summary>
        /// <param name="databasePath">The Database Path</param>
        /// <param name="id">The id of the Accessory that you want to work with</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        public static bool HasDefaultPicture(string databasePath, long id, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Collection_Pictures where CID={id} and IsMain=1";
                bAns = Database.DataExists(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("HasDefaultPicture", e);
            }
            return bAns;
        }
        /// <summary>
        /// Gets the first picture in collection. This replaces the the GetMainPictureFirstListing in the hotfix application
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int32.</returns>
        public static int GetFirstPictureInCollection(string databasePath, long id, out string errOut)
        {
            int lAns = 0;
            errOut = "";
            try
            {
                string sql = $"SELECT TOP 1 ID FROM Gun_Collection_Pictures where CID={id} order by ID ASC";
                lAns = Database.GetIDFromTableBasedOnTSQL(databasePath, sql,"ID" ,out errOut);
            }
            catch (Exception exception)
            {
                errOut = ErrorMessage("GetFirstPictureInCollection", exception);
            }
            return lAns;
        }
        /// <summary>
        /// HOTFIX - If there is no default picture set but collection has pictures, then set the first picture as the default picture
        /// </summary>
        /// <param name="databasePath">The Database Path</param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <returns></returns>
        public static bool SetMainPictures(string databasePath, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string sql = "SELECT DISTINCT(Gun_Collection_Pictures.CID) as CID FROM Gun_Collection_Pictures";
                OleDbConnection conn = new OleDbConnection(Database.ConnectionStringOle(databasePath, out errOut));
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);

                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    { 
                        var cid = (Int32)dr.GetValue(dr.GetOrdinal("cid"));
                        if (!HasDefaultPicture(databasePath, cid, out errOut))
                        {
                            var lid = GetFirstPictureInCollection(databasePath, cid, out errOut);
                            if (lid > 0)
                            {
                                if (!SetAsDefaultPic(databasePath, lid, out errOut)) throw new Exception(errOut);
                            }
                        }
                    }
                }

                conn.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SetMainPictures", e);
            }
            return bAns;
        }
        /// <summary>
        /// Sets as default pic.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool SetAsDefaultPic(string databasePath, long id, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string sql = $"UPDATE Gun_Collection_Pictures set ISMAIN=1 where ID={id}";
                if (!Database.Execute(databasePath, sql, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SetAsdefaultPic", e);
            }
            return bAns;
        }
        /// <summary>
        /// Resets the default pic.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool ResetDefaultPic(string databasePath, long collectionId, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string sql = $"UPDATE Gun_Collection_Pictures set ISMAIN=0 where CID={collectionId}";
                if (!Database.Execute(databasePath, sql, out errOut)) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("ResetDefaultPic", e);
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
        /// <param name="applicationPath"></param>
        /// <param name="defaultPic"></param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool AddDefaultPic(string databasePath, long id,string applicationPath, string defaultPic, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                if (!Save(databasePath, defaultPic, applicationPath, id, " ", " ", out errOut, true))
                    throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("AddDefaultPic", e);
            }
            return bAns;
        }

        /// <summary>
        /// Save a gun picture to the database, this function will convert this picture 
        /// into a thumbnail and upload the orginal picture and the thumbnail
        /// to the database, you can also add a name and notes to it.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="file">The file.</param>
        /// <param name="applicationPathData">The application path data.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="setAsDefault"></param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Save(string databasePath, string file, string applicationPathData, 
            long gunId,string name, string notes, out string errOut, bool setAsDefault = false)
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

                OleDbConnection myConn = new OleDbConnection(Database.ConnectionStringOle(databasePath, out errOut));

                int iMain = 0;
                if (setAsDefault)
                {
                    iMain = 1;
                }
                else
                {
                    iMain = IsFirstPic(databasePath, gunId, out errOut) ? 1 : 0;
                }
                
                string sql = "INSERT INTO Gun_Collection_Pictures(CID, PICTURE, THUMB, ISMAIN,sync_lastupdate,pd_name,pd_note) " +
                             "VALUES(@CID,@PICTURE,@THUMB,@ISMAIN,Now(),@pd_name,@pd_note)";
                OleDbCommand cmd = new OleDbCommand(sql);

                cmd.Parameters.AddWithValue("CID", gunId);
                cmd.Parameters.AddWithValue("PICTURE", buffer);
                cmd.Parameters.AddWithValue("THUMB", bufferT);
                cmd.Parameters.AddWithValue("ISMAIN", iMain);
                cmd.Parameters.AddWithValue("pd_name", name);
                cmd.Parameters.AddWithValue("pd_note", notes);

                myConn.Open();
                cmd.Connection = myConn;
                cmd.ExecuteNonQuery();

                bAns = true;
                myConn.Close();
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Save", e);
            }

            return bAns;
        }

        /// <summary>
        /// Save a gun picture to the database, this function will convert this picture 
        /// into a thumbnail and upload the orginal picture and the thumbnail
        /// to the database, you can also add a name and notes to it.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="file">The file.</param>
        /// <param name="applicationPathData">The application path data.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="picOrder">The Picture Order</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="setAsDefault"></param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Save(string databasePath, string file, string applicationPathData, 
            long gunId, string name, string notes, int picOrder, out string errOut, 
            bool setAsDefault = false)
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

                OleDbConnection myConn = new OleDbConnection(Database.ConnectionStringOle(databasePath, out errOut));

                int iMain = 0;
                if (setAsDefault)
                {
                    iMain = 1;
                }
                else
                {
                    iMain = IsFirstPic(databasePath, gunId, out errOut) ? 1 : 0;
                }

                string sql = "INSERT INTO Gun_Collection_Pictures(CID, PICTURE, THUMB, ISMAIN,sync_lastupdate,pd_name,pd_note, PicOrder) " +
                             "VALUES(@CID,@PICTURE,@THUMB,@ISMAIN,Now(),@pd_name,@pd_note,@PicOrder)";
                OleDbCommand cmd = new OleDbCommand(sql);

                cmd.Parameters.AddWithValue("CID", gunId);
                cmd.Parameters.AddWithValue("PICTURE", buffer);
                cmd.Parameters.AddWithValue("THUMB", bufferT);
                cmd.Parameters.AddWithValue("ISMAIN", iMain);
                cmd.Parameters.AddWithValue("pd_name", name);
                cmd.Parameters.AddWithValue("pd_note", notes);
                cmd.Parameters.AddWithValue("PicOrder", picOrder);

                myConn.Open();
                cmd.Connection = myConn;
                cmd.ExecuteNonQuery();

                bAns = true;
                myConn.Close();
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
        /// <param name="databasePath">The Database Path</param>
        /// <param name="gunId"></param>
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
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
        /// <param name="id">firearm id/ or picture id if set to direct = true</param>
        /// <param name="errOut">exception message</param>
        /// <param name="isDetails">toggle if just the text is returned or all</param>
        /// <param name="isDirect">change the sql from looking up the gun id and look up the direct id instead</param>
        /// <param name="formPictureBox"></param>
        /// <returns></returns>
        public static List<PictureDetails> GetList(string databasePath, long id, out string errOut, bool isDetails = true, bool isDirect = false, PictureBox formPictureBox = null)
        {
            List<PictureDetails> lst = new List<PictureDetails>();
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Collection_Pictures where CID={id}";
                if (isDirect) sql = $"SELECT * from Gun_Collection_Pictures where ID={id}";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut, isDetails,"", formPictureBox);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetList", e);
            }
            return lst;

        }

        /// <summary>
        /// Get all the data from the picture table.
        /// </summary>
        /// <param name="databasePath">full path and file name to the database</param>
        /// <param name="errOut">exception message</param>
        /// <param name="isDetails">toggle if just the text is returned or all</param>
        /// <param name="formPictureBox"></param>
        /// <returns></returns>
        public static List<PictureDetails> GetList(string databasePath, out string errOut, bool isDetails = true, PictureBox formPictureBox = null)
        {
            List<PictureDetails> lst = new List<PictureDetails>();
            errOut = @"";
            try
            {
                string sql = $"SELECT * from Gun_Collection_Pictures";
                DataTable dt = Database.GetDataFromTable(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                lst = MyList(dt, out errOut, isDetails, "", formPictureBox);
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
        /// <param name="errOut">If an exception occurs the message will be in this string</param>
        /// <param name="isDetails"></param>
        /// <param name="dbPath"></param>
        /// <param name="formPictureBox"></param>
        /// <returns></returns>
        internal static List<PictureDetails> MyList(DataTable dt, out string errOut,bool isDetails = false, string dbPath = "", PictureBox formPictureBox = null)
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
                        Bitmap tBmp = null;
                        Bitmap bmp = null;

                        if (bThumb.Length > 0)
                        {
                            thumbStream = new MemoryStream(bThumb, true);
                            thumbStream.Write(bThumb, 0, bThumb.Length);
                            if (formPictureBox != null)
                            {
                                Image imgT = new Bitmap(thumbStream);
                                Size imgTSize = ProportionalSize(imgT.Size, formPictureBox.Size);
                                Bitmap newTimg = new Bitmap(imgTSize.Width, imgTSize.Height);
                                Graphics g = Graphics.FromImage(newTimg);
                                g.DrawImage(imgT, 0,0, imgTSize.Width, imgTSize.Height);
                                tBmp = newTimg;
                            }
                            thumbStream.Close();
                        }
                        if (bPic.Length > 0)
                        {
                            picStream = new MemoryStream(bPic, true);
                            picStream.Write(bPic, 0, bPic.Length);
                            if (formPictureBox != null)
                            {
                                Image imgT = new Bitmap(picStream);
                                Size imgTSize = ProportionalSize(imgT.Size, formPictureBox.Size);
                                Bitmap newTimg = new Bitmap(imgTSize.Width, imgTSize.Height);
                                Graphics g = Graphics.FromImage(newTimg);
                                g.DrawImage(imgT, 0, 0, imgTSize.Width, imgTSize.Height);
                                bmp = newTimg;
                            }
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
                            PictureMemoryStream = picStream,
                            ThumbBmp = tBmp,
                            PictureBmp = bmp,
                            PicOrder = Convert.ToInt32(d["PicOrder"] != DBNull.Value ? d["PicOrder"] : 0)
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
                            PictureNotes = d["pd_note"] != DBNull.Value ? d["pd_note"].ToString().Trim() : "",
                            PicOrder = Convert.ToInt32(d["PicOrder"] != DBNull.Value ? d["PicOrder"] : 0)
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
        /// Proportionals the size. Calculate the Proportional Size of an Image by passing the image size and the MaxSize or Height of the image
        ///  to return the new size.  The Max Width and Height is the parameters of the container
        /// </summary>
        /// <param name="imageSize">Size of the image.</param>
        /// <param name="maxWMaxH">The maximum w maximum h.</param>
        /// <returns>System.Drawing.Size.</returns>
        public static Size ProportionalSize(Size imageSize, Size maxWMaxH)
        {
            double multBy = 1.01;
            double w = imageSize.Width;
            double h = imageSize.Height;

            while ((w < maxWMaxH.Width & h < maxWMaxH.Height))
            {
                w = imageSize.Width * multBy;
                h = imageSize.Height * multBy;
                multBy = multBy + 0.001;
            }

            while ((w > maxWMaxH.Width | h > maxWMaxH.Height))
            {
                multBy = multBy - 0.001;
                w = imageSize.Width * multBy;
                h = imageSize.Height * multBy;
            }

            if ((imageSize.Width < 1))
                imageSize = new Size(imageSize.Width - imageSize.Width + 1, imageSize.Height - imageSize.Width - 1);
            else if ((imageSize.Height < 1))
                imageSize = new Size(imageSize.Width - imageSize.Height - 1, imageSize.Height - imageSize.Height + 1);
            imageSize = new Size(Convert.ToInt32(w), Convert.ToInt32(h));
            return imageSize;
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

        /// <summary>
        /// Updates the picture details.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="title">The title.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="picOrder">The Picture Order</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool UpdatePictureDetails(string databasePath, long id, string title, 
            string notes, int picOrder, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"UPDATE Gun_Collection_Pictures set pd_name='{title}', pd_note='{notes}', PicOrder={picOrder} sync_lastupdate=Now() where ID={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("UpdatePictureDetails", e);
            }
            return bAns;
        }
        /// <summary>
        /// Sets the picture order.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The Firearm identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool SetPictureOrder(string databasePath, long id, int orderId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"UPDATE Gun_Collection_Pictures set PicOrder={orderId} ,sync_lastupdate=Now() where ID={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SetPictureOrder", e);
            }
            return bAns;
        }
        /// <summary>
        /// Gets the next order number.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="firearmId">The firearm identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int32.</returns>
        public static int GetNextOrderNumber(string databasePath, long firearmId, out string errOut)
        {
            int iAns = 0;
            errOut = "";
            try
            {
                List<PictureDetails> lst = new List<PictureDetails>();
                lst = GetList(databasePath, firearmId, out errOut);
                int maxOrder = lst.Max(i => i.PicOrder);
                iAns = maxOrder + 1;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetNextOrderNumber", e);
            }
            return iAns;
        }

        /// <summary>
        /// Gets the last picture that was added for that collection
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="firearmId">The firearm identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Int32 the id of the picture in the database</returns>
        public static int GetLastPicture(string databasePath, long firearmId, out string errOut)
        {
            int iAns = 0;
            errOut = "";
            try
            {
                List<PictureDetails> lst = new List<PictureDetails>();
                lst = GetList(databasePath, firearmId, out errOut);
                int maxOrder = lst.Max(i => i.Id);
                iAns = maxOrder;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetLastPicture", e);
            }
            return iAns;
        }


        /// <summary>
        /// Gets the pcture.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>Object.</returns>
        /// <exception cref="System.Exception"></exception>
        public static Object GetPicture(string databasePath, int id, out string errOut)
        {
            Object oAns = null;
            errOut = "";
            try
            {
                Database obj = new Database();

                if (obj.ConnectDb(Database.ConnectionString(databasePath, out errOut), out errOut))
                {
                    string sql = $"SELECT PICTURE from Gun_Collection_Pictures where ID={id}";
                    OdbcCommand cmd = new OdbcCommand(sql, obj._conn);
                    oAns = cmd.ExecuteScalar();
                    cmd.Connection.Close();
                    obj._conn = null;
                }
                else
                {
                    throw new Exception(errOut);
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetPicture", e);
            }
            return oAns;
        }
        /// <summary>
        /// Gets the thumbnail picture.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>Object.</returns>
        /// <exception cref="System.Exception"></exception>
        public static Object GetThumbnailPicture(string databasePath, int id, out string errOut)
        {
            Object oAns = null;
            errOut = "";
            try
            {
                Database obj = new Database();

                if (obj.ConnectDb(Database.ConnectionString(databasePath, out errOut), out errOut))
                {
                    string sql = $"SELECT THUMB from Gun_Collection_Pictures where ID={id}";
                    OdbcCommand cmd = new OdbcCommand(sql, obj._conn);
                    oAns = cmd.ExecuteScalar();
                    cmd.Connection.Close();
                    obj._conn = null;
                }
                else
                {
                    throw new Exception(errOut);
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetThumbnailPicture", e);
            }
            return oAns;
        }
        /// <summary>
        /// Resets the pictures order for a particular firearm collection
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="firearmId">The firearm identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool ResetPictures(string databasePath, long firearmId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"Update Gun_Collection_Pictures set PicOrder=0 where CID={firearmId}";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("ResetPictures", e);
            }
            return bAns;
        }

        /// <summary>
        /// Resets the pictures for all the collection in the table.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool ResetPictures(string databasePath, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"Update Gun_Collection_Pictures set PicOrder=0";
                bAns = Database.Execute(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("ResetPictures", e);
            }
            return bAns;
        }

    }
}
