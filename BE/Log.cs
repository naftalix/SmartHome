using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BE
{
   /// <summary>
    /// This class represents a change in the status of a device
   /// </summary>
    public class Log
    {
        [Key]
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
    }
}
