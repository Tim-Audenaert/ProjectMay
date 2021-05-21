using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        }

        private void AddUpdateProduct(object sender, RoutedEventArgs e)
        {
            string confirmation = string.Empty;
            using (Context ctx = new Context())
            {
                var product = ctx.Products.FirstOrDefault(p => p.Name == TxtName.Text);
                if (product == null)
                {
                    confirmation = "Product added!";
                    ctx.Products.Add(new Product(TxtName.Text, Convert.ToDouble(TxtPrice.Text), ctx.Suppliers.FirstOrDefault(s => s.Name == TxtSuppliers.Text)));
                }
                else
                {
                    confirmation = "Product updated!";
                    product.Name = TxtName.Text;
                    product.Price = Convert.ToDouble(TxtPrice.Text);
                }               
                ctx.SaveChanges();
            }
            MessageBox.Show(confirmation);
        }

        private void ImportJSon(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON Files (*.json)|*.json";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            string filename = string.Empty;
            // Get the selected file name and display in a TextBox 
            if (result.HasValue && result.Value)
            {
                // Open document                
                filename = dlg.FileName;
            }

            JObject o1 = JObject.Parse(File.ReadAllText(filename));
            Product product = o1.ToObject<Product>();
            GetSupplier(product);
            TxtSuppliers.Text = product.Supplier.Name;
            TxtName.Text = product.Name;
            TxtPrice.Text = product.Price.ToString();

            using (Context ctx = new Context())
            {
                var exists = ctx.Products.FirstOrDefault(p => p.Name == TxtName.Text);
                BtnAddUpdateProduct.Content = (exists == null) ? "Add Product" : "Update Product";
            }

                //read JSON directly from a file
                //using (StreamReader file = File.OpenText(filename))
                //using (JsonTextReader reader = new JsonTextReader(file))
                //{
                //    JObject o2 = (JObject)JToken.ReadFrom(reader);
                //    MessageBox.Show(o2.ToString());

                //}

        }

        private void GetSupplier(Product product)
        {
            using (Context ctx = new Context())
            {
                var supplier = ctx.Suppliers.FirstOrDefault(s => s.Name == product.Supplier.Name);
                if (supplier == null)
                {
                    if (MessageBox.Show("Supplier doesn't exist in the database. Would you like to add it?", "Supplier doesn't exist in the database. Would you like to add it?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        ctx.Suppliers.Add(new Supplier(product.Supplier.Name, product.Supplier.Address));
                        ctx.SaveChanges();
                        MessageBox.Show("Supplier has been added to the database");
                    }
                }
            }
        }
    }
}
