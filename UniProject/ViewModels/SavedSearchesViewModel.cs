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
using Newtonsoft.Json;
using System;

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
            try
            {
                SavedSearches = (ObservableCollection<SchoolModel>)JsonConvert.DeserializeObject(APIConn.Request("api/getSavedSearch?userID=" + Utilities.UserID), typeof(ObservableCollection<SchoolModel>));
            }
            catch (Exception) { throw; }

        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}