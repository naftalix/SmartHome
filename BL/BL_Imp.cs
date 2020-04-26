using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public class BL_Imp : IBL
    {
        /// <summary>
        /// Link between the layers of BL to DAL
        /// </summary>
        IDal dal;
        /// <summary>
        /// Constructor
        /// </summary>
        public BL_Imp()
        {
            dal = FactoryDal.getDal();
        }

        ///  All functions of Get and Update transfer the requests to the DAL layer without logic
        public AC GetAC()
        {
            return dal.GetAC();
        }

        public void UpdateAC(AC ac)
        {
            dal.UpdateAC(ac);
        }

        public EDoor GetEdoor()
        {  
            return dal.GetEdoor();
        }

        public void UpdateEdoor(EDoor edoor)
        {
            dal.UpdateEdoor(edoor);
        }

        public EHeater GetEheater()
        {
            return dal.GetEheater();
        }
 
        public void UpdateEheater(EHeater eheater)
        {
            dal.UpdateEheater(eheater);
        }

        public EShutter GetEshutter(object name)
        {
            return dal.GetEshutter(name);
        }

        public void UpdateEshutter(EShutter eshutter)
        {
            dal.UpdateEshutter(eshutter);
        }
        public Fridge GetFridge()
        {
            return dal.GetFridge();
        }

        public void UpdateFridge(Fridge fridge)
        {
            dal.UpdateFridge(fridge);    
        }

        public Lamp GetLamp(string name)
        {
            return dal.GetLamp(name);
        }

        public void UpdateLamp(Lamp lamp)
        {
            dal.UpdateLamp(lamp);
        }

        public TV GetTV()
        { 
            return dal.GetTV();
        }

        public void UpdateTV(TV tv)
        {
            dal.UpdateTV(tv);
        }
        public List<Log> GetLog(DateTime start, DateTime end, string deviceName)
        {
            return dal.GetLog(start, end, deviceName);
        }

    }
}
