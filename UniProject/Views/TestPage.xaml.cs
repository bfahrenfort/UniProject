using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.ViewModels;
using Xamarin.Forms;

namespace UniProject.Views
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            //SchoolsList.ItemsSource = new SchoolViewModel().Schools;
            //var vm = new SchoolViewModel();
            //BindingContext = vm;
            InitializeComponent();
            
            //BuildingList.ItemSource = new BuildingViewModel().Buildings;
            //LocationsInBuildingsList.Itemsource = new LocationsinBuildingViewModel().LocationsInBuildings;
        }
    }
}