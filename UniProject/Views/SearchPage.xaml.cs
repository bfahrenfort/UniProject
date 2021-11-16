using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.Models;
using UniProject.Utils;
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
            //Whenever an item is selected, that item is assigned to the SchoolViewModel's Selected property
            //Get a reference to that item and pass it to the BuildingPage we push on the nav stack
            SchoolModel s = ((SchoolViewModel) ((ListView) sender).BindingContext).Selected;
            await Navigation.PushAsync(new BuildingPage(s));
        }

        async void SaveClicked(object sender, EventArgs e) //saves selected school
        {
            SchoolModel s = ((SchoolModel) ((CheckBox) sender).BindingContext);
            var schoolName = s.SchoolName;
            //Checks if the school is already saved.
            var saveExists = DbConn.QueryScalar("SELECT * FROM savedsearches WHERE UserId = @1 And SavedSchool = @2", Utilities.UserID, schoolName);

            //If the school isn't favorited, favorites the school.
            if (saveExists == null)
            {
                await DisplayAlert("Saved!", "The University Has Been Saved To Your Saved Searches", "Ok");
                DbConn.Query("INSERT INTO savedsearches (UserId, SavedSchool) Values (@1, @2)", Utilities.UserID, schoolName);
            }
            //If the school is already favorited, un-favorites the school.
            else
            {
                await DisplayAlert("Deleted", "The University Has Been Removed From Your Saved Searches", "Ok");
                DbConn.Query("DELETE FROM savedsearches WHERE UserId = @1 AND SavedSchool = @2", Utilities.UserID, schoolName);
            }
        }
 
        private async void NavigateToSavedSearchButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SavedSearchesPage());
        }

    }
}