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
            UserId = Id;
            InitializeComponent();
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
                User toDelete = ctx.Users.Where(u => u.Id == UserId) as User;
                ctx.Users.Remove(toDelete);
                ctx.SaveChanges();
                MessageBox.Show("Success!");
            }
        }
    }
}
