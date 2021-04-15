

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class TableLists.  List container for data from the CR_TableList table.
    /// </summary>
    public class TableLists
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the tables.
        /// </summary>
        /// <value>The tables.</value>
        public string Tables { get; set; }
        /// <summary>
        /// Gets or sets the display name.  Called DN in the table
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; set; }
    }
}
