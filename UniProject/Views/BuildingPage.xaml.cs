using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuildingPage : ContentPage
    {
        public BuildingPage()
        {
            InitializeComponent();
        }
        
        async void BuildingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocationPage(),true);
        }
    }
}