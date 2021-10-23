using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.Models;
using UniProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UniProject.Views
{
    public partial class SearchPage : ContentPage
    {
        public SchoolModel Selected { get; set; }

        public SearchPage()
        {
            InitializeComponent();
            Navigation.PushModalAsync(new LoginPage());
        }

        async void SchoolClicked(object sender, EventArgs e)
        {
            SchoolModel s = (((ListView) sender).BindingContext as SchoolViewModel).Selected;
            await Navigation.PushAsync(new BuildingPage(s), true);
        }

        private async void NavigateToSavedSearchButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SavedSearchesPage());
        }

    }
}
/**
public void SchoolSaved(object sender, EventArgs e)
{
    //query user id, save school name into the user saved database
}
**/