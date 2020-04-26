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
    public class TVVM:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private TVModel tvModel;

        public TVCommand ChangeTVCommand { get; set; }

        public bool Status
        {
            get { return tvModel.status; }
            set
            {
                tvModel.status = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
            }
        }
        public int Channel
        {
            get { return tvModel.channel; }
            set
            {
                tvModel.channel = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Channel"));
            }
        }

        public int Volume
        {
            get { return tvModel.volume; }
            set
            {
                tvModel.volume = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Volume"));
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        public TVVM()
        {
            tvModel = new TVModel();
            ChangeTVCommand = new TVCommand();
        }
        
    }
    
}
