using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.Models;
using UniProject.Utils;
using UniProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace UniProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedSearchesPage : ContentPage
    {
        public SchoolModel Selected { get; set; }

        public SavedSearchesPage()
        {
            InitializeComponent();
        }

        async void SchoolClicked(object sender, EventArgs e)
        {
            SchoolModel s = (((ListView) sender).BindingContext as SavedSearchesViewModel).Selected;
            await Navigation.PushAsync(new BuildingPage(s), true);
        }

        //Deletes the favorited university (Button is on the saved searches page)
        async void SchoolDeleteButton(object sender, EventArgs e)
        {
            SchoolModel s = ((SchoolModel) ((ImageButton) sender).BindingContext);
            string schoolName = s.SchoolName;
            //returns correct data, if statement below doesnt wait
            string saveExists =  APIConn.Request("api/removeSearch?userID=" + Utilities.UserID + "&schoolName=" + schoolName);

            if (saveExists.Equals("True"))
            {
                await DisplayAlert("Success!", "The University Was Removed From Your Saved Searches.", "Close");              
            }
            else
            {
                await DisplayAlert("Error!", "Saved Item Not Found.", "Close");
            }
        }
    }
}