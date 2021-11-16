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
    public partial class CompareSearchPage : ContentPage
    {
        public SchoolModel Selected { get; set; }
        private SchoolModel _school1;

        public CompareSearchPage(SchoolModel s)
        {
            _school1 = s;
            InitializeComponent();
        }
    
        async void SchoolClicked(object sender, EventArgs e)
        {
            //Whenever an item is selected, that item is assigned to the SchoolViewModel's Selected property
            //Get a reference to that item and pass it to the BuildingPage we push on the nav stack
            SchoolModel school2 = ((SchoolViewModel) ((ListView) sender).BindingContext).Selected;
            await Navigation.PushAsync(new ComparePage(_school1, school2));
        }
    }
}