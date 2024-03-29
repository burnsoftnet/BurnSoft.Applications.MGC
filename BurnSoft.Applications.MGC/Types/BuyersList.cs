﻿
using System;

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class SolToList.  List container for the Gun_Collection_SoldTo table
    /// </summary>
    [Serializable]
    public class BuyersList
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address1.
        /// </summary>
        /// <value>The address1.</value>
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the address2.
        /// </summary>
        /// <value>The address2.</value>
        public string Address2 { get; set; }

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
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>The fax.</value>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the lic.
        /// </summary>
        /// <value>The lic.</value>
        public string Lic { get; set; }

        /// <summary>
        /// Gets or sets the web site.
        /// </summary>
        /// <value>The web site.</value>
        public string WebSite { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        public string ZipCode { get; set; }
        /// <summary>
        /// Gets or sets the dlic.  Drivers license for person to person sale
        /// </summary>
        /// <value>The dlic.</value>
        public string Dlic { get; set; }
        /// <summary>
        /// Gets or sets the Date of birth of the buyer
        /// </summary>
        /// <value>The dob.</value>
        public string Dob { get; set; }
        /// <summary>
        /// Gets or sets the resident is resident or business
        /// </summary>
        /// <value>The resident.</value>
        public string Resident { get; set; }
        /// <summary>
        /// Gets or sets the synchronize lastupdate ro sync_lastupdate in the database
        /// </summary>
        /// <value>The synchronize lastupdate.</value>
        public string SyncLastupdate { get; set; }
    }
}
