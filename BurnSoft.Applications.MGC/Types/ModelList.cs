
namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class ModelList which will contain all the information gathered form the Gun_Model table
    /// </summary>
    public class ModelList
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the manufacturer identifier.  This is GMID in the tabl
        /// </summary>
        /// <value>The manufacturer identifier.</value>
        public long ManufacturerId { get; set; }
        /// <summary>
        /// Gets or sets the name. Is field is Model in the table.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the last synchronize. This is sync_lastupdate in the table.
        /// </summary>
        /// <value>The last synchronize.</value>
        public string LastSync { get; set; }
    }
}
