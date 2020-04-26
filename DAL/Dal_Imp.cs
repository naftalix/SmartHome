using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    /// <summary>
    /// Realization of the DAL layer by a Database of SQL Entity Framework
    /// </summary>
    public class Dal_Imp : IDal
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Dal_Imp()
        {
            using (var db = new AContext())
            {
                /// Here we build the tables of the database for the first time, 
                /// which is designed to give the various devices their default condition
                if (!db.Aces.Any())
                    InitAcDatatbase();
                if (!db.EDoors.Any())
                    InitEDoorsDatatbase();
                if (!db.EHeaters.Any())
                    InitEHeaterDatatbase();
                if (!db.EShutters.Any())
                    InitEShutterDatatbase();
                if (!db.Fridges.Any())
                    InitFridgeDatatbase();
                if (!db.Lamps.Any())
                    InitLampDatatbase();
                if (!db.TVs.Any())
                    InitTvDatatbase();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------Init area-----------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Initialize the table of 'Air-Conditioner' for the first time with the default status
        /// </summary>
        void InitAcDatatbase()
        {
            using (var db = new AContext())
            {
                var ac = new AC { Name = "Air-Conditioner", Status = false, Temperature = 18, AirFlow = 2 };
                db.Aces.Add(ac);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Initialize the table of 'Electric-Door' for the first time with the default status
        /// </summary>
        void InitEDoorsDatatbase()
        {
            using (var db = new AContext())
            {
                var edoor = new EDoor { Name = "Electric-Door", Status = false, Alarm = 5 };
                db.EDoors.Add(edoor);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Initialize the table of 'Electric-Heater' for the first time with the default status
        /// </summary>
        void InitEHeaterDatatbase()
        {
            using (var db = new AContext())
            {
                var eheater = new EHeater { Name = "Electric-Heater", Status = false };
                db.EHeaters.Add(eheater);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Initialize the table of 'Electric-shutter' for the first time with the default status
        /// </summary>
        void InitEShutterDatatbase()
        {
            using (var db = new AContext())
            {
                var eshutter = new EShutter { Name = "Electric shutter first floor", Status = false, level = 1 };
                db.EShutters.Add(eshutter);
                eshutter = new EShutter { Name = "Electric shutter second floor", Status = false, level = 1 };
                db.EShutters.Add(eshutter);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Initialize the table of 'Fridge' for the first time with the default status
        /// </summary>
        void InitFridgeDatatbase()
        {
            using (var db = new AContext())
            {
                var fridge = new Fridge { Name = "Fridge", Status = false, Temperature = 4 };
                db.Fridges.Add(fridge);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Initialize the table of 'Lights' for the first time with the default status of all four lights
        /// </summary>
        void InitLampDatatbase()
        {
            using (var db = new AContext())
            {
                var lamp = new Lamp { Name = "Lobby-Light", Status = false };
                db.Lamps.Add(lamp);
                lamp = new Lamp { Name = "BedRoom-Light", Status = false };
                db.Lamps.Add(lamp);
                lamp = new Lamp { Name = "Saloon-Light", Status = false };
                db.Lamps.Add(lamp);
                lamp = new Lamp { Name = "Kitchen-Light", Status = false };
                db.Lamps.Add(lamp);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Initialize the table of 'TV' for the first time with the default status
        /// </summary>
        void InitTvDatatbase()
        {
            using (var db = new AContext())
            {
                var tv = new TV { Name = "TV", Status = false, Volume = 10, Channel = 1 };
                db.TVs.Add(tv);
                db.SaveChanges();
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------Get and Update area-----------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------

        //----------------------------------------------Air-Conditioner-----------------------------------------------------------
        /// <summary>
        /// This function performs a query on the table in the database 
        /// in order to get the status of the Air-Conditioner
        /// </summary>
        /// <returns>The current status of the Air-Conditioner</returns>
        public AC GetAC()
        {
            using (var db = new AContext())
            {
                return db.Aces.FirstOrDefault();
            }
        }
        /// <summary>
        /// This function updates the table in the database with the status of the Air-Conditioner
        /// In addition we add to the log table the info of the operation that was done
        /// </summary>
        /// <param name="ac">The entity of Air-Conditioner</param>
        public void UpdateAC(AC ac)
        {
            using (var db = new AContext())
            {
                AC temp = db.Aces.FirstOrDefault();
                string str = (ac.Status == true ? "on" : "off");
                Log log = new Log { Date = DateTime.Now, DeviceName = ac.Name, Action = string.Format("At {0}, the Air Conditioner is turned {1,-3}", DateTime.Now, str) };
                if (ac.Status == true)
                    log.Action += string.Format(", the temperature is {0,3}°C, the Aeration intensity is set to level {1}", ac.Temperature, ac.AirFlow);
                db.Logs.Add(log);
                db.Entry(temp).CurrentValues.SetValues(ac);
                db.SaveChanges();
            }
        }
        //----------------------------------------------Electric-Door-----------------------------------------------------------
        /// <summary>
        /// This function performs a query on the table in the database 
        /// in order to get the status of the Electric-Door
        /// </summary>
        /// <returns>The current status of the Electric-Door</returns>
        public EDoor GetEdoor()
        {
            using (var db = new AContext())
            {          
                return db.EDoors.FirstOrDefault();
            }
        }
        /// <summary>
        /// This function updates the table in the database with the status of the Electric-Door
        /// In addition we add to the log table the info of the operation that was done
        /// </summary>
        /// <param name="edoor">The entity of Electric-Door</param>
        public void UpdateEdoor(EDoor edoor)
        {
            using (var db = new AContext())
            {
                EDoor temp = db.EDoors.FirstOrDefault();
                string str = (edoor.Status == true ? "opened" : "closed");
                Log log = new Log { Date = DateTime.Now, DeviceName = edoor.Name, Action = string.Format("At {0}, the Electric door is {1}, the Alarm is set for {2} minutes", DateTime.Now, str, edoor.Alarm) };
                db.Logs.Add(log);
                db.Entry(temp).CurrentValues.SetValues(edoor);
                db.SaveChanges();
            }
        }
        //----------------------------------------------Electric-Eheater-----------------------------------------------------------
        /// <summary>
        /// This function performs a query on the table in the database 
        /// in order to get the status of the Electric-Eheater
        /// </summary>
        /// <returns>The current status of the Electric-Eheater</returns>
        public EHeater GetEheater()
        {
            using (var db = new AContext())
            {
                return db.EHeaters.FirstOrDefault();
            }
        }
        /// <summary>
        /// This function updates the table in the database with the status of the Electric-Eheater
        /// In addition we add to the log table the info of the operation that was done
        /// </summary>
        /// <param name="eheater">The entity of Electric-Eheater</param>
        public void UpdateEheater(EHeater eheater)
        {
            using (var db = new AContext())
            {
                EHeater temp = db.EHeaters.FirstOrDefault();
                string str = (eheater.Status == true ? "on" : "off");
                Log log = new Log { Date = DateTime.Now, DeviceName = eheater.Name, Action = string.Format("At {0}, the heater was turned {1}", DateTime.Now, str) };
                db.Logs.Add(log);
                db.Entry(temp).CurrentValues.SetValues(eheater);
                db.SaveChanges();
            }
        }
        //----------------------------------------------Electric-Shutter-----------------------------------------------------------
        /// <summary>
        /// This function performs a query on the table in the database 
        /// in order to get the status of the requested Electric-Shutter
        /// </summary>
        /// <param name="name">name of the Shutter</param>
        /// <returns>The current status of the Electric-Shutter</returns>
        public EShutter GetEshutter(object name)
        {
            using (var db = new AContext())
            {
                return db.EShutters.Where(x => x.Name == (string)name).FirstOrDefault();
            }
        }
        /// <summary>
        /// This function updates the table in the database with the status of a specific shutter
        /// In addition we add to the log table the info of the operation that was done
        /// </summary>
        /// <param name="eshutter">An entity of Electric-Shutter</param>
        public void UpdateEshutter(EShutter eshutter)
        {
            using (var db = new AContext())
            {
                EShutter temp = db.EShutters.Where(x => x.Name == eshutter.Name).FirstOrDefault();
                //-------------------------------------------------------------------------
                string str = (eshutter.Status == true ? "opened" : "closed");
                Log log = new Log { Date = DateTime.Now, DeviceName = eshutter.Name, Action = string.Format("At {0}, the Electric shutter is {1}", DateTime.Now, str) };
                if (eshutter.Status == true)
                    log.Action += string.Format(" on level {0}", eshutter.level);
                db.Logs.Add(log);
                //-----------------------------------------------------------------------------
                db.Entry(temp).CurrentValues.SetValues(eshutter);
                db.SaveChanges();
            }
        }
        //----------------------------------------------Fridge-----------------------------------------------------------
        /// <summary>
        /// This function performs a query on the table in the database 
        /// in order to get the status of the Fridge
        /// </summary>
        /// <returns>The current status of the Fridge</returns>
        public Fridge GetFridge()
        {
            using (var db = new AContext())
            {
                return db.Fridges.FirstOrDefault();
            }
        }
        /// <summary>
        /// This function updates the table in the database with the status of the Fridge
        /// In addition we add to the log table the info of the operation that was done
        /// </summary>
        /// <param name="fridge">The entity of Fridge</param>
        public void UpdateFridge(Fridge fridge)
        {
            using (var db = new AContext())
            {
                Fridge temp = db.Fridges.FirstOrDefault();
                string str = (fridge.Status == true ? "opened" : "closed");
                Log log = new Log { Date = DateTime.Now, DeviceName = fridge.Name, Action = string.Format("At {0}, the Fridge is {1,-6}, the temperature is {2,3}°C", DateTime.Now, str, fridge.Temperature) };
                db.Logs.Add(log);
                db.Entry(temp).CurrentValues.SetValues(fridge);
                db.SaveChanges();
            }
        }
        //----------------------------------------------Lights-----------------------------------------------------------
        /// <summary>
        /// This function performs a query on the table in the database 
        /// in order to get the status of the requested light
        /// </summary>
        /// <param name="name">name of the light</param>
        /// <returns>The current status of the light</returns>
        public Lamp GetLamp(string name)
        {
            using (var db = new AContext())
            {
                return db.Lamps.Where(x => x.Name == name).FirstOrDefault();
            }
        }
        /// <summary>
        /// This function updates the table in the database with the status of a specific light
        /// In addition we add to the log table the info of the operation that was done
        /// </summary>
        /// <param name="lamp">An entity of light</param>
        public void UpdateLamp(Lamp lamp)
        {
            using (var db = new AContext())
            {
                Lamp temp = db.Lamps.Where(x => x.Name == lamp.Name).FirstOrDefault();
                string str = (lamp.Status == true ? "on" : "off");
                Log log = new Log { Date = DateTime.Now, DeviceName = lamp.Name, Action = string.Format("At {0}, the light was turned {1}", DateTime.Now, str) };
                db.Logs.Add(log);
                db.Entry(temp).CurrentValues.SetValues(lamp);
                db.SaveChanges();
            }
        }
        //----------------------------------------------Fridge-----------------------------------------------------------
        /// <summary>
        /// This function performs a query on the table in the database 
        /// in order to get the status of the TV
        /// </summary>
        /// <returns>The current status of the TV</returns>
        public TV GetTV()
        {
            using (var db = new AContext())
            {
                return db.TVs.FirstOrDefault();
            }
        }
        /// <summary>
        /// This function updates the table in the database with the status of the TV
        /// In addition we add to the log table the info of the operation that was done
        /// </summary>
        /// <param name="tv">The entity of TV</param>
        public void UpdateTV(TV tv)
        {
            using (var db = new AContext())
            {
                TV temp = db.TVs.FirstOrDefault();
                string str = (tv.Status == true ? "on" : "off");
                Log log = new Log { Date = DateTime.Now, DeviceName = tv.Name, Action = string.Format("At {0}, the TV is turned {1,-3}", DateTime.Now, str) };
                if (tv.Status == true)
                    log.Action += string.Format(", the channel is set to {0,3} and the volume is set to {1}", tv.Channel, tv.Volume);
                db.Logs.Add(log);
                db.Entry(temp).CurrentValues.SetValues(tv);
                db.SaveChanges();
            }
        }
        //----------------------------------------------LOG (Action)-----------------------------------------------------------
        /// <summary>
        ///  This function is designed to get information about the history of the activities on various devices
        /// </summary>
        /// <param name="start">The time from which the search will start</param>
        /// <param name="end">The time in which the search ends</param>
        /// <param name="name">The name of the device</param>
        /// <returns>A List of actions that have been done on the device</returns>
        public List<Log> GetLog(DateTime start, DateTime end, string deviceName)
        {
            using (var db = new AContext())
            {
                List<Log> Llog = (from x in db.Logs
                                  where x.DeviceName == deviceName && x.Date >= start && x.Date <= end
                                  select x).ToList();
                return Llog;
            }
        }
    }
}