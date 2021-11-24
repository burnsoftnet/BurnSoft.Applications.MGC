using System;

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class DocumentLinkList. Container for the doc link table.
    /// </summary>
    [Serializable]
    public class DocumentLinkList
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the gun identifier. GID in the Table
        /// </summary>
        /// <value>The gun identifier.</value>
        public long GunId { get; set; }
        /// <summary>
        /// Gets or sets the document identifier. DID in the table
        /// </summary>
        /// <value>The document identifier.</value>
        public long DocId { get; set; }
        /// <summary>
        /// Gets or sets the dta.
        /// </summary>
        /// <value>The dta.</value>
        public string Dta { get; set; }
        /// <summary>
        /// Gets or sets the last synchronize. sync_lastupdate in the table
        /// </summary>
        /// <value>The last synchronize.</value>
        public string LastSync { get; set; }
    }
}
