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
    /// Interaction logic for Overview.xaml
    /// </summary>
    public partial class Overview : Window
    {
        public Overview()
        {
            InitializeComponent();
        }
        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            Manager.Source = new Uri("UserOverview.xaml", UriKind.RelativeOrAbsolute);
            BtnUsers.Background = new SolidColorBrush(Colors.Aquamarine);
            BtnProducts.Background = default;
            BtnCustomers.Background = default;
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            Manager.Source = new Uri("ProductOverview.xaml", UriKind.RelativeOrAbsolute);
            BtnUsers.Background = default;
            BtnProducts.Background = new SolidColorBrush(Colors.Aquamarine);
            BtnCustomers.Background = default;
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            Manager.Source = new Uri("CustomerOverview.xaml", UriKind.RelativeOrAbsolute);
            BtnUsers.Background = default;
            BtnProducts.Background = default;
            BtnCustomers.Background = new SolidColorBrush(Colors.Aquamarine);
        }

    }
}
