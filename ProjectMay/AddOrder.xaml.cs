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
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();
            OrderPage.Source = new Uri("AddPurchase.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Switch(object sender, RoutedEventArgs e)
        {
            string page = (RbPurchase.IsChecked == true) ? "AddPurchase.xaml" : "AddSale.xaml";
            OrderPage.Source = new Uri(page, UriKind.RelativeOrAbsolute);
        }
    }
}
