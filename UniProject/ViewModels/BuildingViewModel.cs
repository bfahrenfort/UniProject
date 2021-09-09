using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniProject.Models;

//View Model Displaying list of different buildings on campus

namespace UniProject.ViewModels
{
    public class BuildingViewModel
    {
        public ObservableCollection<Building> Buildings { get; }

        public BuildingViewModel()
        {
            Buildings = new ObservableCollection<Building>
            {
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
                new Building { BuildingName = "" ,BuildingAddress = ""},
            };
            
        }
    }
}