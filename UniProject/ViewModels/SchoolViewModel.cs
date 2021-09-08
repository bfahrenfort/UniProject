using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniProject.Models;

namespace UniProject.ViewModels
{
    public class SchoolViewModel
    {
        public ObservableCollection<School> Schools { get; }

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