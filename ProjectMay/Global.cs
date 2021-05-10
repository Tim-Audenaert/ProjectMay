using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMay
{
    static class Global
    {
        private static int userId;

        public static int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private static string username;

        public static string Username
        {
            get { return username; }
            set { username = value; }
        }

        private static string role;
        public static string Role
        {
            get { return role; }
            set { role = value; }
        }

    }
}
