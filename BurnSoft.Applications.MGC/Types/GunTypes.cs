using System;

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class GunTypes.
    /// </summary>
    [Serializable]
    public class GunTypes
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the name whihc is labeled as Type in the database.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the last synchronize.
        /// </summary>
        /// <value>The last synchronize.</value>
        public string LastSync { get; set; }
    }
}
