using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class ColumnLists list container for the CR_ColumnList table.
    /// </summary>
    public class ColumnLists
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the table identifier. This is TID in the table
        /// </summary>
        /// <value>The table identifier.</value>
        public long TableId { get; set; }
        /// <summary>
        /// Gets or sets the column. This is Col in the table
        /// </summary>
        /// <value>The column.</value>
        public string Column { get; set; }
        /// <summary>
        /// Gets or sets the display name. This is DN in the table
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; set; }
    }
}
