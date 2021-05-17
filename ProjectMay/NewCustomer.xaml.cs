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
    /// Interaction logic for NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : Window
    {
        public NewCustomer()
        {
            InitializeComponent();
        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            using (Context ctx = new Context())
            {
                ctx.Customers.Add(new Customer(TxtFirstName.Text, TxtLastName.Text, Convert.ToInt32(TxtAge.Text), TxtAddress.Text));
                ctx.SaveChanges();
                MessageBox.Show("Customer added!");
            }
        }
    }
}
