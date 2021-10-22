using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

//features needed for User Login
namespace UniProject.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserModel(string u, string p)
        {
            Username = u;
            Password = p;
        }

    }
}