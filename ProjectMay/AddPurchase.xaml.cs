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
    /// Interaction logic for AddPurchase.xaml
    /// </summary>
    public partial class AddPurchase : Page
    {
        public AddPurchase()
        {
            InitializeComponent();
            using (Context ctx = new Context())
            {
                var suppliers = ctx.Suppliers.ToList();
                foreach (var item in suppliers)
                {
                    CmbSupplier.Items.Add(item);
                }

            }
        }

        private void CmbSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (Context ctx = new Context())
            {
                var products = ctx.Products.Where(p => p.Supplier == CmbSupplier.SelectedItem);
                foreach (var item in products)
                {
                    LvwProducts.Items.Add(item);
                }
            }

        }
    }
}
