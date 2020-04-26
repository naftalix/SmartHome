using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;


namespace SmartHome
{
    ///Model of TV which expands this business entity and connects to TV's view model.
    ///In case of changes in the view, the function 'Update()' is called in order to connect with the lower layres that will update the Database.
    public class TVModel
    {
        private IBL bl;
        private TV tv { get; set; }

        public bool status
        {
            get { return tv.Status; }
            set
            {
                if (tv.Status != value)
                {
                    tv.Status = value; Update();
                }
            }
        }

        public int channel
        {
            get { return tv.Channel; }
            set
            {
                if (tv.Channel != value)
                {
                    tv.Channel = value; Update();
                }
            }
        }

        public int volume
        {
            get { return tv.Volume; }
            set
            {
                if (tv.Volume != value)
                {
                    tv.Volume = value; Update();
                }
            }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public TVModel()
        {
            bl = FactoryBL.getBL();
            tv = bl.GetTV();
               
        }

        public void Update()
        {
            bl.UpdateTV(tv);

        }
    }
    
}
