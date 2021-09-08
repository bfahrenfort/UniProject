using System.Collections.ObjectModel;
using UniProject.Models;

namespace UniProject.ViewModels
{
    public class BuildingViewModel
    {
        public ObservableCollection<Building> Buildings { get; }

        public BuildingViewModel()
        {
            Buildings = new ObservableCollection<Building>
            {
                new Building { buildingName = "" ,buildingLocation = ""},
                new Building { buildingName = "" ,buildingLocation = ""}
            };
            
        }
    }
}