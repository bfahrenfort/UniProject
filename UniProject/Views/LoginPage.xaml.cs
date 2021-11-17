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
            string hash = Utilities.Hash(TextPassword.Text);
            //Query for the input user credentials used to login the user.
            var encode = Encoding.UTF8.GetBytes(TextUsername.Text + ":" + hash);
            string key = Convert.ToBase64String(encode);

            int userID = int.Parse(APIConn.Request("Auth/login?key=" + key));

            //Checks if there is any result for the entered Username and Password.
            if (userID == -1)
            {
                //Displays an error if login information is incorrect/doesn't exist.
                DisplayAlert("Error!",   "Username or Password is incorrect or doesn't exist.", "Ok");
            }
            
            //If it finds a matching result, takes the user to the search page.
            else
            {
                
                Utilities.UserID = (int) userID;
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