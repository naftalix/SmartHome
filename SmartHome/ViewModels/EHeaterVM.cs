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
    public class EHeaterVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private EHeaterModel eheaterModel;

        public EHeaterCommand ChangeEHeaterCommand { get; set; }

        public bool Status
        {
            get { return eheaterModel.status; }
            set
            {
                eheaterModel.status = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        public EHeaterVM()
        {
            eheaterModel = new  EHeaterModel();
            ChangeEHeaterCommand = new  EHeaterCommand();
        }
    }
}
