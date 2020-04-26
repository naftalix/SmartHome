using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// This base class Inherits to all devices this three fildes
    /// </summary>
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }

}
