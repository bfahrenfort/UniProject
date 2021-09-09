using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

//features needed for Locations in Buildings

namespace UniProject.Models
{
    public class LocationsInBuildings
    {
        private string buildingN;
        public string BuildingN { get; set; }

        private string buildingAdd;
        public string BuildingAdd { get; set; }

        private string locOfInterest;
        public string LocOfInterest { get; set; }
        
        private string roomLoc;
        public string RoomLoc { get; set; }
        
        
    }
}