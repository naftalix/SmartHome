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
    public class ACVM :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ACModel acModel;

        public ACCommand ChangeACCommand { get; set; }

        public bool Status
        {
            get { return acModel.status; }
            set
            {
                acModel.status = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
            }
        }
        public int Temperature
        {
            get { return acModel.temperature; }
            set
            {
                acModel.temperature = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Temperature"));
            }
        }

        public int AirFlow
        {
            get { return acModel.airFlow; }
            set
            {
                acModel.airFlow = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("AirFlow"));
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        public ACVM()
        {
            acModel = new ACModel();
            ChangeACCommand = new ACCommand();
        }
        
    }
}