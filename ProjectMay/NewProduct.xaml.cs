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
            {                                                                                                                                    //TEMPORARY - WHAT IF ORDER CHANGES?      
                ctx.Products.Add(new Product(TxtName.Text, Convert.ToDouble(TxtPrice.Text), ctx.Suppliers.FirstOrDefault(s => s.Id == CmbSuppliers.SelectedIndex + 1)));
                ctx.SaveChanges();
            }
            MessageBox.Show("Product added!");
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

            //JObject o1 = JObject.Parse(File.ReadAllText(filename));
            //Product product = o1.ToObject<Product>();
            //CmbSuppliers.Text = product.Supplier.Name;
            //TxtName.Text = product.Name;
            //TxtPrice.Text = product.Price.ToString();

            //read JSON directly from a file
            using (StreamReader file = File.OpenText(filename))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                MessageBox.Show(o2.ToString());
            }

        }
    }
}
