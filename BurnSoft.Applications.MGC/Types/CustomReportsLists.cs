
namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class CustomReportsLists.  List container for the CR_SavedReports table.
    /// </summary>
    public class CustomReportsLists
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the report.
        /// </summary>
        /// <value>The name of the report.</value>
        public string ReportName { get; set; }
        /// <summary>
        /// Gets or sets the SQL. Is Called MySQL in the table
        /// </summary>
        /// <value>The SQL.</value>
        public string Sql { get; set; }
        /// <summary>
        /// Gets or sets the date added.  Is called dt in the table
        /// </summary>
        /// <value>The date added.</value>
        public string DateAdded { get; set; }
        /// <summary>
        /// Gets or sets the last synchronize.  sync_lastupdate in the table
        /// </summary>
        /// <value>The last synchronize.</value>
        public string LastSync { get; set; }
    }
}
