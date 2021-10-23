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

//View Model Displaying list of different buildings on campus

namespace UniProject.ViewModels
{
    public class BuildingViewModel: INotifyPropertyChanged
    {
        private SchoolModel _school;
        public SchoolModel School
        {
            get => _school;
            set
            {
                _school = value;
                OnPropertyChanged(nameof(School));
            }
        }
        public string SchoolNameFormatted => $"School Name: {_school.SchoolName}"; // Convenience

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

       /*THIS DEFAULT CONSTRUCTOR BREAKS THE PROGRAM
        I can't see why it would break it, because we never call this constructor in BuildingPage's code-behind 
          or implicitly instantiate it in the layout XAML. Are you using the BuildingViewModel for more than one page?
          That would absolutely break that page because it doesn't have a school passed to it. -Kirby
        public BuildingViewModel()
        {
            Buildings = new ObservableCollection<Building>();
        }*/
       
        public BuildingViewModel(SchoolModel s)
        {
            _school = s;
            //returns from database buildings from selected school
            DataTable test2 = DbConn.query("select * from building where SchoolName = @1", _school.SchoolName); 
            Buildings = new ObservableCollection<BuildingModel>(test2.Select().ToList().Select(r =>
                new BuildingModel(r["BuildingName"] as string,
                    r["BuildingAddress"] as string,
                    r["PictureUrl"] as string,
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