using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniProject.Models;
using UniProject.Utils;

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
            Buildings = new ObservableCollection<Building>();
        }
    }
}