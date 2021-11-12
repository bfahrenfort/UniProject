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

namespace UniProject.ViewModels
{
    public class DeleteSavedSearchViewModel: INotifyPropertyChanged
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
        
        private UserModel _user;
        
        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public DeleteSavedSearchViewModel(UserModel u, SchoolModel s)
        {
            _school = s;
            _user = u;
            //returns from database buildings from selected school
            DataTable test2 = DbConn2.Query("DELETE FROM savedsearches (UserId, SavedSchool) Values (@1, @2)", _user.UserId,_school.SchoolName);
            
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}