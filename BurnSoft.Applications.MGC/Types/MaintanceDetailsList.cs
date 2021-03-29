using System;

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class MaintanceDetailsList to store the information from the Maintance_Details table
    /// </summary>
    [Serializable]
    public class MaintanceDetailsList
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the gun identifier. in the table it is gid
        /// </summary>
        /// <value>The gun identifier.</value>
        public long GunId { get; set; }
        /// <summary>
        /// Gets or sets the plan identifier. is mpid in the table
        /// </summary>
        /// <value>The plan identifier.</value>
        public long PlanId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the operation start date. is OpDate in the table
        /// </summary>
        /// <value>The operation start date.</value>
        public string OperationStartDate { get; set; }
        /// <summary>
        /// Gets or sets the operation due date. is OpDueDate in the table
        /// </summary>
        /// <value>The operation due date.</value>
        public string OperationDueDate { get; set; }
        /// <summary>
        /// Gets or sets the rounds fired. is RndFired in the table
        /// </summary>
        /// <value>The rounds fired.</value>
        public long RoundsFired { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }
        /// <summary>
        /// Gets or sets the ammo used. is au in the table
        /// </summary>
        /// <value>The ammo used.</value>
        public string AmmoUsed { get; set; }
        /// <summary>
        /// Gets or sets the barrel system identifier. is bsid in the table
        /// </summary>
        /// <value>The barrel system identifier.</value>
        public long BarrelSystemId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [does count]. is dc in the table, this is used
        /// for to overall count of rounds fired
        /// </summary>
        /// <value><c>true</c> if [does count]; otherwise, <c>false</c>.</value>
        public bool DoesCount { get; set; }
        /// <summary>
        /// Gets or sets the last synchronize. is sync_lastupdate in the table.
        /// </summary>
        /// <value>The last synchronize.</value>
        public string LastSync { get; set; }

    }
}
