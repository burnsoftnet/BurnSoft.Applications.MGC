using System;

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class MaintancePlans to hold the information from the Maintance_Plans table
    /// </summary>
    [Serializable]
    public class MaintancePlansList
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the operation details. is od in the table
        /// </summary>
        /// <value>The operation details.</value>
        public string OperationDetails { get; set; }
        /// <summary>
        /// Gets or sets the intervals in days. iid in table
        /// </summary>
        /// <value>The intervals in days.</value>
        public string IntervalsInDays { get; set; }
        /// <summary>
        /// Gets or sets the interval in rounds fired. is iirf in table
        /// </summary>
        /// <value>The interval in rounds fired.</value>
        public string IntervalInRoundsFired { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }
        /// <summary>
        /// Gets or sets the last synchronize. sync_lastupdate in table
        /// </summary>
        /// <value>The last synchronize.</value>
        public string LastSync { get; set; }

    }
}
