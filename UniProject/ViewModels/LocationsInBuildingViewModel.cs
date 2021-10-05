using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniProject.Models;
using UniProject.Utils;

//View model displaying list of different features within each building

namespace UniProject.ViewModels
{
    public class LocationsInBuildingViewModel
    {
        public ObservableCollection<LocationsInBuildings> LocationsInBuildings { get; }

        public LocationsInBuildingViewModel()
        {
            LocationsInBuildings = new ObservableCollection<LocationsInBuildings>
            {

            };
            
        }
    }
}