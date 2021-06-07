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
using System.Windows.Shapes;

namespace ProjectMay
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            LblInfo.Content = (Global.Username + " (" + Global.Role + ")");
        }

        private void BtnDataManager_Click(object sender, RoutedEventArgs e)
        {
            DataManager mngr = new DataManager();
            mngr.Show();
        }

        private void BtnOverview_Click(object sender, RoutedEventArgs e)
        {
            Overview view = new Overview();
            view.Show();
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderManager om = new OrderManager();
            om.Show();
        }
    }
}
