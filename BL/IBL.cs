using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    /// <summary>
    /// the interface is basically a contract with which anyone who implements the BL hase to stick to it
    /// </summary>
    public interface IBL
    {
        /// <summary>
        ///  Air-Conditioner
        /// </summary>
        AC GetAC();
        void UpdateAC(AC ac);

        /// <summary>
        ///  Electric-Door
        /// </summary>
        EDoor GetEdoor();
        void UpdateEdoor(EDoor edoor);

        /// <summary>
        ///  Electric-Eheater
        /// </summary>
        EHeater GetEheater();
        void UpdateEheater(EHeater eheater);

        /// <summary>
        ///  Electric-Shutter
        /// </summary>
        EShutter GetEshutter(object name);
        void UpdateEshutter(EShutter eshutter);

        /// <summary>
        ///  Fridge
        /// </summary>
        Fridge GetFridge();
        void UpdateFridge(Fridge fridge);

        /// <summary>
        ///  Lights
        /// </summary>
        Lamp GetLamp(string name);
        void UpdateLamp(Lamp lamp);

        /// <summary>
        ///  TV
        /// </summary>
        TV GetTV();
        void UpdateTV(TV tv);


        /// <summary>
        ///  This function is designed to get information about the history of the activities on various devices
        /// </summary>
        List<Log> GetLog(DateTime start, DateTime end, string name);
    }
}