using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace UniProject.Models
{
    // Class to store user information from database
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserModel(int d, string u, string p, string e)
        {
            UserId = d;
            Username = u;
            Password = p;
            Email = e;
        }

    }
}
