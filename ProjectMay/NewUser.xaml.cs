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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        public NewUser()
        {
            InitializeComponent();
            using (Context ctx = new Context())
            {
                foreach (var item in ctx.Roles)
                {
                    CmbRoles.Items.Add(item);
                }
            }
        }

        private void CreateUser(object sender, RoutedEventArgs e)
        {
            using (Context ctx = new Context())
            {
                ctx.Users.Add(new User(TxtFirstName.Text, TxtLastName.Text, TxtUsername.Text, TxtPassword.Text, ctx.Roles.FirstOrDefault(r => r.Id == CmbRoles.SelectedIndex + 1))); ;
                ctx.SaveChanges();
            }
            MessageBox.Show("User created!");
        }
    }
}
