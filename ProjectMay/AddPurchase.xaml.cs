using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                var suppliers = ctx.Suppliers;
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
                var products = ctx.Products.Include(nameof(Supplier)).Where(p => p.Supplier.Id == CmbSupplier.SelectedIndex + 1);
                foreach (var item in products)
                {
                    LvwProducts.Items.Add(item);
                }
            }

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            LvwPurchase.Items.Add(e.Source as Product);
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            LvwPurchase.Items.Remove(e.Source);
        }
    }
}
