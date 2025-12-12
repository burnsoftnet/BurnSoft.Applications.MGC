using System;
using System.Drawing;
using System.IO;

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class PictureDetails.  Picture Container for the data that is stored in the Gun_Collection_Pictures table.
    /// </summary>
    [Serializable]
    public class PictureDetails
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the collection identifier.  Also known as the CID in the table
        /// </summary>
        /// <value>The collection identifier.</value>
        public int CollectionId { get; set; }
        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        /// <value>The picture.</value>
        public object Picture { get; set; }
        /// <summary>
        /// Gets or sets the picture MemoryStream.
        /// </summary>
        /// <value>The picture ms.</value>
        public MemoryStream PictureMemoryStream { get; set; }
        /// <summary>
        /// Gets or sets the picture BMP.
        /// </summary>
        /// <value>The picture BMP.</value>
        public Bitmap PictureBmp { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is main.
        /// </summary>
        /// <value><c>true</c> if this instance is main; otherwise, <c>false</c>.</value>
        public bool IsMain { get; set; }
        /// <summary>
        /// Gets or sets the thumb.
        /// </summary>
        /// <value>The thumb.</value>
        public object Thumb { get; set; }
        /// <summary>
        /// Gets or sets the thumb memory stream.
        /// </summary>
        /// <value>The thumb memory stream.</value>
        public MemoryStream ThumbMemoryStream { get; set; }
        /// <summary>
        /// Gets or sets the thumb BMP.
        /// </summary>
        /// <value>The thumb BMP.</value>
        public Bitmap ThumbBmp { get; set; }
        /// <summary>
        /// Gets or sets the display name of the picture.  This is also known as pd_name
        /// </summary>
        /// <value>The display name of the picture.</value>
        public string PictureDisplayName { get; set; }
        /// <summary>
        /// Gets or sets the picture notes.  This is also known as pd_note
        /// </summary>
        /// <value>The picture notes.</value>
        public string PictureNotes { get; set; }
        /// <summary>
        /// Gets or sets the last synchronize date. This is also known as sync_lastupdate
        /// </summary>
        /// <value>The last synchronize date.</value>
        public string LastSyncDate { get; set; }
        /// <summary>
        /// Gets or sets the pic order.
        /// </summary>
        /// <value>The pic order.</value>
        public int PicOrder { get; set; }
    }
}
