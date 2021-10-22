using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.Models;
using UniProject.ViewModels;
using Xamarin.Forms;
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
            await Navigation.PushAsync(new BuildingPage(s),true);
        }
    }
}