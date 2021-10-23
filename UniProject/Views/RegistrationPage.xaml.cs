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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        
        //Prevents Android users from using the (hardware) back button.
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        
        //Button Action: Create the exist or return an error.
        //If account successfully created, take them to login page.
        private void CreateAccountButtonClicked(object sender, EventArgs e)
        {
            //Temporary until we can pass information to and from database
            //to validate if the user's credentials exist/is correct
            
            /**
             * First, check if the account already exists
             *It's worth considering creating parameters for password length,
             * what symbols should be used, and the use of
             * a capital and/or lowercase letter(s), etc.
             * 
            if(User == UserInDatabase || Email == EmailInDatabase)
            {
                //Displays an error if login information already exists.
                DisplayAlert("Error", "Username or Email already exists!", "Ok"); 
            }
            **/
            
            //Next, we check if the passwords entered match up.
            if (NewPassword.Text != NewPasswordConfirm.Text)
            {
                
                DisplayAlert("Error", "Passwords don't match. Please try again.", "Ok");
            }
            //Finally, the account was successfully created.
            else
            {
                //addUserToDatabase(Username, Password, Email)
                DisplayAlert("Account Creation", "Account Successfully Created!", "Ok");
                //Takes you back to the LoginPage
                Navigation.PopModalAsync(); 

            }
        }
        
        //Button Action: If the account already exists, take them to login page.
        private void ExistingAccountButtonTapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(); 
        }
    }
}