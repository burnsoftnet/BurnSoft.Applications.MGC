namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class AccessoriesList list container that will contain the information from the Gun_Collection_Accessories table.
    /// </summary>
    public class AccessoriesList
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the gun identifier.  This is gid in the table
        /// </summary>
        /// <value>The gun identifier.</value>
        public long GunId { get; set; }
        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public string Model { get; set; }
        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>The serial number.</value>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        /// <value>The condition.</value>
        public string Condition { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }
        /// <summary>
        /// Gets or sets the use.
        /// </summary>
        /// <value>The use.</value>
        public string Use { get; set; }
        /// <summary>
        /// Gets or sets the purchase value. Is PurValue in the table
        /// </summary>
        /// <value>The purchase value.</value>
        public string PurchaseValue { get; set; }
        /// <summary>
        /// Gets or sets the appriased value. Is AppValue in the table.
        /// </summary>
        /// <value>The appriased value.</value>
        public string AppriasedValue { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [count in value].  This is an interger value called CIV in the table
        /// </summary>
        /// <value><c>true</c> if [count in value]; otherwise, <c>false</c>.</value>
        public bool CountInValue { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is choke.  This is an interger value called IC in the table
        /// </summary>
        /// <value><c>true</c> if this instance is choke; otherwise, <c>false</c>.</value>
        public bool IsChoke { get; set; }
    }
}
