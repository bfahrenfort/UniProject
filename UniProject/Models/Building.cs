using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace UniProject.Models
{
    // Building on or around a School, will potentially contain locations of interest
    public class BuildingModel
    {
        public string BuildingName { get; set; }
        public string BuildingAddress { get; set; }
        public string PictureUrl { get; set; }
        public string SchoolN { get; set; }

        public BuildingModel(string n, string a, string u, string s)
        {
            BuildingName = n;
            BuildingAddress = a;
            PictureUrl = u;
            SchoolN = s;
        }
    }
}
