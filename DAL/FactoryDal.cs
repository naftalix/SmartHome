using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Here we determine with which realization of the DAL layer we work with
    /// </summary>
    public class FactoryDal
    {
        static IDal dal;
        public static IDal getDal()
        {
            if (dal == null)
                dal = new Dal_Imp();
            return dal;
        }
    }
}
