using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Applications.MGC.Types
{
    /// <summary>
    /// Class MaintanceDetailsList to store the information from the Maintance_Details table
    /// </summary>
    [Serializable]
    public class MaintanceDetailsList
    {
        public long Id { get; set; }
        public long GunId { get; set; }
        public long PlanId { get; set; }

    }
}
