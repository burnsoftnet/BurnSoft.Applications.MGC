
namespace BurnSoft.Applications.MGC.hotixes.types
{
    /// <summary>
    /// Class HotFixList to hold the hotfixes that have been installed
    /// </summary>
    public class HotFixList
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the date installed.
        /// </summary>
        /// <value>The date installed.</value>
        public string DateInstalled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [was from install].
        /// </summary>
        /// <value><c>true</c> if [was from install]; otherwise, <c>false</c>.</value>
        public bool WasFromInstall { get; set; }
    }
}
