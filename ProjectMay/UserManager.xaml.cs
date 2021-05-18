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
    /// Interaction logic for UserManager.xaml
    /// </summary>
    public partial class UserManager : Page
    {
        public UserManager()
        {
            InitializeComponent();
            using (Context ctx = new Context())
            {
                var users = ctx.Users.Include(u => u.Role);
                foreach (var item in users)
                {
                    LvwUsers.Items.Add(item);
                }
            }
        }

        private void LvwUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CreateNewUser(object sender, RoutedEventArgs e)
        {
            NewUser newuser = new NewUser();
            newuser.Show();

        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            User user = button.DataContext as User;
            EditUser edit = new EditUser(user.Id);
            edit.Show();
        }
    }
}
