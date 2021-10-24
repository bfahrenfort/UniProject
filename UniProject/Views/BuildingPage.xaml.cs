using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniProject.Models;
using UniProject.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace UniProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuildingPage : ContentPage
    {

        private SchoolModel school;
        public BuildingPage(SchoolModel s)
        {
            // Get the selected school
            school = s;
            // Pass that school to where we can bind to it, in the viewmodel we instantiate for our BindingContext
            BindingContext = new BuildingViewModel(school);
            
            InitializeComponent();
        }
        
        async void BuildingClicked(object sender, EventArgs e)
        {
            BuildingModel b = (((ListView) sender).BindingContext as BuildingViewModel).Selected;
            await Navigation.PushAsync(new LocationPage(b),true);
        }
        
    }
}