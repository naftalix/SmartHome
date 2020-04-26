using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// This class represents an entity of a air conditioner
    /// </summary>
    public class AC:Device
    {
        public int Temperature { get; set; }
        public int AirFlow { get; set; }
    }
}
