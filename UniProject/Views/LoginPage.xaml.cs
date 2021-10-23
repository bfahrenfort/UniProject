using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Temporary until we can pass information to and from database
            //to validate if the user's credentials exist/is correct
            if (TextUsername.Text == "Admin" && TextPassword.Text == "123")
            {
                //We need to find a way to change the MainPage such that the user can't login, hit 
                //the back arrow, and end up back at the login screen. We want that closed after login.
                Navigation.PopModalAsync(); //Takes you to SearchPage; Adds SearchPage to stack.
            }
            else
            {
                //Displays an error if login information is incorrect/doesn't exist.
                DisplayAlert("Error", "Username or Password is incorrect!", "Ok"); 
            }
        }
        
        //Button Action: Take them to the Forgot Password Page if they forgot their password.
        private void ForgotPasswordButtonTapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ForgotPasswordPage());
        }
        
        //Button Action: Take them to registration page if they don't have an account.
        private void RegisterButtonTapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistrationPage());
        }
    }
}