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
    /// Interaction logic for ProductManager.xaml
    /// </summary>
    public partial class ProductManager : Page
    {
        public ProductManager()
        {
            InitializeComponent();
            using (Context ctx = new Context())
            {
                var products = ctx.Products.Include(p => p.Supplier);
                foreach (var item in products)
                {
                    LvwProducts.Items.Add(item);
                }
            }
        }

        private void LvwProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnDeleteProduct.IsEnabled = true;
        }
        private void AddUpdateProduct(object sender, RoutedEventArgs e)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.Show();
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            using (Context ctx = new Context())
            {
                ctx.Products.Remove(ctx.Products.Find((LvwProducts.SelectedItem as Product).Id));
                ctx.SaveChanges();
            }
            MessageBox.Show("Product deleted!");
        }
    }
}
