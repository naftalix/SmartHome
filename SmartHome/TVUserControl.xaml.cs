using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for TVUserControl.xaml
    /// </summary>
    public partial class TVUserControl : UserControl
    {
        int minvalue = 0,
            maxvalue = 100,
            startvalue = 10;
        string tempChannel;
        double tempVol;
        public TVUserControl()
        {
            InitializeComponent();

        }

        public void func(string tempChannel, double tempVol)
        {
            this.tempChannel = tempChannel;
            this.tempVol = tempVol;
        }
        private void VolSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Double value = VolSlider.Value;
            VolText.Margin = new Thickness(329, 885 - value * 9.4, 100, 120 + value * 9.4);
        }

        private void TVOn_Checked(object sender, RoutedEventArgs e)
        {

            //-----------------------
            NUDTextBox.Text = tempChannel;
            //-----------------------
            VolSlider.Value = tempVol;                   

        }

        private void TVOn_Unchecked(object sender, RoutedEventArgs e)
        {

            //-----------------------
            tempVol =  VolSlider.Value;
            VolSlider.Value = 0;
            //-----------------------
            //-----------------------
            tempChannel = NUDTextBox.Text;
            NUDTextBox.Text = "";
            //-----------------------
        }

        private void NUDButtonUP_Click(object sender, RoutedEventArgs e)
        {

            NUDButtonDown.IsEnabled = true;
            int number;
            if (NUDTextBox.Text != "") number = Convert.ToInt32(NUDTextBox.Text);
            else number = 0;
            if (number < maxvalue)
                NUDTextBox.Text = Convert.ToString(number + 1);

            BindingExpression be = NUDTextBox.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }

        private void NUDButtonDown_Click(object sender, RoutedEventArgs e)
        {
            int number = Convert.ToInt32(NUDTextBox.Text);
            if (number < 2)
                NUDButtonDown.IsEnabled = false;
            else
            {              
                if (NUDTextBox.Text != "") number = Convert.ToInt32(NUDTextBox.Text);
                else number = 0;
                if (number > minvalue)
                    NUDTextBox.Text = Convert.ToString(number - 1);
            }
         
            BindingExpression be = NUDTextBox.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }

        private void NUDTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Up)
            {
                NUDButtonUP.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonUP, new object[] { true });
            }


            if (e.Key == Key.Down)
            {
                NUDButtonDown.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonDown, new object[] { true });
            }
        }

        private void NUDTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonUP, new object[] { false });

            if (e.Key == Key.Down)
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonDown, new object[] { false });
        }

        private void NUDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int number = 0;
            if (NUDTextBox.Text != "")
                if (!int.TryParse(NUDTextBox.Text, out number)) NUDTextBox.Text = startvalue.ToString();
            if (number > maxvalue) NUDTextBox.Text = maxvalue.ToString();
            if (number < minvalue) NUDTextBox.Text = minvalue.ToString();
            NUDTextBox.SelectionStart = NUDTextBox.Text.Length;
            

        }


    }
}
