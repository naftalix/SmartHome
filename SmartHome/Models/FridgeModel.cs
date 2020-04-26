using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;


namespace SmartHome
{
    ///Model of Fridge which expands this business entity and connects to Fridge's view model.
    ///In case of changes in the view, the function 'Update()' is called in order to connect with the lower layres that will update the Database.
    public class FridgeModel
    {
         private IBL bl;

        private Fridge fridge {get; set;}

        public bool status
        {
            get { return fridge.Status; }
            set
            {
                if (fridge.Status != value)
                {
                    fridge.Status = value; Update();
                }
            }
        }

        public int temperature
        {
            get { return fridge.Temperature; }
            set
            {
                if (fridge.Temperature != value)
                {
                    fridge.Temperature = value; Update();
                }
            }

        }

        /// <summary>
        /// Ctor
        /// </summary>
        public FridgeModel()
        {
            bl = FactoryBL.getBL();
            fridge = bl.GetFridge();
               
        }

        public void Update()
        {
            bl.UpdateFridge(fridge);

        }
    }
}
