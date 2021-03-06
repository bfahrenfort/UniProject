using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace UniProject.Models
{
    // Location in a building, with information about that location
    public class LocationsInBuildingsModel
    {
        public string LocationCol { get; set; } //primary key in database, not sure if needed here
        
        public string LocationName { get; set; }
        
        public string BuildingName { get; set; }
        
        public string LocationAddress { get; set; }
        
        public string SchoolName { get; set; }

        public LocationsInBuildingsModel(string c, string n, string b, string a, string s)
        {
            LocationCol = c;//primary key in database
            LocationName = n;
            BuildingName = b;
            LocationAddress = a;
            SchoolName = s;
        }
        
    }
}
