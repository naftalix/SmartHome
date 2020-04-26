using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;


namespace SmartHome
{
    ///Model of Electric-Door which expands this business entity and connects to Electric-Door's view model.
    ///In case of changes in the view, the function 'Update()' is called in order to connect with the lower layres that will update the Database.
    public class EdoorModel
    {
        private IBL bl;

        private EDoor edoor {get; set;}

        public bool status
        {
            get { return edoor.Status; }
            set
            {
                if (edoor.Status != value)
                {
                    edoor.Status = value; Update();
                }
            }
        }

        public int alarm
        {
            get { return edoor.Alarm; }
            set
            {
                if (edoor.Alarm != value)
                {
                    edoor.Alarm = value; Update();
                }
            }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public EdoorModel()
        {
            bl = FactoryBL.getBL();
            edoor = bl.GetEdoor();
               
        }

        public void Update()
        {
            bl.UpdateEdoor(edoor);

        }

    }
}
