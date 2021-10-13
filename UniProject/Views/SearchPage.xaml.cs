using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.Models;
using UniProject.ViewModels;
using Xamarin.Forms;

namespace UniProject.Views
{
    public partial class SearchPage : ContentPage
    {
        public School Selected { get; set; }
        public SearchPage()
        {
            InitializeComponent();
        }
        
        async void SchoolClicked(object sender, EventArgs e)
        {
            School s = (((ListView) sender).BindingContext as SchoolViewModel).Selected;
            await Navigation.PushAsync(new BuildingPage(s),true);
        }

        public void SchoolSaved(object sender, EventArgs e)
        {
            //query user id, save school name into the user saved database
        }
    }
}