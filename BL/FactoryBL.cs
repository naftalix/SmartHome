using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// Here we determine with which realization of the BL layer we work with
    /// </summary>
    public class FactoryBL
    {
        static IBL bl;
        public static IBL getBL()
        {
            if (bl == null)
                bl = new BL_Imp();
            return bl;
        }
    }
}
