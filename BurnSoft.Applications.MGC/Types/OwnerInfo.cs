using System;
#pragma warning disable 1570

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class OwnerInfo.  List container for the Owner_Ino Table
    /// </summary>
    [Serializable]
    public class OwnerInfo
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        public string ZipCode { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the CCDWL. This can also be used for FFl or driver license, how ever you want to set it or C&R license
        /// </summary>
        /// <value>The CCDWL.</value>
        public string Ccdwl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use password]. NUmeric value in database canned UsePWD
        /// </summary>
        /// <value><c>true</c> if [use password]; otherwise, <c>false</c>.</value>
        public bool UsePassword { get; set; }
        /// <summary>
        /// Gets or sets the password. PWD in database
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the name of the user. UID in database
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the forgot word.  forgot_word in database
        /// </summary>
        /// <value>The forgot word.</value>
        public string ForgotWord { get; set; }
        /// <summary>
        /// Gets or sets the forgot phrase. forgot_phrase in database
        /// </summary>
        /// <value>The forgot phrase.</value>
        public string ForgotPhrase { get; set; }
        /// <summary>
        /// Gets or sets the last synchronize. sync_lastupdate in database
        /// </summary>
        /// <value>The last synchronize.</value>
        public string LastSync { get; set; }
    }
}
