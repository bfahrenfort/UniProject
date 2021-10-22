using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

//features needed for User Login
namespace UniProject.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string u, string p)
        {
            Username = u;
            Password = p;
        }

    }
}