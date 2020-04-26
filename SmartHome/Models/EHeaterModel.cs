using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;



namespace SmartHome
{
    ///Model of Electric-Heater which expands this business entity and connects to Electric-Heater's view model.
    ///In case of changes in the view, the function 'Update()' is called in order to connect with the lower layres that will update the Database.
    public class EHeaterModel
    {
        private IBL bl;

        private EHeater eheater {get; set;}

        public bool status
        {
            get { return eheater.Status; }
            set
            {
                if (eheater.Status != value)
                {
                    eheater.Status = value; Update();
                }
            }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public EHeaterModel()
        {
            bl = FactoryBL.getBL();
            eheater = bl.GetEheater();
               
        }

        public void Update()
        {
            bl.UpdateEheater(eheater);

        }
    }
}
