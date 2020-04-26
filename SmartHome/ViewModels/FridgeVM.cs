using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    ///View Model which connects to the entity model and makes the connection between View layer and Model layer.
    ///In case of changes in the Lamp element it updates the bounded properties here (which are in his Data Context). 
    ///Duo to the interface "I Notify Property Changed" changes occured in Model are updated in the bounded view element.
    public class FridgeVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private FridgeModel fridgeModel;

        public FridgeCommand ChangeFridgeCommand { get; set; }

        public bool Status
        {
            get { return fridgeModel.status; }
            set
            {
                fridgeModel.status = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
            }
        }
        public int Temperature
        {
            get { return fridgeModel.temperature; }
            set
            {
                fridgeModel.temperature = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Temperature"));
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        public FridgeVM()
        {
            fridgeModel = new FridgeModel();
            ChangeFridgeCommand = new FridgeCommand();
        }
    }
}
