using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Applications.MGC.Global
{
    /// <summary>
    /// Class Helpers.
    /// </summary>
    public class Helpers
    {
        /// <summary>
        /// Formats from XML.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string FormatFromXML(string value)
        {
            string sAns = value.Replace("&amp;", "&");
            sAns = sAns.Replace("'", "''");
            return sAns;
        }

    }
}
