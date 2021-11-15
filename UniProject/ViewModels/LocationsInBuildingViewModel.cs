
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UniProject.Models;
using UniProject.Utils;
using Xamarin.Forms;
using UniProject.Annotations;
using Xamarin.Essentials;

//View model displaying list of different features within each building
namespace UniProject.ViewModels
{
    public class LocationsInBuildingViewModel: INotifyPropertyChanged
    {
        private BuildingModel building;
        private ObservableCollection<LocationsInBuildingsModel> _locations;
        private LocationsInBuildingsModel locationbinding;
        private BuildingModel _building; //the building which locations are returned from
        public BuildingModel Building
        {
            get => _building;
            set
            {
                _building = value;
                OnPropertyChanged(nameof(Building));
            }
        }

        public LocationsInBuildingsModel Location
        {
            get => locationbinding;
            set
            {
                locationbinding = value;
                OnPropertyChanged(nameof(Location));
            }
        }
        public string BuildingNameFormatted => $"{_building.BuildingName}"; // Convenience
        public string BuildingPictureFormatted => $"{_building.PictureUrl}";
        public string BuildingAddressFormatted => $"{_building.BuildingAddress}";
        public string ImageUrlFormatted => $"{_building.PictureUrl}";
        
        public ObservableCollection<LocationsInBuildingsModel> LocationsInBuildings
        { 
            get => _locations;
            set
            {
                _locations = value;
                OnPropertyChanged(nameof(LocationsInBuildings));
            } 
        }
        
        public string RoomNumFormatted => $"{locationbinding.LocationAddress}";
        public LocationsInBuildingViewModel(BuildingModel b)
        {
            
            _building = b;
            //query to return all locations from selected building
            DataTable locationreturn = DbConn.query("select * from location where BuildingName = @1", b.BuildingName);
            LocationsInBuildings = new ObservableCollection<LocationsInBuildingsModel>(locationreturn.Select().ToList().Select(r =>
                new LocationsInBuildingsModel(r["LocationCol"] as string,
                    r["LocationName"] as string,
                    r["BuildingName"] as string,
                    r["LocationAddress"] as string,
                    r["SchoolName"] as string)));

        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}