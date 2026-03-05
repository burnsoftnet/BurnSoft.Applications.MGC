using BurnSoft.Applications.MGC.Global;


namespace BurnSoft.Applications.MGC.LoadersLog
{
    /// <summary>
    /// Class RegistryHelpers Pointer to halp the My Loaders Log use the MyRegistry Class Functions that it uses
    /// </summary>
    public class RegistryHelpers
    {
        /// <summary>
        /// Gets the MGC executable path.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <param name="sDefault">The s default.</param>
        /// <returns>System.String.</returns>
        public static string GetMgcExePath(out string errOut, string sDefault = "") => 
            MyRegistry.GetMgcExePath(out errOut, sDefault);

        /// <summary>
        /// Gets the MGC database path.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <param name="sDefault">The s default.</param>
        /// <returns>System.String.</returns>
        public static string GetMGCPath(out string errOut, string sDefault = "") => 
            MyRegistry.GetDatabaseLocation(out errOut, sDefault);
        /// <summary>
        /// Mies the gun collection is installed.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool MyGunCollectionIsInstalled(out string errOut) => 
            MyRegistry.MyGunCollectionIsInstalled(out errOut);
    }
}
