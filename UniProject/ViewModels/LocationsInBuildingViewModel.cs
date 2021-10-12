
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

//View model displaying list of different features within each building
namespace UniProject.ViewModels
{
    public class LocationsInBuildingViewModel: INotifyPropertyChanged
    {

        private ObservableCollection<LocationsInBuildings> _locations;
        
        public ObservableCollection<LocationsInBuildings> LocationsInBuildings
        { 
            get => _locations;
            set
            {
                _locations = value;
                OnPropertyChanged(nameof(LocationsInBuildings));
            } 
        }
        
        public LocationsInBuildingViewModel()
        {
            //needs to display building name at top
            //queries to display 
            DataTable test1 = DbConn.query("select * from location"); //not tested
            LocationsInBuildings = new ObservableCollection<LocationsInBuildings>(test1.Select().ToList().Select(r =>
                new LocationsInBuildings(r["LocationCol"] as string,
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