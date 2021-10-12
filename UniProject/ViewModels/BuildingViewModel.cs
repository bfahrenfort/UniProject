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

        private ObservableCollection<Building> _buildings;
        
        public ObservableCollection<Building> Buildings
        { 
            get => _buildings;
            set
            {
                _buildings = value;
                OnPropertyChanged(nameof(Buildings));
            } 
        }
        
        // Default constructor
        public BuildingViewModel()
        {
            Buildings = new ObservableCollection<Building>();
            //THIS JUNK IS FOR TESTING ONLY{
            DataTable test2 = DbConn.query("select * from building"); //not tested
            Buildings = new ObservableCollection<Building>(test2.Select().ToList().Select(r =>
                new Building(r["BuildingName"] as string,
                    r["BuildingAddress"] as string,
                    r["PictureUrl"] as string,
                    r["SchoolName"] as string)));
            //END TESTING JUNK^ }
        }
        
        //!!!!!!!
        //THIS NEEDS FIXED TO ONLY QUERY FOR THE NEEDED BUILDING!
        
        /* public BuildingViewModel()
         {
 
                 //queries to display schooladdress, application url, followed by all buildings at school
                 DataTable test2 = DbConn.query("select * from building"); //not tested
             Buildings = new ObservableCollection<Building>(test2.Select().ToList().Select(r =>
                 new Building(r["BuildingName"] as string,
                     r["BuildingAddress"] as string,
                     r["PictureUrl"] as string,
                     r["SchoolName"] as string)));
 
         }*/
        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}