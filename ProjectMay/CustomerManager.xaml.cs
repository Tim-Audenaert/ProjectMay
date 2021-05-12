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

namespace ProjectMay
{
    /// <summary>
    /// Interaction logic for CustomerManager.xaml
    /// </summary>
    public partial class CustomerManager : Page
    {
        public CustomerManager()
        {
            InitializeComponent();
            using (Context ctx = new Context())
            {
                var customers = ctx.Customers;
                foreach (var item in customers)
                {
                    LvwCustomers.Items.Add(item);
                }
            }
        }

        private void LvwCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
