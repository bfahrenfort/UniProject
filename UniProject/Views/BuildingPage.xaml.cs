using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UniProject.Models;
using UniProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuildingPage : ContentPage
    {
        private School school;
        public BuildingPage(School s)
        {
            school = s;
            BindingContext = new BuildingViewModel(school);
            InitializeComponent();
        }
        
        async void BuildingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocationPage(),true);
        }
    }
}