

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class Linkers.Information from the linker table
    /// </summary>
    public class GeneralAccessoriesLinkers
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the Gun Id that it is attached to.
        /// </summary>
        /// <value>The gid.</value>
        public int Gid { get; set; }
        /// <summary>
        /// Gets or sets the General Accessory that is used.
        /// </summary>
        /// <value>The aid.</value>
        public int Aid { get; set; }
    }
}
