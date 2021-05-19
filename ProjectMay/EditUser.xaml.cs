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
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public int UserId { get; set; }

        public EditUser()
        {
            InitializeComponent();
        }
        public EditUser(int Id)
        {
            InitializeComponent();
            UserId = Id;
            using (Context ctx = new Context())
            {
                foreach (var item in ctx.Roles)
                {
                    CmbRoles.Items.Add(item);
                }

                User user = ctx.Users.FirstOrDefault(u => u.Id == UserId);
                TxtFirstName.Text = user.FirstName;
                TxtLastName.Text = user.LastName;
                TxtUsername.Text = user.Username;
                CmbRoles.SelectedItem = user.Role;

            }
        }

        private void Delete_User(object sender, RoutedEventArgs e)
        {
            using (Context ctx = new Context())
            {
                User toDelete = ctx.Users.FirstOrDefault(u => u.Id == UserId);
                ctx.Users.Remove(toDelete);
                ctx.SaveChanges();
                MessageBox.Show("Success!");
            }
        }

        private void Edit_User(object sender, RoutedEventArgs e)
        {
            using (Context ctx = new Context())
            {
                User toEdit = ctx.Users.FirstOrDefault(u => u.Id == UserId);
                toEdit.FirstName = TxtFirstName.Text;
                toEdit.LastName = TxtLastName.Text ;
                toEdit.Username = TxtUsername.Text;
                toEdit.Password = TxtPassword.Text == string.Empty ? toEdit.Password : TxtPassword.Text;
                toEdit.Role = ctx.Roles.FirstOrDefault(r => r.Id == CmbRoles.SelectedIndex + 1);
                ctx.SaveChanges();
                MessageBox.Show("Success!");
            }
        }
    }
}
