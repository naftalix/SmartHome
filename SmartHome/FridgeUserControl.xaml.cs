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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartHome
{
    /// <summary>
    /// Interaction logic for FridgeUserControl.xaml
    /// </summary>
    public partial class FridgeUserControl : UserControl
    {
        public FridgeUserControl()
        {
            InitializeComponent();
        }

        private void TempSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (TempSlider.Value < 10 && Power.IsChecked == true)
                TempText.Margin = new Thickness(62, 124, 314, 66);
            else if(Power.IsChecked == true)
                TempText.Margin = new Thickness(42, 124, 314, 66);

   
        }

        private void TempSlider_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (TempSlider.Value < 10 && Power.IsChecked == true)
                TempText.Margin = new Thickness(62, 124, 314, 66);
            else if (Power.IsChecked == true)
                TempText.Margin = new Thickness(42, 124, 314, 66);
        }
    }
}
