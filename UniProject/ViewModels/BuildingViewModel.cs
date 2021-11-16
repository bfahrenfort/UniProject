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
        public InfoViewModel InfoVm { get; set; }
        
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
        
        public BuildingViewModel(SchoolModel s)
        {
            InfoVm = new InfoViewModel(s);
            //returns from database buildings from selected school
            DataTable buildingreturn = DbConn.Query("select * from building where SchoolName = @1", InfoVm.School.SchoolName); 
            Buildings = new ObservableCollection<BuildingModel>(buildingreturn.Select().ToList().Select(r =>
                new BuildingModel(r["BuildingName"] as string,
                    r["BuildingAddress"] as string,
                    r["PictureUrl"] as string,
                    r["SchoolName"] as string)));

        }

        public SchoolModel SchoolFromVm => InfoVm.School;

        // Required definitions to update the view
        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
