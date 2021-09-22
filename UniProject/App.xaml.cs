using System;
using UniProject.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UniProject
{
    public partial class App : Application
    {
        public App()
        {
            const string connString = "server=SERVERNAME;user=USERNAME;database=DBNAME;port=3306;password=PASSWORD";
            InitializeComponent();

            MainPage = new TestPage(); // Set the main page being displayed as our test page
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
