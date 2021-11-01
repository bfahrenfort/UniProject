using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

//features needed for User Login
namespace UniProject.Models
{
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