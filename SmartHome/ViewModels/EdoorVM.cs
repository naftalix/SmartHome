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
    public class EdoorVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private EdoorModel edoorModel;

        public EDoorCommand ChangeDoorCommand { get; set; }

        public bool Status
        {
            get { return edoorModel.status; }
            set
            {
                edoorModel.status = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
            }
        }
        public int Alarm
        {
            get { return edoorModel.alarm; }
            set
            {
                edoorModel.alarm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Alarm"));
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        public EdoorVM()
        {
            edoorModel = new EdoorModel();
            ChangeDoorCommand = new EDoorCommand();
        }
    }
}
