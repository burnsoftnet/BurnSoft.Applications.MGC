// ReSharper disable UnusedMember.Global

namespace BurnSoft.Applications.MGC.ThirdParty
{
    /// <summary>
    /// Class Ammunition quick ref functions foro third party
    /// </summary>
    public class Ammunition
    {
        /// <summary>
        /// Ammoes the is already listed.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="name">The name.</param>
        /// <param name="cal">The cal.</param>
        /// <param name="grain">The grain.</param>
        /// <param name="jacket">The jacket.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="mid">The mid.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool AmmoIsAlreadyListed(string databasePath, string manufacturer, string name, string cal,
            string grain, string jacket, out long qty, out long mid, out string errOut)
        {
            return Ammo.Inventory.AmmoIsAlreadyListed(databasePath, manufacturer, name, cal, grain, jacket, out qty, out mid,
                out errOut);
        }
    }
}
