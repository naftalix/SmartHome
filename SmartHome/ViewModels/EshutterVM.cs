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
    public class EshutterVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private EshutterModel eshutterModel;

        public ShuttersCommand ChangeShuttersCommand { get; set; }

        public bool Status
        {
            get { return eshutterModel.status; }
            set
            {
                eshutterModel.status = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
            }
        }
        public int Level
        {
            get { return eshutterModel.level; }
            set
            {
                eshutterModel.level = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Level"));
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="name"></param>
        public EshutterVM(object name)
        {
            eshutterModel = new  EshutterModel(name);
            ChangeShuttersCommand = new ShuttersCommand();
        }
    }
}
