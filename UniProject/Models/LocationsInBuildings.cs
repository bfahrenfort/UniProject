using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

//features needed for Locations in Buildings

namespace UniProject.Models
{
    public class LocationsInBuildings
    {
        public string LocationCol { get; set; } //primary key in database, not sure if needed here
        public string BuildingN { get; set; }
        public string  BuildingAdd { get; set; }
        public string LocOfInterest { get; set; }
        public string RoomLoc { get; set; }

        public LocationsInBuildings(string c, string n, string a, string h, string r)
        {
            LocationCol = c;//primary key in database
            BuildingN = n;
            BuildingAdd = a;
            LocOfInterest = h;
            RoomLoc = r;
        }
        
    }
}