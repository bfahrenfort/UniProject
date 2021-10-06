using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using MySqlConnector;
using UniProject.Models;
using UniProject.Utils;
using Xamarin.Forms;

//View model displaying list of different features within each building

namespace UniProject.ViewModels
{
    public class LocationsInBuildingViewModel
    {
        public ObservableCollection<LocationsInBuildings> LocationsInBuildings { get; }

        public LocationsInBuildingViewModel()
        {
            LocationsInBuildings = new ObservableCollection<LocationsInBuildings>();
        }
        
        public LocationsInBuildingViewModel(string uniBuilding)
        {
            //needs to display building name at top
            //queries to display 
            DataTable test1 = DbConn.query("select * from Location where BuildingName = @1", uniBuilding); //not tested
            LocationsInBuildings = new ObservableCollection<LocationsInBuildings>(test1.Select().ToList().Select(r =>
                new LocationsInBuildings(r["LocationCol"] as string,
                    r["BuildingName"] as string,
                    r["BuildingN"] as string,
                    r["LocOfInterest"] as string,
                    r["RoomLoc"] as string)));

        }
    }
}