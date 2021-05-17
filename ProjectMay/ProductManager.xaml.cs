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
    /// Interaction logic for ProductManager.xaml
    /// </summary>
    public partial class ProductManager : Page
    {
        public ProductManager()
        {
            InitializeComponent();
            using (Context ctx = new Context())
            {
                var products = ctx.Products;
                foreach (var item in products)
                {
                    LvwProducts.Items.Add(item);
                }
            }
        }

        private void LvwProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CreateNewProduct(object sender, RoutedEventArgs e)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.Show();
        }
    }
}
