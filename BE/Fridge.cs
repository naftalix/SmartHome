using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// This class represents an entity of a Fridge
    /// </summary>
    public class Fridge:Device
    {
        public int Temperature { get; set; }
    }
}
