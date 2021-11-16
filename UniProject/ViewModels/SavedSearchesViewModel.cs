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
        public SchoolModel Selected { get; set; }
        private ObservableCollection<SchoolModel> _savedSearches;
        
        public ObservableCollection<SchoolModel> SavedSearches
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
            SavedSearches = new ObservableCollection<SchoolModel>();
            //returns from database all schools which match the logged in user's id
            DataTable schoolReturn = 
                DbConn.Query("SELECT * FROM school Where SchoolName in (Select SchoolName From school Where SchoolName in (Select SavedSchool From savedsearches where UserID = @1))", Utilities.UserID);
            SavedSearches = new ObservableCollection<SchoolModel>(schoolReturn.Select().ToList().Select(r =>
                new SchoolModel(r["SchoolName"] as string,
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