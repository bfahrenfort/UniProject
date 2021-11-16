using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
        private ObservableCollection<SchoolModel> _savedSearches;
        
        public ObservableCollection<SchoolModel> SavedSearches
        { 
            get => _savedSearches;
            set
            {
                _savedSearches = value;
                OnPropertyChanged(nameof(SavedSearches));
            } 
        }
        public SavedSearchesPage()
        {
            InitializeComponent();
        }

        async void SchoolClicked(object sender, SelectedItemChangedEventArgs e)
        {

            SchoolModel s = (((ListView) sender).BindingContext as SavedSearchesViewModel).Selected;
            await Navigation.PushAsync(new BuildingPage(s), true);
        }

        //Deletes the favorited university (Button is on the saved searches page)
        async void SchoolDeleteButton(object sender, EventArgs e)
        {
            SchoolModel s = ((SchoolModel) ((Button) sender).BindingContext);
            String schoolname = s.SchoolName;
            //Remove the line below this at a later date.
            await DisplayAlert("Success!", "The university was removed from your saved searches.", "Close");
            DbConn.Query("DELETE FROM savedsearches WHERE UserId = @1 AND SavedSchool = @2", Utilities.UserID, schoolname);
            
            //updates to display all remaining universities
            SchoolsList.ItemsSource = null;
            SchoolsList.ItemsSource = _savedSearches;
            
        }
    }
}