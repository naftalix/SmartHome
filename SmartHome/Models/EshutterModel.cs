using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;


namespace SmartHome
{
    ///Model of Electric-Shutter which expands this business entity and connects to Electric-Shutter's view model.
    ///In case of changes in the view, the function 'Update()' is called in order to connect with the lower layres that will update the Database.
    public class EshutterModel
    {
        private IBL bl;

        private EShutter eshutter {get; set;}

        public bool status
        {
            get { return eshutter.Status; }
            set
            {
                if (eshutter.Status != value)
                {
                    eshutter.Status = value; Update();
                }
            }
        }

        public int level
        {
            get { return eshutter.level; }
            set
            {
                if (eshutter.level != value)
                {
                    eshutter.level = value; Update();
                }
            }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="name">The name of the Shutter</param>
        public EshutterModel(object name)
        {
            bl = FactoryBL.getBL();
            eshutter = bl.GetEshutter(name);               
        }

        public void Update()
        {
            bl.UpdateEshutter(eshutter);
        }
    }
}
