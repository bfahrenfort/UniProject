using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using MySqlConnector;
using UniProject.Models;
using UniProject.Utils;
using Xamarin.Forms;

//View Model Displaying list of different buildings on campus

namespace UniProject.ViewModels
{
    public class BuildingViewModel
    {   
        
        public ObservableCollection<Building> Buildings { get; }

        // Default constructor
        public BuildingViewModel()
        {
            Buildings = new ObservableCollection<Building>();
            
        }
        
        // When page is instantiated from a school
        public BuildingViewModel(string uniName)
        {
                //needs to display uni name at top
                //queries to display schooladdress, application url, followed by all buildings at school
            DataTable test2 = DbConn.query("select * from School where SchoolName = @1", uniName); //not tested
            Buildings = new ObservableCollection<Building>(test2.Select().ToList().Select(r =>
                new Building(r["BuildingName"] as string,
                    r["BuildingAddress"] as string,
                    r["PictureUrl"] as string,
                    r["SchoolName"] as string)));

        }
    }
}