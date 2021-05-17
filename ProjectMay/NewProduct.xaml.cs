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
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        public NewProduct()
        {
            InitializeComponent();
            using (Context ctx = new Context())
            {
                foreach (var item in ctx.Suppliers)
                {
                    CmbSuppliers.Items.Add(item);
                }
            }
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            using(Context ctx = new Context())
            {
                                                                                                                                    //TEMPORARY - WHAT IF ORDER CHANGES?      
                ctx.Products.Add(new Product(TxtName.Text, Convert.ToDouble(TxtPrice.Text), ctx.Suppliers.FirstOrDefault(s => s.Id == CmbSuppliers.SelectedIndex + 1)));
                ctx.SaveChanges();
            }
            MessageBox.Show("Product added!");
        }
    }
}
