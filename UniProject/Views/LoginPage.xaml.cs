using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using UniProject.Utils;
using UniProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace UniProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        //Prevents Android users from using the (hardware) back button.
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        //Button Action: Login the user if information is correct, taking them to SearchPage.
        private void LoginButtonClicked(object sender, EventArgs e)
        {
            //Query for the input user credentials used to login the user.
            var credentialsExists = DbConn2.QueryScalar("SELECT UserID FROM user WHERE Username = @1  AND Password = @2", TextUsername.Text, TextPassword.Text);
            
            //Checks if there is any result for the entered Username and Password.
            if (credentialsExists == null)
            {
                //Displays an error if login information is incorrect/doesn't exist.
                DisplayAlert("Error!",   "Username or Password is incorrect or doesn't exist.", "Ok");
            }
            
            //If it finds a matching result, takes the user to the search page.
            else
            {
                
                Utilities.UserID = (int) credentialsExists;
                Navigation.PopModalAsync();
            }
        }
        
        //Button Action: Take the user to the Forgot Password Page if they forgot their password.
        private void ForgotPasswordButtonTapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ForgotPasswordPage());
        }
        
        //Button Action: Take the user to registration page if they don't have an account.
        private void RegisterButtonTapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistrationPage());
        }
    }
}