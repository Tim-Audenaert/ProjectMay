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
    /// Interaction logic for DataManager.xaml
    /// </summary>
    public partial class DataManager : Window
    {
        public DataManager()
        {
            InitializeComponent();
            
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            Manager.Navigate(new Uri("UserManager.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
