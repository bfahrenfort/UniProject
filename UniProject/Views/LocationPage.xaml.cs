using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.Models;
using UniProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage : ContentPage
    {
        private Building building;
        
        public LocationPage(Building b)
        {
            building = b;
            BindingContext = new LocationsInBuildingViewModel(building);
            InitializeComponent();
        }
    }
}