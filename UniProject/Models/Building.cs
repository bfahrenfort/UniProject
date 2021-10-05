using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

//features needed for Building
namespace UniProject.Models
{
    public class Building
    {
        public string BuildingName { get; set; }
        public string BuildingAddress { get; set; }
        public string PictureUrl { get; set; }
        public string SchoolN { get; set; }

        public Building(string n, string a, string u, string s)
        {
            BuildingName = n;
            BuildingAddress = a;
            PictureUrl = u;
            SchoolN = s;
        }
    }
}
