using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Applications.MGC.hotixes.types
{
    public class DbColumns
    {
        public int HotFixId { get; set; }
        public string Column { get; set; }
        public string Table { get; set; }
        public string Value { get; set; }
    }
}
