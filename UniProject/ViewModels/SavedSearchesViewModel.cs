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
    public class SavedSearchesViewModel: INotifyPropertyChanged
    {
        public School Selected { get; set; }
        private ObservableCollection<School> _savedSearches;
        
        public ObservableCollection<School> SavedSearches
        { 
            get => _savedSearches;
            set
            {
                _savedSearches = value;
                OnPropertyChanged(nameof(SavedSearches));
            } 
        }

        // Default constructor
        public SavedSearchesViewModel()
        {
            SavedSearches = new ObservableCollection<School>();
            //returns from database buildings from selected school
            DataTable test2 = DbConn.query("select * from School"); 
            SavedSearches = new ObservableCollection<School>(test2.Select().ToList().Select(r =>
                new School(r["SchoolName"] as string,
                    r["SchoolAddress"] as string,
                    r["ApplicationURL"] as string,
                    r["SchoolAcronym"] as string)));

        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}