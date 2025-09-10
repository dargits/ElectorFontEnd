using Elector.Forms.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// UserSession.cs
namespace Elector
{
    public static class UserSession
    {
        public static bool IsLoggedIn { get; set; } = false;
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string FullName { get; set; }
        public static bool IsAdmin { get; set; }

        public static void Login(User user)
        {
            IsLoggedIn = true;
            UserId = user.Id;
            Username = user.Username;
            FullName = user.FullName;
            IsAdmin = user.IsAdmin;
        }

        public static void Logout()
        {
            IsLoggedIn = false;
            UserId = 0;
            Username = null;
            FullName = null;
            IsAdmin = false;
        }
    }
}