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
    /// Interaction logic for CustomerOverview.xaml
    /// </summary>
    public partial class CustomerOverview : Page
    {
        public CustomerOverview()
        {
            InitializeComponent();
            Context ctx = new Context();
            List<Customer> customers = ctx.Customers.ToList();
            //foreach (var item in customers)
            //{
            //    dtgCustomers.Items.Add(item);
            //}
            
        }
    }
}
