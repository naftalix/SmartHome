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
using Xceed.Wpf.Toolkit;
using BL;
using BE;


namespace SmartHome
{
    /// <summary>
    /// Interaction logic for HistoryInfoUserControl.xaml
    /// </summary>
    public partial class HistoryInfoUserControl : UserControl
    {
        private IBL bl;
        public HistoryInfoUserControl()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Info.IsReadOnly = false;
            Info.Text = "";
            DateTime from = DateFrom.Value.Value;
            DateTime to = DateTo.Value.Value;
            string Dname = SelectDevice.Text;

            List<Log> Logs = bl.GetLog(from, to, Dname);
            int i = 1;
            foreach (Log l in Logs)
            {
                Info.Text += i + ". " + l.Action + Environment.NewLine + Environment.NewLine;
                i++;
            }
            Info.IsReadOnly = true;
        }
    }
}
