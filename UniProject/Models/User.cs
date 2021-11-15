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

        public UserModel(int d, string u)
        {
            UserId = d;
            Username = u;
        }
    }
}
