using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using UniProject.Utils;
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
            
            var usernameExists = DbConn2.QueryScalar("SELECT * FROM user WHERE Username = @1", TextUsername.Text);
            
            //Checks if there is any result for the entered Username.
            if (usernameExists == null)
            {
                //Displays an error if login information is incorrect/doesn't exist.
                DisplayAlert("Error!",   "Username or Password is incorrect or doesn't exist." , "Ok");
            }
            
            //If it finds a matching result, it will pop-up with an alert with the return value (should be a 1).
            else //(int) usernameExists == 1
            {
                //Navigation.PopModalAsync(); //Takes you to SearchPage; Adds SearchPage to stack.
                DisplayAlert("Success!", "Returned: " + (int) usernameExists, "Let's Go!!!"); 
            }
           
            //You COULD further test this by adding an else if that says "else if ((int) usernameExists == 1)" and an
            //else statement with some sort of error/exception.
            
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