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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //CreateDatabase();
        }

        public void CreateDatabase()
        {
            using (Context ctx = new Context())
            {
                ctx.Roles.Add(new Role("Admin"));
                ctx.Roles.Add(new Role("Clerk"));
                ctx.Roles.Add(new Role("Salesman"));
                ctx.SaveChanges();

                ctx.Users.Add(new User("Tim", "Audenaert", "Overlord", "", ctx.Roles.FirstOrDefault(r => r.Id == 1)));
                ctx.Users.Add(new User("Ken", "Field", "Clerk", "test", ctx.Roles.FirstOrDefault(r => r.Id == 2)));
                ctx.Users.Add(new User("Wesley", "Messiaen", "Sales", "", ctx.Roles.FirstOrDefault(r => r.Id == 3)));
                ctx.SaveChanges();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Context ctx = new Context())
            {
                var user = ctx.Users.Include(nameof(Role)).FirstOrDefault(u => u.Username == TxtUsername.Text);
                if (user == null)
                {
                    MessageBox.Show("Username does not exist.");
                }
                else
                {
                    if (user.Password == User.CreateMD5(TxtPassword.Text))
                    {
                        Global.UserId = user.Id;
                        Global.Username = user.Username;
                        Global.Role = user.Role.Name;
                        MessageBox.Show("Successfully logged in. Redirecting...");
                        MainMenu main = new MainMenu();
                        Hide();
                        main.Show();
                    }
                    else MessageBox.Show("Incorrect password.");
                }
            }
        }        
    }
}
