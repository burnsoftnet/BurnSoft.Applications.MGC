using System;

namespace BurnSoft.Applications.MGC.hotixes.types
{
    /// <summary>
    /// Class DbAddData.
    /// </summary>
    class DbAddData
    {
        /// <summary>
        /// Gets or sets the hot fix identifier.
        /// </summary>
        /// <value>The hot fix identifier.</value>
        public int HotFixId { get; set; }
        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        /// <value>The column.</value>
        public string Column { get; set; }
        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>The table.</value>
        public string Table { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
    }
}
