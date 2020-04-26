using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartHome
{
    ///View Model which connects to the entity model and makes the connection between View layer and Model layer.
    ///In case of changes in the Lamp element it updates the bounded properties here (which are in his Data Context). 
    ///Duo to the interface "I Notify Property Changed" changes occured in Model are updated in the bounded view element.
    public class LampVM:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private LampModel LampModel;
        private string imageUrl;

        /// <summary>
        /// The Command operates every time the button is clicked
        /// </summary>
        public LightCommand ChangeLampCommand { get; set; }


        /// <summary>
        /// Image for lamp conditions. it's not part of the Lamp entity it affects only the view.
        /// </summary>
        public string ImageUrl 
        { 
            get { return imageUrl; }
            set 
            {
                imageUrl = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ImageUrl"));
            }
        }

        public bool Status 
        {
            get { return LampModel.status; }
            set 
            {
                LampModel.status = value;
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="name">Name of the specific Lamp</param>
        public LampVM(string name)
        {
            LampModel = new LampModel(name);

            if(LampModel.status == false)
                 ImageUrl = "Images/lampOff.png";
            else
                ImageUrl = "Images/lampOn.png";

            ChangeLampCommand = new LightCommand();
        }

    }
}
