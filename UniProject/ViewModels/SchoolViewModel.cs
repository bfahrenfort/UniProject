// This ViewModel provides a View with access to lists of the School model which it can use in ListViews etc.

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

namespace UniProject.ViewModels
{
    public class SchoolViewModel : INotifyPropertyChanged
    {
        private const string TextSearchQuery = "select * from School where SchoolName like @1";

        //FIXME we don't really need an explicit backing field since we need to onpropertychanged it
        private ObservableCollection<School> _schools;
        public ObservableCollection<School> Schools
        { 
            get => _schools;
            set
            {
                _schools = value;
                OnPropertyChanged(nameof(Schools));
            } 
        }

        public SchoolViewModel()
        {
            Schools = new ObservableCollection<School>();
        }
        
        // Yes, this is technically a functional interface field, but it behaves like a method, so here it is.
        public ICommand Search => new Command<string>((query) =>
        {
            DataTable dt = DbConn.query(TextSearchQuery, '%' + query + '%');
            // Don't touch my GARBAGE!!!
            Schools = new ObservableCollection<School>(dt.Select().ToList().Select(r =>
                new School(r["SchoolName"] as string, 
                           r["SchoolAddress"] as string, 
                           r["ApplicationURL"] as string, 
                           r["SchoolAcronym"] as string)));
        });

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}