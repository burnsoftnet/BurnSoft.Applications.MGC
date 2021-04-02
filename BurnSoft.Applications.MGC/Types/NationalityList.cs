using System;

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class NationalityList. Container for the results in the Gun_Nationality table
    /// </summary>
    [Serializable]
    public class NationalityList
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the name. Is called Country in the table
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
