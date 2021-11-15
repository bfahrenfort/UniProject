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

        async void SchoolClicked(object sender, SelectedItemChangedEventArgs e)
        {
            SchoolModel s = (((ListView) sender).BindingContext as SavedSearchesViewModel).Selected;
            await Navigation.PushAsync(new BuildingPage(s), true);
        }

        async void SchoolDeleteButton(object sender, EventArgs e)
        {
            SchoolModel s = ((SchoolModel) ((Button) sender).BindingContext);
            var schoolname = s.SchoolName;
            //checks if school is already saved
            var saveExists = DbConn.QueryScalar("SELECT * FROM savedsearches WHERE UserId = @1 And SavedSchool = @2", Utilities.UserID, schoolname);
            if (saveExists != null)
            {
                await DisplayAlert("Successful!", "Deleted", "Close");
                var savesearch = DbConn.Query("DELETE FROM savedsearches WHERE UserId = @1 AND SavedSchool = @2", Utilities.UserID, schoolname);

            }
            else
            {
                //no longer in saved table, Null return
            }
        }
    }
}