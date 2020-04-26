using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartHome
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IBL bl;

        /// <summary>
        /// Instances of all the 'VM' classes
        /// </summary>
        public ACVM acVM { get; set; }
        public EdoorVM edoorVM { get; set; }
        public EHeaterVM eheaterVM { get; set; }
        public EshutterVM eshutterVM1 { get; set; }
        public EshutterVM eshutterVM2 { get; set; }
        public FridgeVM fridgeVM { get; set; }
        public LampVM BedRoomLightVm { get; set; }
        public LampVM KitchenLightVm { get; set; }
        public LampVM LobbyLightVm { get; set; }
        public LampVM SaloonLightVm { get; set; }
        public TVVM tvVM { get; set; }

        /// <summary>
        /// Instances of commands
        /// </summary>
        public TVCommand ChangeTVCommand { get; set; }
        public InfoCommand ShowInfoCommand { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            ///Here we Init the BL that will be used throughout the program
            bl = FactoryBL.getBL();

            InitializeComponent();

            ///Inits the 4 'VM' Lamps
            LobbyLightVm = new LampVM("Lobby-Light");
            BedRoomLightVm = new LampVM("BedRoom-Light");
            SaloonLightVm = new LampVM("Saloon-Light");
            KitchenLightVm = new LampVM("Kitchen-Light");


            ///Registrats the function 'ChangeLampCondition' to the event that will be called from the -
            ///command in the case of clicking the button of the a light
            LobbyLightVm.ChangeLampCommand.LampStatus += ChangeLampCondition;
            BedRoomLightVm.ChangeLampCommand.LampStatus += ChangeLampCondition;
            SaloonLightVm.ChangeLampCommand.LampStatus += ChangeLampCondition;
            KitchenLightVm.ChangeLampCommand.LampStatus += ChangeLampCondition;


            ///sets the 'DataContext' of each button of a light to the matching 'VM' instance
            LobbyLight.DataContext = LobbyLightVm;
            BedRoomLight.DataContext = BedRoomLightVm;
            SaloonLight.DataContext = SaloonLightVm;
            KitchenLight.DataContext = KitchenLightVm;


            ///Inits the 'VM' of air conditioner, registrats the function 'ChangeACCondition' to the event of 'Command' -
            ///and sets the 'DataContext' of the button and user control of the air conditioner to the matching 'VM' instance
            acVM = new ACVM();
            acVM.ChangeACCommand.ACStatus += ChangeACCondition;
            AC.DataContext = acVM;
            ACTemplate.DataContext = acVM;


            ///Inits the 'VM' of Electric-Door, registrats the function 'ChangeDoorCondition' to the event of 'Command' -
            ///and sets the 'DataContext' of the button and user control of the Electric-Door to the matching 'VM' instance
            edoorVM = new EdoorVM();
            edoorVM.ChangeDoorCommand.DoorStatus += ChangeDoorCondition;
            Edoor.DataContext = edoorVM;
            EdoorTemplate.DataContext = edoorVM;


            ///Inits the 'VM' of Electric-Heater, registrats the function 'ChangeEheaterCondition' to the event of 'Command' -
            ///and sets the 'DataContext' of the button and user control of the Electric-Heater to the matching 'VM' instance
            eheaterVM = new EHeaterVM();
            eheaterVM.ChangeEHeaterCommand.EHeaterStatus += ChangeEheaterCondition;
            EHeater.DataContext = eheaterVM;
            EHeaterTemplate.DataContext = eheaterVM;


            ///Inits the 'VM' of the 2 Electric-Shutters, registrats the function 'ChangeShuttersCondition' to the event of 'Command' -
            ///and sets the 'DataContext' of the buttons and user controls of the Electric-Shutters to the matching 'VM' instances
            eshutterVM1 = new EshutterVM("Electric shutter first floor");
            eshutterVM2 = new EshutterVM("Electric shutter second floor");
            eshutterVM1.ChangeShuttersCommand.ESStatus += ChangeShuttersCondition;
            eshutterVM2.ChangeShuttersCommand.ESStatus += ChangeShuttersCondition;
            Eshutters1.DataContext = eshutterVM1;
            Eshutters2.DataContext = eshutterVM2;
            EshuttersTemplate1.DataContext = eshutterVM1;
            EshuttersTemplate2.DataContext = eshutterVM2;


            ///Inits the 'VM' of Fridge, registrats the function 'ChangeFridgeCondition' to the event of 'Command' -
            ///and sets the 'DataContext' of the button and user control of the Fridge to the matching 'VM' instance
            fridgeVM = new FridgeVM();
            fridgeVM.ChangeFridgeCommand.FridgeStatus += ChangeFridgeCondition;
            Fridge.DataContext = fridgeVM;
            FridgeTemplate.DataContext = fridgeVM;


            ///Inits the 'VM' of TV, registrats the function 'ChangeTVCondition' to the event of 'Command' -
            ///and sets the 'DataContext' of the button and user control of the TV to the matching 'VM' instance
            tvVM = new TVVM();
            tvVM.ChangeTVCommand.TVStatus += ChangeTVCondition;
            TV.DataContext = tvVM;
            TVTemplate.DataContext = tvVM;


            //Inits the Info instance, registrats the function 'ShowInfoCondition' to the event of 'Command' -
            ///and sets the 'DataContext' of the button to this window 
            ShowInfoCommand = new InfoCommand();
            HistoryInfo.DataContext = this;
            ShowInfoCommand.InfoStatus += ShowInfoCondition;            
        }

        private void ShowInfoCondition(object obj)
        {
            ((Storyboard)FindResource("StartVisible")).Begin(HistoryInfoTemplate);
            HistoryInfoTemplate.Info.Text = "";
            HistoryInfoTemplate.SelectDevice.SelectedIndex = -1;
            HistoryInfoTemplate.SelectDevice.Text = "Select Device";
        }

        private void ChangeEheaterCondition(object obj)
        {
            ((Storyboard)FindResource("StartVisible")).Begin(EHeaterTemplate);
        }

        private void ChangeTVCondition(object obj)
        {
            ((Storyboard)FindResource("StartVisible")).Begin(TVTemplate);
            if (TVTemplate.TVOn.IsChecked == false && TVTemplate.NUDTextBox.Text != "")
            {
                string channel = TVTemplate.NUDTextBox.Text;
                TVTemplate.func(channel, TVTemplate.VolSlider.Value);
                TVTemplate.NUDTextBox.Text = "";
                TVTemplate.VolSlider.Value = 0;
            }
        }

        public void ChangeACCondition(object name)
        {
            ((Storyboard)FindResource("StartVisible")).Begin(ACTemplate);
        }

        public void ChangeShuttersCondition(object name)
        {
            string ESname = name.ToString();
            if (ESname == "Eshutters1")
                   ((Storyboard)FindResource("StartVisible")).Begin(EshuttersTemplate1);
            else
                   ((Storyboard)FindResource("StartVisible")).Begin(EshuttersTemplate2);
        }

        public void ChangeFridgeCondition(object name)
        {
                  ((Storyboard)FindResource("StartVisible")).Begin(FridgeTemplate);
        }

        public void ChangeDoorCondition(object name)
        {
            ((Storyboard)FindResource("StartVisible")).Begin(EdoorTemplate);
        }
        
        public void ChangeLampCondition(object name)
        {
            LampVM temp;

            switch (name.ToString())
            {
                case "LobbyLight":
                    temp = LobbyLightVm;
                    break;

                case "BedRoomLight":
                    temp = BedRoomLightVm;
                    break;

                case "SaloonLight":
                    temp = SaloonLightVm;
                    break;

                case "KitchenLight":
                    temp = KitchenLightVm;
                    break;

                default:
                    temp = null;
                    break;
            }

            if (temp != null)
            {
                if (temp.ImageUrl == "Images/lampOff.png")
                {
                    temp.ImageUrl = "Images/lampOn.png";
                    temp.Status = true;
                }
                else
                {
                    temp.ImageUrl = "Images/lampOff.png";
                    temp.Status = false;
                }
            }
        }
    }
}
