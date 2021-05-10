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
            if (Global.Role == "Admin")
            {
                BtnUserManager.Visibility = Visibility.Visible;
                BtnUserManager.IsEnabled = true;
            }
        }

        private void BtnDataManager_Click(object sender, RoutedEventArgs e)
        {
            DataManager mngr = new DataManager();
            mngr.Show();
        }
    }
}
