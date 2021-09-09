// This ViewModel provides a View with access to lists of the School model which it can use in ListViews etc.

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniProject.Models;

namespace UniProject.ViewModels
{
    public class SchoolViewModel
    {
        // The list property, currently read-only because set has strange interactions with INotifyPropertyChanged on collections
        public ObservableCollection<School> Schools { get; }

        // Test constructor to show functionality
        public SchoolViewModel()
        {
            Schools = new ObservableCollection<School>
            {
                new School { Name = "Sam Houston State University", Acronym = "SHSU" },
                new School { Name = "Stephen F. Austin University", Acronym = "SFA" }
            };
        }
        
    }
}