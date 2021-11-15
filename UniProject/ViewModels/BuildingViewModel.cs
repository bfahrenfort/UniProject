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

//View Model Displaying list of different buildings on campus

namespace UniProject.ViewModels
{
    public class BuildingViewModel: INotifyPropertyChanged
    {
        private SchoolModel _school; // The School this building list is returned from
        public SchoolModel School
        {
            get => _school;
            set
            {
                _school = value;
                OnPropertyChanged(nameof(School));
            }
        }
        public string SchoolNameFormatted => $"{_school.SchoolName}"; // For convenience, in accordance with MVVM
        public string SchoolAddressLabel => $"{_school.SchoolAddress}";
        public string SchoolUrlLabel => $"{_school.ApplicationURL}";
    
        private ObservableCollection<BuildingModel> _buildings;
        public ObservableCollection<BuildingModel> Buildings
        { 
            get => _buildings;
            set
            {
                _buildings = value;
                OnPropertyChanged(nameof(Buildings));
            } 
        }
        
        public BuildingModel Selected { get; set; } // The building in Buildings currently selected
        
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public BuildingViewModel(SchoolModel s)
        {
            _school = s;
            //returns from database buildings from selected school
            DataTable buildingreturn = DbConn.query("select * from building where SchoolName = @1", _school.SchoolName); 
            Buildings = new ObservableCollection<BuildingModel>(buildingreturn.Select().ToList().Select(r =>
                new BuildingModel(r["BuildingName"] as string,
                    r["BuildingAddress"] as string,
                    r["PictureUrl"] as string,
                    r["SchoolName"] as string)));

        }
        
        // Required definitions to update the view
        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
