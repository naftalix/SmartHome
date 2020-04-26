using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;


namespace SmartHome
{
    ///Model of Air conditioner which expands this business entity and connects to AC's view model.
    ///In case of changes in the view, the function 'Update()' is called in order to connect with the lower layres that will update the Database.
    public class ACModel
    {
        private IBL bl;
        private AC ac { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        public ACModel()
        {
            bl = FactoryBL.getBL();
            ac = bl.GetAC();


        }
        
        public bool status
        {
            get { return ac.Status; }
            set
            {
                if (ac.Status != value)
                {
                    ac.Status = value; Update();
                }
            }
        }

        public int temperature
        {
            get { return ac.Temperature; }
            set
            {
                if (ac.Temperature != value)
                {
                    ac.Temperature = value; Update();
                }
            }
        }

        public int airFlow
        {
            get { return ac.AirFlow; }
            set
            {
                if (ac.AirFlow != value)
                {
                    ac.AirFlow = value; Update();
                }
            }
        }


        public void Update()
        {
            bl.UpdateAC(ac);

        
        }
    }
}
