using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace SmartHome
{
    ///Model of Lamp which expands this business entity and connects to Lamp's view model.
    ///In case of changes in the view, the function 'Update()' is called in order to connect with the lower layres that will update the Database.
    public class LampModel
    {

        private IBL bl;
        private Lamp lamp { get; set; }
        public bool status {
            get { return lamp.Status; }
            set { lamp.Status = value; Update(); }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="name">String of the name of a specific lamp</param>
        public LampModel(string name)
        {
            bl = FactoryBL.getBL();

            lamp = bl.GetLamp(name);
            
        }

        public void Update()
        {
            bl.UpdateLamp(lamp);
        }
    }
}
