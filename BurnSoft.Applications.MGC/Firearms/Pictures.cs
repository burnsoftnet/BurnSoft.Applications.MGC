using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ADODB;

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
        private static string ClassLocation = "BurnSoft.Applications.MGC.Firearms.Pictures";
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
        /// Determines whether the firearm ( collection id ) already has a default picture set or not
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if [is first pic] [the specified database path]; otherwise, <c>false</c>.</returns>
        /// <exception cref="Exception"></exception>
        public static bool IsFirstPic(string databasePath, string collectionId, out string errOut)
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

        public static bool Save(string databasePath, string file, string ApplicationPathData, long gunId,string name, string notes, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {

                FileStream st = new FileStream(file, FileMode.Open, FileAccess.Read);
                BinaryReader mbr = new BinaryReader(st);
                byte[] buffer = new byte[st.Length + 1];
                mbr.Read(buffer, 0, System.Convert.ToInt32(st.Length));
                st.Close();

                int intPicHeight = 64;
                int intPicWidth = 64;
                string sThumbName = $"{ApplicationPathData}\\mgc_thumb.jpg";

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
                //rs.Open("Gun_Collection_Pictures", conn, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic);
                //rs.AddNew();
                //rs("CID").Value = gunId;
                //rs("PICTURE").AppendChunk(buffer);
                //rs("THUMB").AppendChunk(bufferT);
                //if (IsFirstPic(databasePath, gunId.ToString(), out errOut))
                //{
                //    rs("ISMAIN").Value = 1;
                //}
                //else
                //{
                //    rs("ISMAIN").Value = 0;
                //}

                //rs("pd_name").Value = name;
                //rs("pd_note").Value = notes;
                //rs("sync_lastupdate").Value = DateTime.Now;
                //rs.Update();
                //rs.Close();
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Save", e);
            }

            return bAns;
        }
    }
}
